using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Battleship.Logger;
using Battleship.BattleshipModel;

namespace Battleship.BattleshipControl
{
    public enum GameMode
    {
        Setup,
        Battle
    }

    public class BattleshipController
    {
        public event EventHandler GameReady;
        public event EventHandler GameReset;
        public event EventHandler GameOver;
        public event EventHandler ActiveShipTypeChanged;
        public event EventHandler ActiveShipLayoutChanged;

        private static BattleshipController _instance = null;
        private static object _lock = new Object();

        private BattleshipManager _battleshipManager;

        private ShipType _activeAvailableShipTypeOfPlayer1;
        private ShipType _activeAvailableShipTypeOfPlayer2;

        private ShipLayout _activeShipLayoutOfPlayer1;
        private ShipLayout _activeShipLayoutOfPlayer2;

        private BattleshipController()
        {
            _battleshipManager = new BattleshipManager();
            _activeAvailableShipTypeOfPlayer1 = ShipType.Unknown;
            _activeAvailableShipTypeOfPlayer2 = ShipType.Unknown;

            _activeShipLayoutOfPlayer1 = ShipLayout.Horizontal;
            _activeShipLayoutOfPlayer2 = ShipLayout.Horizontal;

            GameMode = GameMode.Setup;
        }

        public static BattleshipController Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_lock)
                    {
                        if (null == _instance)
                        {
                            _instance = new BattleshipController();
                        }
                    }
                }
                return _instance;
            }
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            return player == Player1 ? Player2 : Player1;
        }

        #region Public Properties
        public GameMode GameMode
        {
            get; set;
        }

        public IPlayer PreviousPlayer
        {
            get; set;
        }

        public IPlayer Player1
        {
            get
            {
                return _battleshipManager.Player1;
            }
        }

        public IPlayer Player2
        {
            get
            {
                return _battleshipManager.Player2;
            }
        }

        public ShipLayout ShipLayoutOfPlayer1
        {
            get
            {
                return _activeShipLayoutOfPlayer1;
            }
            set
            {
                if(_activeShipLayoutOfPlayer1 != value)
                {
                    _activeShipLayoutOfPlayer1 = value;

                    if(ActiveShipLayoutChanged != null)
                    {
                        ActiveShipLayoutChanged(Player1, null);
                    }
                }
            }
        }

        public ShipLayout ShipLayoutOfPlayer2
        {
            get
            {
                return _activeShipLayoutOfPlayer2;
            }
            set
            {
                if (_activeShipLayoutOfPlayer2 != value)
                {
                    _activeShipLayoutOfPlayer2 = value;

                    if (ActiveShipLayoutChanged != null)
                    {
                        ActiveShipLayoutChanged(Player2, null);
                    }
                }
            }
        }

        public ShipType ActiveShipTypeOfPlayer1
        {
            get
            {
                return _activeAvailableShipTypeOfPlayer1;
            }
            set
            {
                _activeAvailableShipTypeOfPlayer1 = value;
                if (ActiveShipTypeChanged != null)
                {
                    ActiveShipTypeChanged(Player1, null);
                }
            }
        }

        public ShipType ActiveShipTypeOfPlayer2
        {
            get
            {
                return _activeAvailableShipTypeOfPlayer2;
            }
            set
            {
                _activeAvailableShipTypeOfPlayer2 = value;
                if (ActiveShipTypeChanged != null)
                {
                    ActiveShipTypeChanged(Player2, null);
                }
            }
        }

        #endregion Public Properties

        public void Initialize()
        {
            Log.Logger.Write(LogLevel.Info, $"BattleshipController: initialize");
            _battleshipManager.Initialize();
        }

        public void StartBattle()
        {
            GameMode = GameMode.Battle;
            PreviousPlayer = null;
        }

        public void ResetGame()
        {
            Log.Logger.Write(LogLevel.Info, $"BattleshipController: User Reset the game");
            GameMode = GameMode.Setup;
            _battleshipManager.Reset();
            PreviousPlayer = null;

            if (GameReset != null)
                GameReset(null, null);
        }

        public bool TryPlaceShip(IPlayer player, Location location, ShipType shipType)
        {
            ShipLayout layout = (player == Player1 ? _activeShipLayoutOfPlayer1 : _activeShipLayoutOfPlayer2);
            return _battleshipManager.TryPlaceShip(player, location, shipType, layout);
        }

        public bool PlaceShip(IPlayer player, Location location)
        {
            var shipType = (player == BattleshipController.Instance.Player1 ? ActiveShipTypeOfPlayer1 : ActiveShipTypeOfPlayer2);

            if (shipType == ShipType.Unknown)
                return false;

            IShip ship = GetShip(player, location);
            if (ship != null)
            {
                if (ship.ShipType != shipType)
                {
                    return false;
                }
            }

            if (TryPlaceShip(player, location, shipType))
            {
                Log.Logger.Write(LogLevel.Info, $"BattleshipController: Player {player.ID} placed {shipType} at ({location.Row}, {location.Col})");
                var layout = (player == BattleshipController.Instance.Player1 ? _activeShipLayoutOfPlayer1 : _activeShipLayoutOfPlayer2);
                if (_battleshipManager.PlaceShip(player, location, shipType, layout))
                {
                    if (Player1 == player)
                    {
                        ActiveShipTypeOfPlayer1 = ShipType.Unknown;
                    }
                    else
                    {
                        ActiveShipTypeOfPlayer2 = ShipType.Unknown;
                    }
                }
            }

            if(_battleshipManager.IsGameReady())
            {
                GameReady(null, null);
            }

            return true;
        }

        public bool IsShipAvailable(IPlayer player, ShipType shipType)
        {
            return _battleshipManager.IsShipAvailable(player, shipType);
        }

        public void Attack(IPlayer player, Location location)
        {
            // not the player's turn
            if (player == PreviousPlayer)
                return;

            // No need attack because game is over
            var opponent = GetOpponent(player);
            if (_battleshipManager.AreAllShipsDamaged(opponent) ||
                _battleshipManager.AreAllShipsDamaged(player))
                return;

            _battleshipManager.Attack(player, location);

            PreviousPlayer = player;

            if (_battleshipManager.AreAllShipsDamaged(opponent))
            {
                GameOver?.Invoke(opponent, null);
            }
        }

        public bool IsGameOver()
        {
            return _battleshipManager.AreAllShipsDamaged(Player1) || _battleshipManager.AreAllShipsDamaged(Player2);

        }

        public ICell GetCell(IPlayer player, Location location)
        {
            IBoard board = _battleshipManager.GetBoard(player);
            return board.GetCell(location);
        }

        public IShip GetShip(IPlayer player, Location location)
        {
            return _battleshipManager.GetShip(player, location);
        }
    }
}

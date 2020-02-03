using Battleship.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class BattleshipManager
    {
        private const string _settingPath = @"Config\BattleshipSetting.json";
        private BattleshipConfig _battleshipConfig;
        private Dictionary<IPlayer, IBoard> _boardByPlayer;
        private Dictionary<IPlayer, List<IShip>> _shipByPlayer;
        private IBoard _boardOfPlayer1;
        private IBoard _boardOfPlayer2;
        private List<IShip> _shipsOfPlayer1;
        private List<IShip> _shipsOfPlayer2;

        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }

        public BattleshipManager()
        {
            _boardByPlayer = new Dictionary<IPlayer, IBoard>();
            _shipByPlayer = new Dictionary<IPlayer, List<IShip>>();

            _shipsOfPlayer1 = new List<IShip>();
            _shipsOfPlayer2 = new List<IShip>();

            Player1 = new Player(1);
            Player2 = new Player(2);

            _shipByPlayer[Player1] = _shipsOfPlayer1;
            _shipByPlayer[Player2] = _shipsOfPlayer2;
        }

        public void Initialize()
        {
            /// <summary>
            /// Consider connect to DB in the future
            /// </summary>
            if (File.Exists(_settingPath))
            {
                var text = File.ReadAllText(_settingPath);
                this._battleshipConfig = JsonConvert.DeserializeObject<BattleshipConfig>(text, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    Error = (sender, args) => { args.ErrorContext.Handled = true; }
                });

                if (_battleshipConfig == null)
                {
                    _battleshipConfig = new BattleshipConfig();
                    Log.Logger.Write(LogLevel.Warn, "Config: BattleshipSetting.json is crashed.");
                }
            }
            else
            {
                _battleshipConfig = new BattleshipConfig();
                Log.Logger.Write(LogLevel.Warn, "Config: BattleshipSetting.json does not exist.");
            }

            // TODO: we can make this configurable if needed
            var shipSizeByType = new Dictionary<ShipType, Size>();
            shipSizeByType[ShipType.Carrier] = new Size(1, 5);
            shipSizeByType[ShipType.Battleship] = new Size(1, 4);
            shipSizeByType[ShipType.Submarine] = new Size(1, 3);
            shipSizeByType[ShipType.Cruiser] = new Size(1, 2);
            shipSizeByType[ShipType.Patrol] = new Size(1, 1);

            _battleshipConfig.ShipSizeByType = shipSizeByType;
            _boardOfPlayer1 = new Board(_battleshipConfig.BoardSquare.Value, _battleshipConfig);
            _boardOfPlayer1.Owner = Player1.ID;
            _boardOfPlayer2 = new Board(_battleshipConfig.BoardSquare.Value, _battleshipConfig);

            _boardByPlayer[Player1] = _boardOfPlayer1;
            _boardByPlayer[Player2] = _boardOfPlayer2;
        }

        public void Reset()
        {
            Log.Logger.Write(LogLevel.Warn, $"BattleshipManager: Reset");

            _boardOfPlayer1.Reset();
            _boardOfPlayer2.Reset();

            Log.Logger.Write(LogLevel.Warn, $"BattleshipManager: Reset ships");
            _shipsOfPlayer1.Clear();
            _shipsOfPlayer2.Clear();
        }

        public IBoard GetBoard(IPlayer player)
        {
            IBoard board = _boardByPlayer[player];
            return board;
        }

        public IShip GetShip(IPlayer player, Location location)
        {
            var ships = (player == Player1 ? _shipsOfPlayer1 : _shipsOfPlayer2);
            foreach(var ship in ships)
            {
                if (ship.HasLocation(location))
                    return ship;
            }

            return null;
        }

        public bool IsShipAvailable(IPlayer player, ShipType shipType)
        {
            var ships = _shipByPlayer[player];
            foreach(var ship in ships)
            {
                if(ship.ShipType == shipType)
                {
                    return false;
                }
            }

            return true;
        }

        public bool TryPlaceShip(IPlayer player, Location location, ShipType shipType, ShipLayout layout)
        {
            IBoard board = _boardByPlayer[player];
            return board.TryPlaceShip(location, shipType, layout);
        }

        public bool PlaceShip(IPlayer player, Location location, ShipType shipType, ShipLayout layout)
        {
            IBoard board = _boardByPlayer[player];
            var ships = _shipByPlayer[player];

            if (!board.TryPlaceShip(location, shipType, layout))
                return false;

            IShip ship = ShipFactory.CreateShip(board, location, shipType, layout, _battleshipConfig.ShipSizeByType);
            ship.Owner = player.ID;
            ships.Add(ship);

            foreach (var cell in ship.Cells)
                cell.HasShip = true;

            return true;
        }

        public bool Attack(IPlayer attacker, Location location)
        {
            IBoard board = _boardOfPlayer1;
            if (attacker == Player1)
                board = _boardOfPlayer2;
            else
                board = _boardOfPlayer1;

            board.Attack(location);

            List<IShip> ships = _shipsOfPlayer1;
            if (attacker == Player1)
                ships = _shipsOfPlayer2;
            else
                ships = _shipsOfPlayer1;

            foreach (var ship in ships)
            {
                if (ship.Attack(location))
                {
                    Log.Logger.Write(LogLevel.Info, $"Player {attacker.ID}: attacked {ship.ShipType} at ({location.Row}, {location.Col}).");
                    return true;
                }
            }

            return false;
        }

        public bool AreAllShipsDamaged(IPlayer player)
        {
            var ships = _shipByPlayer[player];

            foreach (var ship in ships)
            {
                if (!ship.IsShipDamaged())
                    return false;
            }

            Log.Logger.Write(LogLevel.Info, $"Player {player.ID}: all ships are damaged, lost the game.");
            return true;
        }

        public bool IsGameReady()
        {
            return _shipsOfPlayer1.Count == _battleshipConfig.ShipSizeByType.Count && _shipsOfPlayer2.Count == _battleshipConfig.ShipSizeByType.Count;
        }

        public bool IsShipDamaged(IPlayer player, ShipType shipType)
        {
            var ships = _shipByPlayer[player];
            foreach (var ship in ships)
            {
                if (ship.ShipType != shipType)
                    continue;

                return ship.IsShipDamaged();
            }

            return false;
        }
    }
}


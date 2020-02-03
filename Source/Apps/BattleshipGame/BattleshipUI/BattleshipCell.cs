using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleship.BattleshipModel;
using Battleship.BattleshipControl;

namespace Battleship.BattleshipUI
{
    public partial class BattleshipCell : UserControl
    {
        private ICell _cell;
        private IPlayer _player;

        public BattleshipCell()
        {
            InitializeComponent();
        }

        public void Initialize(IPlayer player, ICell cell)
        {
            _cell = cell;
            _player = player;

            cell.Attacked += Cell_Attacked;

            BattleshipController.Instance.ActiveShipTypeChanged += ActiveShipTypeChanged;
            BattleshipController.Instance.ActiveShipLayoutChanged += ActiveShipLayoutChanged;
            BattleshipController.Instance.GameReset += GameReset;
        }

        private void GameReset(object sender, EventArgs e)
        {
            RefreshAvailablility(_player);
        }

        private void ActiveShipLayoutChanged(object sender, EventArgs e)
        {
            var player = sender as IPlayer;
            RefreshAvailablility(player);
        }

        private void ActiveShipTypeChanged(object sender, EventArgs e)
        {
            var player = sender as IPlayer;
            RefreshAvailablility(player);
        }

        private void Cell_Attacked(object sender, EventArgs e)
        {
            if (BattleshipController.Instance.GetShip(_player, _cell.Location) != null)
                BackgroundImage = Properties.Resources.battleship_player_ship_cell_attacked;
            else
                BackgroundImage = Properties.Resources.battleship_cell_missed;
        }

        private void BattleshipCell_Click(object sender, EventArgs e)
        {
            // prevent user click on their own cells
            if (BattleshipController.Instance.GameMode == GameMode.Battle)
                return;

            BattleshipController.Instance.PlaceShip(_player, _cell.Location);
        }

        private void RefreshAvailablility(IPlayer player)
        {
            if (player != _player)
                return;

            var shipType = (player == BattleshipController.Instance.Player1 ?
                BattleshipController.Instance.ActiveShipTypeOfPlayer1 : BattleshipController.Instance.ActiveShipTypeOfPlayer2);

            IShip ship = BattleshipController.Instance.GetShip(player, _cell.Location);
            // Clear selection
            if (shipType == ShipType.Unknown)
            {
                if (ship == null)
                    BackgroundImage = Properties.Resources.battleship_cell_bg;
                else
                    BackgroundImage = Properties.Resources.battleship_ship_cell_bg;

                return;
            }

            if (ship != null)
            {
                if (ship.ShipType != shipType)
                {
                    BackgroundImage = Properties.Resources.assign_ship_not_available;
                    return;
                }
            }

            if (BattleshipController.Instance.TryPlaceShip(player, _cell.Location, shipType))
            {
                BackgroundImage = Properties.Resources.assign_ship_available;
            }
            else
            {
                BackgroundImage = Properties.Resources.assign_ship_not_available;
            }
        }
    }
}

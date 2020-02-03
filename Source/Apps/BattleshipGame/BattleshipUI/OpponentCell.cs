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
    public partial class OpponentCell : UserControl
    {
        private ICell _cell;
        private IPlayer _player;

        public OpponentCell()
        {
            InitializeComponent();
        }

        public void Initialize(IPlayer player, ICell cell)
        {
            _cell = cell;
            _player = player;

            cell.Attacked += Cell_Attacked;
            BattleshipController.Instance.GameReset += GameReset;
        }

        private void GameReset(object sender, EventArgs e)
        {
            RefreshAvailablility();
        }

        private void Cell_Attacked(object sender, EventArgs e)
        {
            RefreshAvailablility();
        }

        private void OpponentCell_Click(object sender, EventArgs e)
        {
            if (BattleshipController.Instance.GameMode == GameMode.Setup)
                return;

            if (_cell.IsDamaged)
                return;

            // the _player here is the opponent, so we switch attack player here
            IPlayer attacker = BattleshipController.Instance.GetOpponent(_player);;

            BattleshipController.Instance.Attack(attacker, _cell.Location);
        }

        private void RefreshAvailablility()
        {
            if (_cell.IsDamaged)
            {
                IShip ship = BattleshipController.Instance.GetShip(_player, _cell.Location);

                if (ship != null)
                    BackgroundImage = Properties.Resources.battleship_ship_cell_attacked;
                else
                    BackgroundImage = Properties.Resources.battleship_cell_missed;
            }
            else
            {
                BackgroundImage = Properties.Resources.battleship_cell_bg;
            }
        }
    }
}

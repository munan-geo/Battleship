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
    public enum PlayerInControl
    {
        Player1InControl,
        Player2InControl
    }

    public partial class BattleshipGameUserControl : UserControl
    {
        private IPlayer _player;

        public BattleshipGameUserControl()
        {
            InitializeComponent();
        }

        public void Initialize(PlayerInControl playerInControl)
        {
            IPlayer player1 = BattleshipController.Instance.Player1;
            IPlayer player2 = BattleshipController.Instance.Player2;

            if(playerInControl == PlayerInControl.Player1InControl)
            {
                battleshipBoard.Initialize(player1);
                opponentBoard.Initialize(player2);

                _player = player1;
                labelPlayer.Text = "Houston";
                labelOpponent.Text = "Las Vegas";
                pictureBoxPlayer.BackgroundImage = Properties.Resources.hou_logo;
                pictureBoxOpponent.BackgroundImage = Properties.Resources.lv_logo;
            }
            else
            {
                battleshipBoard.Initialize(player2);
                opponentBoard.Initialize(player1);

                _player = player2;
                labelOpponent.Text = "Houston";
                labelPlayer.Text = "Las Vegas";
                pictureBoxPlayer.BackgroundImage = Properties.Resources.lv_logo;
                pictureBoxOpponent.BackgroundImage = Properties.Resources.hou_logo;
            }

            foreach (var control in this.Controls)
            {
                if (control is AvaialbleShip)
                {
                    (control as AvaialbleShip).Initialize(_player);
                }
            }

            BattleshipController.Instance.GameOver += GameOver;
            BattleshipController.Instance.GameReset += GameReset;
        }

        private void GameReset(object sender, EventArgs e)
        {
            labelLost.Visible = false;
        }

        private void GameOver(object sender, EventArgs e)
        {
            var player = sender as IPlayer;
            if (player == _player)
                labelLost.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShipLayout shipLayout = checkBox1.Checked ? ShipLayout.Horizontal : ShipLayout.Vertical;
               
            if(_player == BattleshipController.Instance.Player1)
                BattleshipController.Instance.ShipLayoutOfPlayer1 = shipLayout;
            else
                BattleshipController.Instance.ShipLayoutOfPlayer2 = shipLayout;
        }
    }
}

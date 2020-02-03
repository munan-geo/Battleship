using Battleship.BattleshipControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.BattleshipUI
{
    public partial class BattleshipForm : Form
    {
        public BattleshipForm()
        {
            InitializeComponent();

            Initialize();
        }

        public void Initialize()
        {
            battleshipGameUserControl1.Initialize(PlayerInControl.Player1InControl);
            battleshipGameUserControl2.Initialize(PlayerInControl.Player2InControl);

            BattleshipController.Instance.GameReady += GameReady;
        }

        private void GameReady(object sender, EventArgs e)
        {
            buttonFireBattle.Enabled = true;
            buttonFireBattle.BackgroundImage = Properties.Resources.fire_the_battle;
        }

        private void buttonFireBattle_Click(object sender, EventArgs e)
        {
            BattleshipController.Instance.StartBattle();

            labelAssignShip.Visible = false;
            buttonFireBattle.Enabled = false;
            buttonFireBattle.BackgroundImage = Properties.Resources.fire_the_battle_disabled;
        }

        private void buttonResetBattle_Click(object sender, EventArgs e)
        {
            labelAssignShip.Visible = true;
            BattleshipController.Instance.ResetGame();
        }
    }
}

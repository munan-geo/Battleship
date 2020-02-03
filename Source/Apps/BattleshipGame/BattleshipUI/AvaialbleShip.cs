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
    public partial class AvaialbleShip : UserControl
    {
        private IPlayer _player;

        public AvaialbleShip()
        {
            InitializeComponent();

            _player = null;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public ShipType ShipType
        {
            get; set;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string ShipName
        {
            get
            {
                return this.labelShipName.Text;
            }
            set
            {
                this.labelShipName.Text = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int ShipLength
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
                labelShipName.MinimumSize = new System.Drawing.Size(this.Width, labelShipName.Height);
            }
        }

        public void Initialize(IPlayer player)
        {
            _player = player;
            BattleshipController.Instance.ActiveShipTypeChanged += ActiveShipTypeChanged;
            BattleshipController.Instance.GameReset += GameReset;
        }

        private void GameReset(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void ActiveShipTypeChanged(object sender, EventArgs e)
        {
            IPlayer player = sender as IPlayer;
            if (player != _player)
                return;

            RefreshUI();
        }

        private void AvaialbleShip_Click(object sender, EventArgs e)
        {
            if (BattleshipController.Instance.GameMode != GameMode.Setup)
                return;

            if (!BattleshipController.Instance.IsShipAvailable(_player, ShipType))
                return;

            var shipType = (_player == BattleshipController.Instance.Player1 ?
                BattleshipController.Instance.ActiveShipTypeOfPlayer1 : BattleshipController.Instance.ActiveShipTypeOfPlayer2);

            if (shipType != ShipType)
            {
                if (_player == BattleshipController.Instance.Player1)
                    BattleshipController.Instance.ActiveShipTypeOfPlayer1 = ShipType;
                else
                    BattleshipController.Instance.ActiveShipTypeOfPlayer2 = ShipType;
            }
        }

        private void RefreshUI()
        {
            var shipType = (_player == BattleshipController.Instance.Player1 ?
                BattleshipController.Instance.ActiveShipTypeOfPlayer1 : BattleshipController.Instance.ActiveShipTypeOfPlayer2);

            if (shipType != ShipType)
            {
                if (BattleshipController.Instance.IsShipAvailable(_player, ShipType))
                {
                    this.BackColor = Color.Khaki;
                    this.ForeColor = Color.Black;
                }
                else // Ship is ready assigned
                {
                    this.BackColor = Color.DarkGray;
                    this.ForeColor = Color.White;
                }
            }
            else
            {
                this.BackColor = Color.DeepSkyBlue;
                this.ForeColor = Color.White;
            }
        }

    }
}
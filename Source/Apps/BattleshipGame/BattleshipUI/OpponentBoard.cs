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
    public partial class OpponentBoard : UserControl
    {
        public OpponentBoard()
        {
            InitializeComponent();
        }

        public void Initialize(IPlayer player)
        {
            CreateCells(player);
        }

        private void CreateCells(IPlayer player)
        {
            for(int row = 0; row < 10; ++row)
            {
                for(int col = 0; col < 10; ++col)
                {
                    var cellUI = new OpponentCell();
                    cellUI.Location = new System.Drawing.Point(0, 0);
                    cellUI.Margin = new System.Windows.Forms.Padding(0);
                    cellUI.Dock = DockStyle.Fill;

                    tableLayoutPanel1.Controls.Add(cellUI);

                    ICell cell = BattleshipController.Instance.GetCell(player, new Location(row, col));
                    cellUI.Initialize(player, cell);
                }
            }
        }
    }
}

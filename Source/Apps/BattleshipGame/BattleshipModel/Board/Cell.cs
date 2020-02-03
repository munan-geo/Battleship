using Battleship.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class Cell : ICell
    {
        public event EventHandler Attacked;

        public Location Location { get; set; }
        public bool HasShip { get; set; }
        public bool IsDamaged { get; set; }
        public int Owner { get; set; }

        public Cell(int row, int col)
        {
            Location = new Location(row, col);
            IsDamaged = false;
        }

        public bool IsAttackable()
        {
            return IsDamaged;
        }

        public bool Attack()
        {
            if (IsDamaged)
            {
                Log.Logger.Write(LogLevel.Warn, $"Player {Owner}: Board: shouldn't reach here");
                return false;
            }
            else
            {
                Log.Logger.Write(LogLevel.Info, $"Player {Owner}: Board: the opponent attacked an empty square");
                IsDamaged = true;
            }

            if (Attacked != null)
                Attacked(this, null);

            return true;
        }
    }
}

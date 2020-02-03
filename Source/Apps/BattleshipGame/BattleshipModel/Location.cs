using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class Location
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Location(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool Equals(Location location)
        {
            return location.Row == Row && location.Col == Col;
        }
    }
}

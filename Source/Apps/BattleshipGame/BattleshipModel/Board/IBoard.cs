using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public interface IBoard
    {
        int Owner { get; set; }
        ICell GetCell(Location location);
        bool TryPlaceShip(Location location, ShipType shipType, ShipLayout layout);
        bool Attack(Location location);
        void Reset();
    }
}

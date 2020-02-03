using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    /// <summary>
    /// Explicitly specify the number assign to ship, so that if we add new type of ship in the future,
    /// the ship type change unexpectedly
    /// </summary>
    public enum ShipType
    {
        Unknown = 0,
        Carrier = 1,
        Battleship = 2,
        Submarine = 3,
        Cruiser = 4,
        Patrol = 5
    }

    public enum ShipLayout
    {
        Horizontal,
        Vertical
    }

    public interface IShip
    {
        ShipType ShipType { get; set; }
        ShipLayout ShipLayout { get; set; }
        Location Location { get; set; }
        List<ICell> Cells { get; set; }
        Size Size { get; set; }
        int Owner { get; set; }

        bool IsShipDamaged();
        bool IsAttackable(Location location);
        bool Attack(Location location);
        bool HasLocation(Location location);
    }
}


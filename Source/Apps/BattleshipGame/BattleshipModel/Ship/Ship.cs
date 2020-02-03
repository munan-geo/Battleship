using Battleship.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{

    public class Ship : IShip
    {
        public ShipLayout ShipLayout { get; set; }
        public ShipType ShipType { get;  set; }
        public Location Location { get; set; }
        public Size Size { get; set; }
        public List<ICell> Cells { get; set; }
        public int Owner { get; set; }

        public Ship()
        {
            ShipType = ShipType.Unknown;
            Location = new Location(0, 0);
            Cells = new List<ICell>();
            Size = new Size(1, 1);
        }

        public bool IsShipDamaged()
        {
            foreach(var cell in Cells)
            {
                if (cell.IsDamaged == false)
                    return false;
            }

            return true;
        }

        public bool IsAttackable(Location location)
        {
            foreach (var cell in Cells)
            {
                if (!cell.Location.Equals(location))
                    continue;

                if (cell.IsDamaged == false)
                    return true;
            }

            return false;
        }


        public bool Attack(Location location)
        {
            foreach (var cell in Cells)
            {
                if (cell.Location.Equals(location))
                {
                    cell.IsDamaged = true;
                    Log.Logger.Write(LogLevel.Info, $"Player {Owner}: {ShipType}: the opponent attacked at location {location}");
                    return true;
                }
            }

            return false;
        }

        public bool HasLocation(Location location)
        {
            foreach (var cell in Cells)
            {
                if (cell.Location.Equals(location))
                    return true;
            }

            return false;
        }
    }
}

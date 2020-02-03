using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class ShipFactory
    {
        public static IShip CreateShip(IBoard board, Location location, ShipType shipType, 
            ShipLayout shipLayout, Dictionary<ShipType, Size> shipSizeByType)
        {
            var ship = new Ship();
            ship.Location = location;
            ship.ShipLayout = shipLayout;
            ship.ShipType = shipType;
            ship.Size = new Size(shipSizeByType[shipType].Width, shipSizeByType[shipType].Height);
            ship.Cells = CreateShipCells(board, location, shipLayout, ship.Size);

            return ship;
        }

        private static List<ICell> CreateShipCells(IBoard board, Location location, ShipLayout layout, Size size)
        {
            var cells = new List<ICell>();

            int rowMultiplier = (layout == ShipLayout.Horizontal ? 0 : 1);
            int colMultiplier = (layout == ShipLayout.Vertical ? 0 : 1);

            for (int i = 0; i < size.Height; ++i)
            {
                Location loc = new Location(location.Row + rowMultiplier * i, location.Col + colMultiplier * i); 
                cells.Add(board.GetCell(loc));
            }

            return cells;
        }
    }
}

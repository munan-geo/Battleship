using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.BattleshipModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipGameTest
{
    [TestClass]
    public class Ship_UnitTest
    {
        private List<(ShipType shipType, int length)> _shipFacts = new List<(ShipType shipType, int length)>()
        {
            (ShipType.Carrier, 5),
            (ShipType.Battleship, 4),
            (ShipType.Submarine, 3),
            (ShipType.Cruiser,2),
            (ShipType.Patrol, 1)
        };

        [TestMethod]
        public void TestShipCreation()
        {
            Dictionary<ShipType, Size> shipSizeByType = CreateShipBySize();

            var board = CreateBattleshipConfig();

            foreach ((ShipType shipType, int length) shipFact in _shipFacts)
            {
                IShip ship = ShipFactory.CreateShip(board, new Location(0, 0), shipFact.shipType, ShipLayout.Horizontal, shipSizeByType);
                Assert.IsTrue(ship.ShipType == shipFact.shipType);
                Assert.IsTrue(ship.Size.Height == shipFact.length);
                Assert.IsTrue(ship.Cells.Count == shipFact.length);
                Assert.IsTrue(ship.Cells.Last().Location.Row == 0);
                Assert.IsTrue(ship.Cells.Last().Location.Col == shipFact.length - 1);
                Assert.IsTrue(ship.IsShipDamaged() == false);
            }
        }

        [TestMethod]
        public void TestAttackShip()
        {
            var shipBySize = CreateShipBySize();
            var board = CreateBattleshipConfig();
            IShip ship = ShipFactory.CreateShip(board, new Location(0, 0), ShipType.Battleship, ShipLayout.Horizontal, shipBySize);
            Assert.IsTrue(ship.Attack(new Location(0, 1)));
            Assert.IsFalse(ship.Attack(new Location(1, 0)));
            Assert.IsFalse(ship.IsShipDamaged());

            Assert.IsTrue(ship.Attack(new Location(0, 2)));
            Assert.IsTrue(ship.Attack(new Location(0, 3)));
            Assert.IsTrue(ship.Attack(new Location(0, 0)));
            Assert.IsTrue(ship.IsShipDamaged());
        }

        private Dictionary<ShipType, Size> CreateShipBySize()
        {
            var shipSizeByType = new Dictionary<ShipType, Size>();
            shipSizeByType[ShipType.Carrier] = new Size(1, 5);
            shipSizeByType[ShipType.Battleship] = new Size(1, 4);
            shipSizeByType[ShipType.Submarine] = new Size(1, 3);
            shipSizeByType[ShipType.Cruiser] = new Size(1, 2);
            shipSizeByType[ShipType.Patrol] = new Size(1, 1);

            return shipSizeByType;
        }

        private IBoard CreateBattleshipConfig()
        {
            BattleshipConfig battleshipConfig = new BattleshipConfig();
            var shipSizeByType = new Dictionary<ShipType, Size>();
            shipSizeByType[ShipType.Carrier] = new Size(1, 5);
            shipSizeByType[ShipType.Battleship] = new Size(1, 4);
            shipSizeByType[ShipType.Submarine] = new Size(1, 3);
            shipSizeByType[ShipType.Cruiser] = new Size(1, 2);
            shipSizeByType[ShipType.Patrol] = new Size(1, 1);
            battleshipConfig.ShipSizeByType = shipSizeByType;

            return new Board(10, battleshipConfig);
        }
    }
}
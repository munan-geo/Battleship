using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.BattleshipModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipGameTest
{
    [TestClass]
    public class Board_UnitTest
    {
        [TestMethod]
        public void TestShipPlacement()
        {
            var board = CreateBattleshipConfig();
            Assert.IsTrue(board.TryPlaceShip(new Location(0, 0), ShipType.Battleship, ShipLayout.Horizontal));            
            Assert.IsTrue(board.TryPlaceShip(new Location(0, 7), ShipType.Submarine, ShipLayout.Horizontal));
            Assert.IsFalse(board.TryPlaceShip(new Location(0, 7), ShipType.Carrier, ShipLayout.Horizontal));

            Assert.IsTrue(board.TryPlaceShip(new Location(0, 0), ShipType.Battleship, ShipLayout.Vertical));
            Assert.IsTrue(board.TryPlaceShip(new Location(6, 0), ShipType.Submarine, ShipLayout.Vertical));
            Assert.IsFalse(board.TryPlaceShip(new Location(7, 0), ShipType.Carrier, ShipLayout.Vertical));
        }

        [TestMethod]
        public void TestAttackMiss()
        {
            var board = CreateBattleshipConfig();

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    var loc = new Location(i, j);
                    Assert.IsTrue(board.Attack(loc));
                }
            }

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    var loc = new Location(i, j);
                    Assert.IsFalse(board.Attack(loc));
                }
            }
        }

        private Board CreateBattleshipConfig()
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
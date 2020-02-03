using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.BattleshipModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipGameTest
{
    [TestClass]
    public class Manager_UnitTest
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
        public void TestShipPlacement()
        {
            BattleshipManager battleshipManager = new BattleshipManager();
            battleshipManager.Initialize();

            Assert.IsTrue(battleshipManager.IsShipAvailable(battleshipManager.Player1, ShipType.Patrol));
            Assert.IsTrue(battleshipManager.TryPlaceShip(battleshipManager.Player1, new Location(0, 0), ShipType.Patrol, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.TryPlaceShip(battleshipManager.Player1, new Location(0, 6), ShipType.Patrol, ShipLayout.Horizontal));
            Assert.IsFalse(battleshipManager.TryPlaceShip(battleshipManager.Player1, new Location(0, 6), ShipType.Carrier, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(0, 0), ShipType.Patrol, ShipLayout.Horizontal));

            Assert.IsFalse(battleshipManager.IsShipAvailable(battleshipManager.Player1, ShipType.Patrol));

            Assert.IsNotNull(battleshipManager.GetShip(battleshipManager.Player1, new Location(0, 0)));
        }

        [TestMethod]
        public void TestAttackShip()
        {
            BattleshipManager battleshipManager = new BattleshipManager();
            battleshipManager.Initialize();
            
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(0, 0), ShipType.Patrol, ShipLayout.Horizontal));
            Assert.IsFalse(battleshipManager.IsShipDamaged(battleshipManager.Player1, ShipType.Patrol));
            Assert.IsFalse(battleshipManager.Attack(battleshipManager.Player2, new Location(0, 1)));
            Assert.IsFalse(battleshipManager.AreAllShipsDamaged(battleshipManager.Player1));

            Assert.IsTrue(battleshipManager.Attack(battleshipManager.Player2, new Location(0, 0)));
            Assert.IsTrue(battleshipManager.IsShipDamaged(battleshipManager.Player1, ShipType.Patrol));
            Assert.IsTrue(battleshipManager.AreAllShipsDamaged(battleshipManager.Player1));
        }

        [TestMethod]
        public void TestGameStatus()
        {
            BattleshipManager battleshipManager = new BattleshipManager();
            battleshipManager.Initialize();

            Assert.IsFalse(battleshipManager.IsGameReady());

            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(0, 0), ShipType.Patrol, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(1, 0), ShipType.Carrier, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(2, 0), ShipType.Battleship, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(3, 0), ShipType.Cruiser, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player1, new Location(4, 0), ShipType.Submarine, ShipLayout.Horizontal));

            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player2, new Location(0, 0), ShipType.Patrol, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player2, new Location(1, 0), ShipType.Carrier, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player2, new Location(2, 0), ShipType.Battleship, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player2, new Location(3, 0), ShipType.Cruiser, ShipLayout.Horizontal));
            Assert.IsTrue(battleshipManager.PlaceShip(battleshipManager.Player2, new Location(4, 0), ShipType.Submarine, ShipLayout.Horizontal));

            Assert.IsTrue(battleshipManager.IsGameReady());

            battleshipManager.Reset();
            Assert.IsFalse(battleshipManager.IsGameReady());
        }
    }
}
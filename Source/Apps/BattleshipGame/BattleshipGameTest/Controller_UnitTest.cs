using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.BattleshipControl;
using Battleship.BattleshipModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipGameTest
{
    [TestClass]
    public class Controller_UnitTest
    {
        [TestMethod]
        public void TestOpponent()
        {
            IPlayer player = BattleshipController.Instance.Player1;
            IPlayer opponent = BattleshipController.Instance.GetOpponent(player);
            Assert.AreEqual(opponent, BattleshipController.Instance.Player2);
        }

        [TestMethod]
        public void TestPlaceShip()
        {
            BattleshipController.Instance.Initialize();
            IPlayer player = BattleshipController.Instance.Player1;

            Assert.IsTrue(BattleshipController.Instance.IsShipAvailable(player, ShipType.Carrier));

            BattleshipController.Instance.ActiveShipTypeOfPlayer1 = ShipType.Carrier;
            Assert.IsTrue(BattleshipController.Instance.PlaceShip(player, new Location(0, 0)));

            Assert.IsFalse(BattleshipController.Instance.IsShipAvailable(player, ShipType.Carrier));

            var cell = BattleshipController.Instance.GetCell(player, new Location(0, 0));
            Assert.IsTrue(cell.IsDamaged == false);
        }

        [TestMethod]
        public void TestShipLayout()
        {
            BattleshipController.Instance.Initialize();
            IPlayer player = BattleshipController.Instance.Player1;
            BattleshipController.Instance.ShipLayoutOfPlayer1 = ShipLayout.Horizontal;
            Assert.AreEqual(BattleshipController.Instance.ShipLayoutOfPlayer1, ShipLayout.Horizontal);

            player = BattleshipController.Instance.Player2;
            BattleshipController.Instance.ShipLayoutOfPlayer2 = ShipLayout.Vertical;
            Assert.AreEqual(BattleshipController.Instance.ShipLayoutOfPlayer2, ShipLayout.Vertical);
        }

        [TestMethod]
        public void TestGameLifeCycle()
        {
            BattleshipController.Instance.Initialize();
            BattleshipController.Instance.StartBattle();
            Assert.IsTrue(BattleshipController.Instance.GameMode == GameMode.Battle);

            BattleshipController.Instance.ResetGame();

            Assert.IsTrue(BattleshipController.Instance.PreviousPlayer == null);
            Assert.IsTrue(BattleshipController.Instance.GameMode == GameMode.Setup);
        }

        [TestMethod]
        public void TestAttack()
        {
            BattleshipController.Instance.Initialize();
            IPlayer player = BattleshipController.Instance.Player1;
            BattleshipController.Instance.ActiveShipTypeOfPlayer1 = ShipType.Patrol;
            Assert.IsTrue(BattleshipController.Instance.PlaceShip(player, new Location(0, 0)));

            player = BattleshipController.Instance.Player2;
            BattleshipController.Instance.ActiveShipTypeOfPlayer2 = ShipType.Patrol;
            Assert.IsTrue(BattleshipController.Instance.PlaceShip(player, new Location(0, 0)));

            BattleshipController.Instance.Attack(player, new Location(0, 0));

            Assert.IsTrue(BattleshipController.Instance.IsGameOver());
        }
    }
}
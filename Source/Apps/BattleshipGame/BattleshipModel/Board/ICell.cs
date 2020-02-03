using System;

namespace Battleship.BattleshipModel
{
    public enum CellStatus
    {
        Empty = 1,
        Ship = 2,
        Missile = 3,
    }

    public interface ICell
    {
        event EventHandler Attacked;

        int Owner { get; set; }
        Location Location { get; set; }
        bool HasShip { get; set; }
        bool IsDamaged { get; set; }
        bool IsAttackable();
    }
}
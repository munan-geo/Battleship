using Battleship.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class Board : IBoard
    {
        private int _owner;
        private Cell[,] _cells;
        private int _boardLength;
        private BattleshipConfig _battleshipConfig;

        public Board(int boardLength, BattleshipConfig battleshipConfig)
        {
            _boardLength = boardLength;
            _cells = new Cell[_boardLength, _boardLength];
            for (int i = 0; i < _boardLength; ++i)
            {
                for (int j = 0; j < _boardLength; ++j)
                {
                    _cells[i, j] = new Cell(i, j);
                }
            }

            _battleshipConfig = battleshipConfig;
            _owner = 0;
        }

        public int Owner 
        {
            get
            {
                return _owner;
            } 
            set
            {
                _owner = value;

                for (int i = 0; i < _boardLength; ++i)
                {
                    for (int j = 0; j < _boardLength; ++j)
                    {
                        _cells[i, j].Owner = _owner;
                    }
                }
            }
        }

        public void Reset()
        {
            Log.Logger.Write(LogLevel.Warn, $"Board: Reset all cells");
            for (int i = 0; i < _boardLength; ++i)
            {
                for (int j = 0; j < _boardLength; ++j)
                {
                    _cells[i, j].IsDamaged = false;
                }
            }
        }

        public ICell GetCell(Location location)
        {
            return _cells[location.Row, location.Col];
        }

        public bool TryPlaceShip(Location location, ShipType shipType, ShipLayout layout)
        {
            // if starting point out of boundary
            if (location.Row < 0 || location.Row >= _boardLength || location.Col < 0 || location.Col >= _boardLength)
                return false;

            int rowMultiplier = 1;
            int colMultiplier = 1;
            int shipHeight = _battleshipConfig.ShipSizeByType[shipType].Height;

            if (layout == ShipLayout.Horizontal)
            {
                // if edge point out of boundary
                if (shipHeight + location.Col - 1 >= _boardLength)
                    return false;

                rowMultiplier = 0;
            }
            else
            {
                if (shipHeight + location.Row - 1 >= _boardLength)
                    return false;

                colMultiplier = 0;
            }

            // if overlap with any previous ships
            for (int i = 0; i < shipHeight; ++i)
            {
                var newLoc = new Location(location.Row + i * rowMultiplier, location.Col + i * colMultiplier);
                if (_cells[newLoc.Row, newLoc.Col].HasShip)
                    return false;
            }

            return true;
        }

        public bool Attack(Location location)
        {
            int row = location.Row;
            int col = location.Col;

            var cell = _cells[row, col];
            return cell.Attack(); 
        }
    }
}

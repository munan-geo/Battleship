using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class BattleshipSetting<T>
    {
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
            }
        }
        private T _value = default(T);
    }

    public class BattleshipConfig
    {
        public BattleshipSetting<int> BoardSquare { get; set; }
        public Dictionary<ShipType, Size> ShipSizeByType { get; set; }

        public BattleshipConfig()
        {
            BoardSquare = new BattleshipSetting<int>();
            BoardSquare.Value = 10;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public interface IPlayer
    {
        int ID { get; set; }
        string Name { get; set; }
    }
}

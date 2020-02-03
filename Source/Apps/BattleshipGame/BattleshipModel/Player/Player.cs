using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BattleshipModel
{
    public class Player : IPlayer
    {
        public Player(int id)
        {
            ID = id;
        }

        public int ID { get; set; }

        /// <summary>
        /// User could change their name in the future
        /// </summary>
        public string Name { get; set; }
    }
}

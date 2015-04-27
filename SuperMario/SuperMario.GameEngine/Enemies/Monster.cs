using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.GameEngine.Enemies
{
    public class Monster
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Life { get; set; }

        public List<Monster> ListMonsters { get; set; }

        public bool LeftOrRight { get; set; }

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
            Life = true;
            LeftOrRight = true;
        }
    }
}

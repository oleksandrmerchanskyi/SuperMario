using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Bonuses
{
    public class SuperBonus
    {
        public int X { get; set; }

        public int Y { get; set; }

        public SuperBonus(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

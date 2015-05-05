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

        /*
         * Review GY: створення колекцій об'єктів класу в самому класі допустимо(патерн Composit - Gof),
         * але в даному випадку не виправдане.
         * Рекомендую перенести колекцію до класу, котрий інкапсулює логіку гри.
         */
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

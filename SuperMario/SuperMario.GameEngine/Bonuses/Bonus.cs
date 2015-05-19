using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Bonuses
{
    public class Bonus
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int CountOfBonuses { get; set; }

        public int BonusScore { get; set; }

        public bool CanDraw { get; set; }

        /*
         * Review GY: створення колекцій об'єктів класу в самому класі допустимо(патерн Composit - Gof),
         * але в даному випадку не виправдане.
         * Рекомендую перенести колекцію до класу, котрий інкапсулює логіку гри.
         */
        public List<Bonus> ListBonuses { get; set; }

        public Bonus(int x, int y)
        {
            X = x;
            Y = y;
            CountOfBonuses = 0;
            BonusScore = 0;
        }
        public void CheckScore(int x, int y, SuperBonus superBonus, char [,] gameGround)
        {
            foreach (var b in ListBonuses)
            {
                if (x == b.X && y == b.Y)
                {
                    ListBonuses.Remove(b);
                    BonusScore += 50;
                    gameGround[b.X - 1, b.Y - 1] = 'Z';
                    break;
                }
            }
            if (x == superBonus.X && y == superBonus.Y)
            {
               BonusScore += 200;
            }
        }

        public List<Bonus> GenerateBonus(char[,] gameGround)
        {      ListBonuses = new List<Bonus>();
            for (int i = 0; i < gameGround.GetLength(1); i++)
            {
                for (int j = 0; j < gameGround.GetLength(0); j++)
                {
                    if (gameGround[j, i] == 'B')
                    {
                        ListBonuses.Add(new Bonus(j+1, i+1));
                    }
                }
            }
            return ListBonuses;
        }
    }
}

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

        /*
         * Review GY: клас не містить достатньо інформації для реалізації даної функціональності (вся необхідна інформація передається в якості параметрів).
         * Рекомендую перемістити метод до класу, котрий інкапсулює логіку гри.
         * Цей метод можна замінити на метод для перевірки співпадіння координат Mario та конкретної кулі, координати кулі доступні через this.
         * public bool CheckScore(int x, int y)
         */
        public void CheckScore(Mario mario, List<Bonus> listBonuses, char [,] gameGround)
        {
            ListBonuses = listBonuses;
            foreach (var b in listBonuses)
            {
                if (mario.X == b.X && mario.Y == b.Y)
                {
                    ListBonuses.Remove(b);
                    BonusScore += 50;
                    gameGround[b.X - 1, b.Y - 1] = 'Z';
                    return;
                }
            }
        }

        public List<Bonus> GenerateBonus(Bonus bonus, char[,] gameGround)
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

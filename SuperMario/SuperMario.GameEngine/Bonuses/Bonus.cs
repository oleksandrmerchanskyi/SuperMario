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
        public void CheckScore(Mario mario, List<Bonus> listBonuses)
        {
            ListBonuses = listBonuses;
            for (int i = 0; i < ListBonuses.Count; i++)
            {
                if (mario.X == ListBonuses[i].X && mario.Y == ListBonuses[i].Y)
                {
                    ListBonuses.Remove(ListBonuses[i]);
                    BonusScore += 50;
                }
            }
        }

        public void GenerateBonus(Bonus bonus, char[,] gameGround)
        {      ListBonuses = new List<Bonus>();
            for (int i = 0; i < bonus.CountOfBonuses; i++)
            {
                ListBonuses.Add(new Bonus(bonus.X, bonus.Y));
                bonus.X += 2;
                if (gameGround[ListBonuses[i].X - 1, ListBonuses[i].Y - 1] != 'X')
                {
                    CanDraw = true;
                }
                else if (gameGround[ListBonuses[i].X - 1, ListBonuses[i].Y - 1] != 'Q')
                {
                    CanDraw = true;
                }
                else
                {
                    CanDraw = false;
                }
            }
        }
    }
}

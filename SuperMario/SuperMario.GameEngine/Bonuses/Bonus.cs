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

        public List<Bonus> ListBonuses { get; set; }

        public Bonus(int x, int y)
        {
            X = x;
            Y = y;
            CountOfBonuses = 0;
            BonusScore = 0;
        }
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
    }
}

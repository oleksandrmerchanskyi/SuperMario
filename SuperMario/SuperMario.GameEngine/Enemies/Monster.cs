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

        /*
         * Review GY: створення колекцій об'єктів класу в самому класі допустимо(патерн Composit - Gof),
         * але в даному випадку не виправдане.
         * Рекомендую перенести колекцію до класу, котрий інкапсулює логіку гри.
         */

        public List<Monster> ListMonsters { get; set; }

        public string CurrentDirection { get; set; }

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
            CurrentDirection = "Left";
        }

        public List<Monster> CreateMonsters()
        {
            ListMonsters = new List<Monster>();
            ListMonsters.Add(new Monster(42,3));
            ListMonsters.Add(new Monster(24, 6));
            ListMonsters.Add(new Monster(36, 12));
            ListMonsters.Add(new Monster(4, 14));
            ListMonsters.Add(new Monster(10, 17));
            ListMonsters.Add(new Monster(35, 19));
            ListMonsters.Add(new Monster(70, 20));
            ListMonsters.Add(new Monster(6, 22));
            return ListMonsters;
        }
        public void MonsterMoving(char[,] gameGround)
        {
            foreach (var monster in ListMonsters)
            {
                int possibleCoordinates = 0;
                string newDirection;
                if(monster.CurrentDirection == "Right")
                {
                  possibleCoordinates = monster.X;
                  newDirection = "Left";
                }
                else
                {
                  possibleCoordinates = monster.X - 2;
                  newDirection = "Right";
                }
                if (gameGround[possibleCoordinates, monster.Y - 1] == 'X')
                {
                    monster.CurrentDirection = newDirection;
                }
                else if (gameGround[possibleCoordinates, monster.Y - 1] == 'Q')
                {
                    monster.CurrentDirection = newDirection;
                }
                if(monster.CurrentDirection == "Right")
                {
                    monster.X +=1;
                }
                else
                {
                    monster.X -=1;
                }
            }
        }    
    }
}

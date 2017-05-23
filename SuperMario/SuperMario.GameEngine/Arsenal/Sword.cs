using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Arsenal
{
    public class Sword
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool UseButton { get; set; }
        public List<Sword> ListOfSwords { get; set; } 
        public bool IsRight{ get; set; }

        public Sword(int x, int y)
        {
            X = x;
            Y = y;
            UseButton = false;
        }
        public void CheckIsRight(Mario mario)
        {
            if (mario.IsRight)
            {
                IsRight = true;
            }
            else
            {
                IsRight = false;
            }
            ListOfSwords = new List<Sword>();
            ListOfSwords.Add(new Sword(mario.X, mario.Y));
            ListOfSwords.Add(new Sword(mario.X+1, mario.Y));
            ListOfSwords.Add(new Sword(mario.X + 2, mario.Y));
        }

        public void UseSword(Mario mario)
        {
            foreach (var sword in ListOfSwords)
            {
                if (UseButton)
                {
                    if(IsRight)
                    { 
                    sword.X += 1;
                    }
                    else
                    {
                        sword.X -= 3;
                    }
                }
            }
        }

        public void DeleteSword()
        {
            foreach (var sword in ListOfSwords)
            {
                if (!UseButton)
                {
                    ListOfSwords.Remove(sword);
                    return;
                }
            }
        }

        public void Collisions(Monster monster, Bonus bonus, char [,] gameGround)
        {
            if (ListOfSwords != null)
            {

                foreach (var sword in ListOfSwords)
                {
                    foreach (var monstr in monster.ListMonsters)
                    {
                        if ((sword.X == monstr.X && sword.Y == monstr.Y) 
                            || (sword.X + 1 == monstr.X && sword.Y == monstr.Y))
                        {
                            monster.ListMonsters.Remove(monstr);
                            bonus.BonusScore += 500;
                            return;
                        }
                        else if ((sword.X -3  == monstr.X && sword.Y == monstr.Y)
                            || (sword.X - 4 == monstr.X && sword.Y == monstr.Y))
                        {
                            monster.ListMonsters.Remove(monstr);
                            bonus.BonusScore += 500;
                            return;
                        }
                        
                    }
                }
                foreach (var sword in ListOfSwords)
                {
                    if(sword.X > 4 && sword.X < 76)
                    { 
                        if (gameGround[sword.X-1, sword.Y - 1] == 'X')
                        {
                            gameGround[sword.X + 1, sword.Y - 1] = ' ';
                        }
                        else if (gameGround[sword.X, sword.Y - 1] == 'X')
                        {
                            gameGround[sword.X, sword.Y - 1] = ' ';
                        }
                        else if (gameGround[sword.X - 4, sword.Y - 1] == 'X')
                        {
                            gameGround[sword.X - 4, sword.Y - 1] = ' ';
                        }
                        else if (gameGround[sword.X - 3, sword.Y - 1] == 'X')
                        {
                            gameGround[sword.X - 3, sword.Y - 1] = ' ';
                        }
                    }
                }
            }
        }
    }
}

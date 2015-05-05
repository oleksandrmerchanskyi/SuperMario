using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Shooting
{
    public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool ShotButton { get; set; }

        /*
         * Review GY: створення колекцій об'єктів класу в самому класі допустимо(патерн Composit - Gof),
         * але в даному випадку не виправдане.
         * Рекомендую перенести колекцію до класу, котрий інкапсулює логіку гри.
         */
        public List<Bullet> ListBullets { get; set; }

        public Bullet(int x, int y)
        {
            X = x;
            Y = y;
            /*
             * Review GY: допоміжна змінна listBullets є зайвою, в даному випадку варто відразу проініціалізувати властивість ListBullets
             * ListBullets = new List<Bullet>();
             */
            List<Bullet> listBullets = new List<Bullet>();
            ListBullets = listBullets;
        }

        /*
        * Review GY: метод приймає надлишкові параметри.
        * В даному випадку змінна bullet доступна через this, а з об'єкту mario тут використовується лише одне поле,
        * котре можна передати в якості параметра.
        * Я рекомендую змінити прототип методу на такий: public void BulletMoving(bool leftOrRight)
        */
        public void BulletMoving(Bullet bullet, Mario mario)
        {
            if (mario.LeftOrRight)
            {
                bullet.X += 1;
            }
            else
            {
                bullet.X -= 1;
            }
        }

        /*
         * Review GY: даний метод приймає надто багато параметрів.
         * Клас Bullet не має достатньо інформації для реалізації даної функціональності,
         * тому рекомендую перенести метод до класу, котрий містить параметри методу BulletCollisions в якості полів.
         * Також рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public void BulletCollisions(Mario mario, Bullet bullet, List<Bullet> listBullets, char[,] gameGround, List<Monster> listMonsters, MapGraound map)
        {
            if(bullet.X+2 < map.Width-1)
            { 
                if (gameGround[bullet.X + 1, bullet.Y - 1] == 'X')
                {
                    listBullets.Remove(bullet);
                    if (ShotButton == true)
                    {
                        mario.MarioShoot(mario, listBullets);
                    }
                }
            }
        }

        /*
         * Review GY: даний метод приймає надто багато параметрів.
         * Клас Bullet не має достатньо інформації для реалізації даної функціональності,
         * тому рекомендую перенести метод до класу, котрий містить параметри методу BulletCollisionsWithMonsters в якості полів.
         * Також рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public void BulletCollisionsWithMonsters(Mario mario, Bullet bullet, List<Bullet> listBullets, List<Monster> listMonsters)
        {
            for (int i = 0; i < listMonsters.Count; i++)
            {
                if (bullet.X + 1 == listMonsters[i].X && bullet.Y == listMonsters[i].Y)
                {
                    listMonsters.Remove(listMonsters[i]);
                    listBullets.Remove(bullet);
                    if (ShotButton == true)
                    {
                        mario.MarioShoot(mario, listBullets);
                    }
                }
            }
        }
    }
}

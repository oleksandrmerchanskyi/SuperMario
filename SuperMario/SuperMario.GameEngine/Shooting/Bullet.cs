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

        public List<Bullet> ListBullets { get; set; }

        public Bullet(int x, int y)
        {
            X = x;
            Y = y;
            List<Bullet> listBullets = new List<Bullet>();
            ListBullets = listBullets;
        }

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

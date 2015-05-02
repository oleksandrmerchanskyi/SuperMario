using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Сharacter;
using SuperMario.GameEngine.Shooting;

namespace SuperMario.GameEngine.MovementLogic
{
    /*
     * Review GY: на даний клас покладена надлишкова відповідальність.
     * Рекомендую залишити лише властивості, а решту функціональності перенести у класи, 
     * що володіють інформацією необхідною для їх реалізації.
     */
    public class Movement
    {
        public bool LeftButton { get; set; }

        public bool RightButton { get; set; }

        public bool UpButton { get; set; }

        public bool CanMove { get; set; }

        public Movement()
        {
            CanMove = false;
            UpButton = false;
            RightButton = false;
            LeftButton = false;
        }

        /*
         * Review GY: рекомендую перенести даний метод до класу Mario
         */
        public Mario MarioMoving(Mario mario)
        {
            if (LeftButton == true)
            {
                mario.X -= 1;
                LeftButton = false;
                return mario;
            }    
            else if (RightButton == true)
            {
                mario.X += 1;
                RightButton = false;
                return mario;
            }    
            else if (UpButton == true)
            {
                mario.Y -= 1;
                UpButton = false;
                return mario;
            }
            return mario;
        }

        /*
         * Review GY: рекомендую перенести даний метод до класу Mario
         */
        public Mario MoveDownAfterJump(Mario mario)
        {
            if (UpButton == false)
            {
                mario.Y += 1;
                UpButton = false;
                return mario;
            }
            return mario;
        }

        /*
         * Review GY: рекомендую перенести даний метод до класу, що інкапсулює логіку гри.
         */
        public void CheckMove(Monster monster, List<Monster> listMonsters, char[,] gameGround)
        {
            foreach (var monstr in listMonsters)
            {
                if (gameGround[monstr.X - 2, monstr.Y - 1] != 'X')
                {
                    monstr.LeftOrRight = true;
                }
                if (gameGround[monstr.X - 2, monstr.Y - 1] == 'X')
                {
                    monstr.LeftOrRight = false;
                }
            }
        }

        /*
         * Review GY: рекомендую перенести даний метод до класу, що інкапсулює логіку гри.
         */
        public void MonsterMoving(Monster monster, List<Monster> listMonsters, char[,] gameGround, Mario mario, Game game, List<Bullet> listBullets)
        {
            CheckMove(monster, listMonsters, gameGround);
            foreach (var monstr in listMonsters)
            {
                if (monstr.LeftOrRight == true)
                {
                    if (gameGround[monstr.X - 2, monstr.Y - 1] != 'X')
                    {
                        monstr.X -= 1;
                        
                    }
                    if (mario.X == monstr.X && mario.Y == monstr.Y)
                    {
                        mario.CheckLife(mario, listMonsters, game);
                    }

                }
                else if (monstr.LeftOrRight == false)
                {
                    if (gameGround[monstr.X + 1, monstr.Y - 1] != 'X')
                    {
                        monstr.X += 1;
                        mario.CheckLife(mario, listMonsters, game);
                    }
                }
            }
        }

        /*
         * Review GY: рекомендую перенести даний метод до класу, що інкапсулює логіку гри.
         */
        public void MonsterLife(Monster monster, List<Monster> listMonsters, List<Bullet> listBullets)
        {
            foreach (var monstr in listMonsters)
            {
                foreach (var bullet in listBullets)
                {
                    if (monstr.X == bullet.X + 1 && monstr.Y == bullet.Y)
                    {
                        /*
                         * Review GY: видалення елементів з колекції, по котрій проходить foreach може призвести до виключної ситуації
                         */
                        listMonsters.Remove(monstr);
                        return;
                    }
                }
            }
        }
    }
}

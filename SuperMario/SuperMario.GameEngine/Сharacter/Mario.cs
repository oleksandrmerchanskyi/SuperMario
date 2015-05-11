using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Shooting;

namespace SuperMario.GameEngine.Сharacter
{
    public class Mario
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool CanShot { get; set; }

        public bool LeftOrRight { get; set; }

        public bool Life { get; set; }

        public Mario(int x, int y)
        {
            X = x;
            Y = y;
            Life = true;
            CanShot = false;
            LeftOrRight = true; //right = true, left = false
        }

        /*
         * Review GY: об'єкт mario в межах класу Mario доступний через this, тому передавати його в якості параметру не потрібно.
         * Метод використовує лише координати superBonus, тому краще буде передати їх в якості параметрів.
         * Клас Mario не повинен відповідати за збільшення бонусів bonus.BonusScore += 200;
         * Дана опереція має проводитись ззовні та залежати від результату роботи MarioCanShot.
         * Орієнтовний прототип методу: public bool MarioCanShot(int x, int y)
         */
        public void MarioCanShot(Mario mario, SuperBonus superBonus,Bonus bonus)
        {
            if (mario.X == superBonus.X && mario.Y == superBonus.Y)
            {
                mario.CanShot = true;
                bonus.BonusScore += 200;
            }
        }

        /*
         * Review GY: рекомендую перенести цей метод до класу, що інкапсулює логіку гри.
         * Клас Mario не повинен змінювати об'єкти або ж колекції, котрі йому не належать.
         */
        public void MarioShoot(Mario mario, List<Bullet> listBullets)
        {
            listBullets.Add(new Bullet(mario.X+1, mario.Y)); 
        }

        /*
         * Review GY: рекомендую перенести цей метод до класу, що інкапсулює логіку гри.
         * Клас Mario не володіє достатньою інформацією для реалізації даної функціональності.
         * Рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public bool ObjectCollisions(Mario mario, char[,] gameGround, Movement movement, Game game)
        {
            if (movement.RightButton == true)
            {
                if (gameGround[mario.X, mario.Y - 1] == '[')
                {
                    movement.CanMove = false;
                    game.GameInProgress = false;
                    game.GameFinished = true;
                }
                if (gameGround[mario.X, mario.Y - 1] == 'X')
                {
                    movement.CanMove = false;
                }
                else if (gameGround[mario.X, mario.Y] == 'Q')
                {
                    movement.CanMove = false;
                }
                else
                {
                    movement.CanMove = true;
                }
            }
            else if (movement.LeftButton == true)
            {
                if (gameGround[mario.X - 2, mario.Y - 1] == 'X')
                {
                    movement.CanMove = false;
                }
                else if (gameGround[mario.X-2, mario.Y] == 'Q')
                {
                    movement.CanMove = false;
                }
                else
                {
                    movement.CanMove = true;
                }
            }
            else if (movement.UpButton == true)
            {
                if (gameGround[mario.X - 1, mario.Y - 2] == 'X')
                {
                    movement.CanMove = false;
                }
                else
                {
                    movement.CanMove = true;
                }
            }
            return movement.CanMove;
        }

        /*
         * Review GY: рекомендую перенести цей метод до класу, що інкапсулює логіку гри.
         * Клас Mario не володіє достатньою інформацією для реалізації даної функціональності.
         * Рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public int EarthUnderfoot(Mario mario, char[,] gameGround, Movement movement)
        {
            if (gameGround[mario.X, mario.Y] != 'X')
            {
                if (movement.RightButton == true)
                {
                    if (gameGround[mario.X, mario.Y] != 'X')
                    {
                        mario.X += 1;
                        while (gameGround[mario.X - 1, mario.Y] != 'X')
                        {
                            mario.Y++;
                        }
                        return mario.Y;
                    }
                }
            }
            if (gameGround[mario.X - 2, mario.Y] != 'X')
            {
                if (movement.LeftButton == true)
                {
                    if (gameGround[mario.X - 2, mario.Y] != 'Q')
                    {
                        if (gameGround[mario.X - 2, mario.Y] != 'X')
                        {
                            mario.X -= 1;
                            while (gameGround[mario.X - 2, mario.Y] != 'X')
                            {
                                mario.Y++;
                            }
                            return mario.Y;
                        }
                    }
                }
            }
            return mario.Y;
        }

        /*
         * Review GY: рекомендую перенести цей метод до класу, що інкапсулює логіку гри.
         * Клас Mario не володіє достатньою інформацією для реалізації даної функціональності.
         * Рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public bool CheckLife(Mario mario, List<Monster> listMonsters, Game game)
        {
            foreach (var monster in listMonsters)
            {
                if ((mario.X+1 == monster.X && mario.Y == monster.Y) || 
                    (mario.X == monster.X && mario.Y == monster.Y))
                {
                    mario.Life = false;
                    game.GameOver = true;
                    game.GameInProgress = false;
                    return game.GameOver;
                }
                else if (mario.X - 1 == monster.X && mario.Y == monster.Y)
                {
                    mario.Life = false;
                    game.GameOver = true;
                    game.GameInProgress = false;
                    return game.GameOver;
                }
            }
            return mario.Life;
        }
    }
}

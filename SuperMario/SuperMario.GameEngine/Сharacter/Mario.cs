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
using SuperMario.GameEngine.Arsenal;

namespace SuperMario.GameEngine.Сharacter
{
    public class Mario
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool CanShot { get; set; }

        public bool IsRight { get; set; }

        public bool IsAlive { get; set; }

        public Mario(int x, int y)
        {
            X = x;
            Y = y;
            IsAlive = true;
            CanShot = false;
            IsRight = true;
        }

        public void MarioCanShot(int x, int y, char [,] gameGround)
        {
            if (this.X == x && this.Y == y)
            {
                this.CanShot = true;
                
                gameGround[x-1, y-1] = 'Z';
            }
        }
        public Mario MoveDownAfterJump(Movement movement)
        {
            if (!movement.UpButton)
            {
                Y += 1;
                movement.UpButton = false;
            }
            return this;
        }
        public Mario MarioMoving(Movement movement)
        {
            if (movement.LeftButton)
            {
                X -= 1;
                movement.LeftButton = false;
            }
            else if (movement.RightButton)
            {
                X += 1;
                movement.RightButton = false;
            }
            else if (movement.UpButton)
            {
                Y -= 1;
                movement.UpButton = false;
            }
            return this;
        }
        /*
         * Review GY: рекомендую перенести цей метод до класу, що інкапсулює логіку гри.
         * Клас Mario не володіє достатньою інформацією для реалізації даної функціональності.
         * Рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public bool ObjectCollisions(char[,] gameGround, Movement movement, Game game)
        {
            if (movement.RightButton)
            {
                if (gameGround[X, Y - 1] == '[')
                {
                    movement.CanMove = false;
                    game.GameInProgress = false;
                    game.GameFinished = true;
                }
                if (gameGround[X, Y - 1] == 'X')
                {
                    movement.CanMove = false;
                }
                else if (gameGround[X, Y] == 'Q')
                {
                    movement.CanMove = false;
                }
                else
                {
                    movement.CanMove = true;
                }
            }
            else if (movement.LeftButton)
            {
                if (gameGround[X - 2,Y - 1] == 'X')
                {
                    movement.CanMove = false;
                }
                else if (gameGround[X-2, Y] == 'Q')
                {
                    movement.CanMove = false;
                }
                else
                {
                    movement.CanMove = true;
                }
            }
            else if (movement.UpButton)
            {
                if (gameGround[X - 1, Y - 2] == 'X')
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
        public int EarthUnderfoot(char[,] gameGround, Movement movement)
        {
            if (gameGround[X, Y] != 'X')
            {
                if (movement.RightButton)
                {
                    if (gameGround[X, Y] != 'X')
                    {
                        X += 1;
                        while (gameGround[X - 1, Y] != 'X')
                        {
                            Y++;
                        }
                    }
                }
            }
            if (gameGround[X - 2, Y] != 'X')
            {
                if (movement.LeftButton)
                {
                    if (gameGround[X - 2, Y] != 'Q')
                    {
                        if (gameGround[X - 2, Y] != 'X')
                        {
                            X -= 1;
                            while (gameGround[X - 2, Y] != 'X')
                            {
                                Y++;
                            }
                        }
                    }
                }
            }
            return Y;
        }

        /*
         * Review GY: рекомендую перенести цей метод до класу, що інкапсулює логіку гри.
         * Клас Mario не володіє достатньою інформацією для реалізації даної функціональності.
         * Рекомендую переглянути інформацію за посиланням - http://en.wikipedia.org/wiki/GRASP_(object-oriented_design)#Information_Expert
         */
        public bool CheckLife(List<Monster> listMonsters, Game game)
        {
            foreach (var monster in listMonsters)
            {
                if ((X+1 == monster.X && Y == monster.Y) || 
                    (X == monster.X + 1 && Y == monster.Y) || 
                    (X == monster.X && Y == monster.Y))
                {
                    IsAlive = false;
                    game.GameOver = true;
                    game.GameInProgress = false;
                    return game.GameOver;
                }
                else if (X - 1 == monster.X && Y == monster.Y)
                {
                    IsAlive = false;
                    game.GameOver = true;
                    game.GameInProgress = false;
                    return game.GameOver;
                }
            }
            return IsAlive;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using SuperMario.ConsoleUI.Map;
using SuperMario.GameEngine;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Arsenal;
using SuperMario.GameEngine.Сharacter;


namespace SuperMario.ConsoleUI.ConsoleMovement
{
    class MovementAtConsole
    {
        private ConsoleKeyInfo _keyInfo;
        private Movement _movement;
        private BackGroundDraw _backGroundDraw;

        /*
         * Review GY: метод приймає зайві параметри: Bullet bullet, List<Bullet> listBullets.
         */
        public void CheckButton(Mario mario, char[,] backGround, Bonus bonus, SuperBonus superBonus, Game game)
        {
            _movement = new Movement();
            _backGroundDraw = new BackGroundDraw();
            _keyInfo = Console.ReadKey(true);
            if(game.GameInProgress)
            {
                switch (_keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _movement.UpButton = true;
                        _movement.RightButton = false;
                        _movement.LeftButton = false;
                        break;
                    case ConsoleKey.RightArrow:
                         _movement.RightButton = true;
                        _movement.LeftButton = false;
                        _movement.UpButton = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        _movement.LeftButton = true;
                        _movement.RightButton = false;
                        _movement.UpButton = false;
                        break;
                    case ConsoleKey.Spacebar:
                        break;

                }
                _movement.CanMove = mario.ObjectCollisions(backGround, _movement, game);
                if (_movement.CanMove)
                {
                    switch (_keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            _movement.UpButton = true;
	                        _backGroundDraw.RemoveMario(mario);
	                        mario.MarioMoving(_movement);
	                        if (mario.CanShot == false)
	                        {
	                            mario.MarioCanShot(mario.X, mario.Y, backGround);
	                        }
                            bonus.CheckScore(mario.X, mario.Y, superBonus, backGround);
	                        _backGroundDraw.DrawMario(mario);
                            /*
                             * Review GY: була попередня домовленість про невикористання конструкції Thread.Sleep
                             */
                            Thread.Sleep(100);
	                        _backGroundDraw.RemoveMario(mario);
	                        mario.MoveDownAfterJump(_movement);
                            bonus.CheckScore(mario.X, mario.Y, superBonus, backGround);
	                        _backGroundDraw.DrawMario(mario);
                            _movement.UpButton = false;
                            break;


                        case ConsoleKey.RightArrow:
                            mario.IsRight = true;
                            _backGroundDraw.RemoveMario(mario);
                            bonus.CheckScore(mario.X, mario.Y, superBonus, backGround);
                            mario.MarioMoving(_movement);
                            _backGroundDraw.DrawMario(mario);
                            _movement.RightButton = false;
                            break;

                        case ConsoleKey.LeftArrow:
                            mario.IsRight = false;
                            _backGroundDraw.RemoveMario(mario);
                            mario.EarthUnderfoot(backGround, _movement);
                            mario.MarioMoving(_movement);
                            bonus.CheckScore(mario.X, mario.Y, superBonus, backGround);
                            _backGroundDraw.DrawMario(mario);
                            _movement.LeftButton = false;
                            break;
                    }
                }
            }
        }
    }
}

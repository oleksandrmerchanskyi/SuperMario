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
using SuperMario.GameEngine.Shooting;
using SuperMario.GameEngine.Сharacter;


namespace SuperMario.ConsoleUI.ConsoleMovement
{
    class MovementAtConsole
    {
        private ConsoleKeyInfo _keyInfo;
        private Movement _movement;
        private BackGroundDraw _backGroundDraw;
        public void CheckButton(Mario mario, char[,] backGround, Bonus bonus, SuperBonus superBonus, Game game, Bullet bullet, List<Bullet> listBullets)
        {
            _movement = new Movement();
            _backGroundDraw = new BackGroundDraw();
            _keyInfo = Console.ReadKey(true);
            if(game.GameInProgress == true)
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
                _movement.CanMove = mario.ObjectCollisions(mario, backGround, _movement, game);
                if (_movement.CanMove == true)
                {
                    switch (_keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            _movement.UpButton = true;
	                        _backGroundDraw.RemoveMario(mario);
	                        _movement.MarioMoving(mario);
	                        if (mario.CanShot == false)
	                        {
	                            mario.MarioCanShot(mario, superBonus, bonus);
	                        }
                            bonus.CheckScore(mario, bonus.ListBonuses);
	                        _backGroundDraw.DrawMario(mario);
                            Thread.Sleep(100);
	                        _backGroundDraw.RemoveMario(mario);
	                        _movement.MoveDownAfterJump(mario);
                            bonus.CheckScore(mario, bonus.ListBonuses);
	                        _backGroundDraw.DrawMario(mario);
                            _movement.UpButton = false;
                            break;


                        case ConsoleKey.RightArrow:
                            mario.LeftOrRight = true;
                            _backGroundDraw.RemoveMario(mario);
                            mario.EarthUnderfoot(mario, backGround, _movement);
                            _movement.MarioMoving(mario);
                            _backGroundDraw.DrawMario(mario);
                            _movement.RightButton = false;
                            break;

                        case ConsoleKey.LeftArrow:
                            mario.LeftOrRight = false;
                            _backGroundDraw.RemoveMario(mario);
                            mario.EarthUnderfoot(mario, backGround, _movement);
                            _movement.MarioMoving(mario);
                            bonus.CheckScore(mario, bonus.ListBonuses);
                            _backGroundDraw.DrawMario(mario);
                            _movement.LeftButton = false;
                            break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SuperMario.ConsoleUI.ConsoleMovement;
using SuperMario.GameEngine;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Сharacter;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Map;

namespace SuperMario.ConsoleUI.Map
{
    /*
     * Review GY: на даний клас покладена відповідальність за відображення об'єктів, тому він не повинен містити логіки по їх створенню.
     * Рекомендую винести всі об'єкти та колекції до класу, що інкапсулює логіку гри.
     */
    class BackGroundDraw
    {
        private Mario _mario;
        private Movement _movement;
        private char[,] _gameGround;
        private Bonus _bonus;
        private SuperBonus _superBonus;
        private MovementAtConsole _movementAtConsole;
        private MapGraound _map;
        private Game _game;
        private int _bonusCounter;

        public void GameStart()
        {
            _game = new Game();
            _bonus = new Bonus(1, 1);
            _movement = new Movement();
            ViewMap();
            MarioInit();
            
            _movementAtConsole = new MovementAtConsole();
            while (_game.GameInProgress)
            {
                _movementAtConsole.CheckButton(_mario, _gameGround, _bonus, _superBonus, _game);
            }
        }
        public void GameOver()
        {
            if (_game.GameOver)
            {
                Console.Clear();
                WindowBorder();
                Console.SetCursorPosition(30, 9);
                Console.Write("Game Over");
                Console.SetCursorPosition(30, 10);
                Console.Write("You lose");
                Console.SetCursorPosition(30, 11);
                Console.Write("Score: {0}", _bonus.BonusScore);
            }
        }

        public void GameFinished()
        {
            if (_game.GameFinished)
            {
                Console.Clear();
                WindowBorder();
                Console.SetCursorPosition(30, 9);
                Console.Write("Finished");
                Console.SetCursorPosition(30, 10);
                Console.Write("You Win");
                Console.SetCursorPosition(30, 11);
                Console.Write("Score: {0}", _bonus.BonusScore);
            }
        }

        public void ViewMap()
        {
            WindowBorder();
            MapInit();
            DrawMap();
        }

        public void MapInit()
        {
            _map = new MapGraound(77,23);
            _gameGround = _map.FillTheArray();
        }

        public void MarioInit()
        {
            _mario = new Mario(2,3);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(_mario.X, _mario.Y);
            Console.Write('O');
        }

        public void DrawMario(Mario mario)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(mario.X, mario.Y);
            Console.Write('O');
        }

        public void RemoveMario(Mario mario)
        {
            Console.SetCursorPosition(mario.X, mario.Y);
            Console.Write(' ');
        }

        public void DrawMap()
        {
            for (int i = 0; i < _gameGround.GetLength(1); i++)
            {
                for (int j = 0; j < _gameGround.GetLength(0); j++)
                {
                    Console.SetCursorPosition(j + 1, i + 1);

                    if (_gameGround[j, i] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (_gameGround[j, i] == '[')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if (_gameGround[j, i] == ']')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else if (_gameGround[j, i] == 'B')
                    {
                        _bonus.ListBonuses = new List<Bonus>();
                        _bonus.ListBonuses.Add(new Bonus(j,i));
                    }
                    else if (_gameGround[j, i] == 'B')
                    {
                        _bonus.ListBonuses = new List<Bonus>();
                        _bonus.ListBonuses.Add(new Bonus(j, i));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(_bonus.ListBonuses[_bonusCounter].X, _bonus.ListBonuses[_bonusCounter].Y);
                        Console.Write('$');
                        _bonusCounter++;
                    }
                    else if (_gameGround[j, i] == 'S')
                    {
                        _superBonus = new SuperBonus(j+1,i+1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(_superBonus.X, _superBonus.Y);
                        Console.Write('@');
                    }
                    Console.Write(_gameGround[j, i]);
                }
            }
        }

        public void WindowBorder()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 79; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, 24);
                Console.Write("#");
            }
            for (int j = 1; j < 25; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write("#");
                Console.SetCursorPosition(78, j);
                Console.Write("#");
            }
        }

    }
}

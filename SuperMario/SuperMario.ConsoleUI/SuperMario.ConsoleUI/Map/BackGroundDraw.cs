using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using SuperMario.ConsoleUI.ConsoleMovement;
using SuperMario.GameEngine;
using SuperMario.GameEngine.Interfaces;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Сharacter;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.Shooting;
using Timer = System.Timers.Timer;

namespace SuperMario.ConsoleUI.Map
{
    /*
     * Review GY: на даний клас покладена відповідальність за відображення об'єктів, тому він не повинен містити логіки по їх створенню.
     * Рекомендую винести всі об'єкти та колекції до класу, що інкапсулює логіку гри.
     */
    class BackGroundDraw : IDraw
    {
        private Mario _mario;
        private Movement _movement;
        //private Monster _monster;
        //private List<Monster> _listMonsters;
        private char[,] _gameGround;
        private Bonus _bonus;
        private SuperBonus _superBonus;
        private MovementAtConsole _movementAtConsole;
        private MapGraound _map;
        private Game _game;
        //private Timer _timerMonster;
        private Bullet _bullet;

        public void GameStart()
        {
            _game = new Game();
            _movement = new Movement();
            ViewMap();
            MarioInit();
            //TimersRun();
            _bullet = new Bullet(1,1);
            //_movement.CheckMove(_monster,_listMonsters, _gameGround);
            _movementAtConsole = new MovementAtConsole();
            while (_game.GameInProgress == true)
            {
                _movementAtConsole.CheckButton(_mario, _gameGround, _bonus, _superBonus, _game, _bullet, _bullet.ListBullets);
            }
        }

        //void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    RemoveMonster();
        //    _movement.MonsterMoving(_monster, _listMonsters, _gameGround, _mario, _game, _bullet.ListBullets);
        //    _movement.MonsterLife(_monster, _listMonsters, _bullet.ListBullets);
        //    DrawMonster();
        //}

        //public void TimersRun()
        //{
        //    _timerMonster = new Timer(500);
        //    _timerMonster.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        //    _timerMonster.Enabled = true;
        //    _timerMonster.Start();
        //}

        public void GameOver()
        {
            if (_game.GameOver == true)
            {
                //_timerMonster.Enabled = false;
                //_timerMonster.Stop();
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
            if (_game.GameFinished == true)
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
            FillTheArray();
            GenerateBonuses();
            //MonsterInit();
        }

        public void MapInit()
        {
            _map = new MapGraound(77,23);
            _gameGround = new char[_map.Width,_map.Height];
        }

        public void MarioInit()
        {
            _mario = new Mario(2,3);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(_mario.X, _mario.Y);
            Console.Write('O');
        }

        //public void MonsterInit()
        //{
        //    _monster = new Monster(39,3);
        //    _monster.ListMonsters = new List<Monster>();
        //    _monster.ListMonsters.Add(_monster);
        //    DrawMonster();
        //    _monster.ListMonsters.Add(new Monster(50,6));
        //    DrawMonster();
        //    _monster.ListMonsters.Add(new Monster(3, 8));
        //    DrawMonster();
        //    _monster.ListMonsters.Add(new Monster(35, 8));
        //    DrawMonster();
        //    _monster.ListMonsters.Add(new Monster(35, 12));
        //    DrawMonster();
        //    _monster.ListMonsters.Add(new Monster(35, 17));
        //    DrawMonster();
        //    _monster.ListMonsters.Add(new Monster(45, 17));
        //    DrawMonster();
        //    _listMonsters = _monster.ListMonsters;
        //}

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

        public void FillTheArray()
        {
            var resourceMap = Properties.Resources.Map;
            char[] mapArray = resourceMap.ToCharArray();
            int counter = 0;
            int z = 0;
            int countOfResize = 0;
            for (int i = 0; i < mapArray.Length; ++i)
            {
                if (mapArray[i].ToString().IndexOf('\r') != -1 || mapArray[i].ToString().IndexOf('\n') != -1)
                {
                    ++countOfResize;
                }
                else { mapArray[z] = mapArray[i]; z++; }
            }

            Array.Resize(ref mapArray, mapArray.Length - countOfResize);
            for (int i = 0; i < _gameGround.GetLength(1); i++)
            {
                for (int j = 0; j < _gameGround.GetLength(0); j++)
                {
                    Console.SetCursorPosition(j + 1, i + 1);
                    if (mapArray[counter] == 'Z')
                    {
                        _gameGround[j, i] += ' ';
                    }
                    else if(mapArray[counter] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        _gameGround[j, i] += mapArray[counter];
                    }
                    else if (mapArray[counter] == '[')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        _gameGround[j, i] += mapArray[counter];
                    }
                    else if (mapArray[counter] == ']')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        _gameGround[j, i] += mapArray[counter];
                    }
                    counter++;
                    Console.Write(_gameGround[j, i]);

                }

            }
        }

        /*
         * Review GY: присутній дубляж коду.
         */
        public void GenerateBonuses()
        {
            _superBonus = new SuperBonus(5,2);
            DrawSuperBonus();
            _bonus = new Bonus(2, 2) {CountOfBonuses = 30};
            List<Bonus> listBonuses = new List<Bonus>();
            for (int i = 0; i < _bonus.CountOfBonuses; i++)
            {
                listBonuses.Add(new Bonus(_bonus.X, _bonus.Y));
                _bonus.ListBonuses = listBonuses;
                _bonus.X += 2;
                if (_gameGround[_bonus.X - 1, _bonus.Y - 1] != 'X')
                { 
                    DrawBonuses();
                }
            }
            _bonus = new Bonus(2, 5) {CountOfBonuses = 20};
            for (int i = 0; i < _bonus.CountOfBonuses; i++)
            {
                listBonuses.Add(new Bonus(_bonus.X, _bonus.Y));
                _bonus.ListBonuses = listBonuses;
                _bonus.X += 2;
                if(_gameGround[_bonus.X-1, _bonus.Y-1]!='X')
                { 
                    DrawBonuses();
                }
            }
            _bonus = new Bonus(2, 8) { CountOfBonuses = 29 };
            for (int i = 0; i < _bonus.CountOfBonuses; i++)
            {
                listBonuses.Add(new Bonus(_bonus.X, _bonus.Y));
                _bonus.ListBonuses = listBonuses;
                _bonus.X += 2;
                if (_gameGround[_bonus.X - 1, _bonus.Y - 1] != 'X')
                {
                    DrawBonuses();
                }
            }
            _bonus = new Bonus(20, 12) { CountOfBonuses = 20 };
            for (int i = 0; i < _bonus.CountOfBonuses; i++)
            {
                listBonuses.Add(new Bonus(_bonus.X, _bonus.Y));
                _bonus.ListBonuses = listBonuses;
                _bonus.X += 2;
                if (_gameGround[_bonus.X - 1, _bonus.Y - 1] != 'X')
                {
                    DrawBonuses();
                }
            }
            _bonus = new Bonus(2, 17) { CountOfBonuses = 15 };
            for (int i = 0; i < _bonus.CountOfBonuses; i++)
            {
                listBonuses.Add(new Bonus(_bonus.X, _bonus.Y));
                _bonus.ListBonuses = listBonuses;
                _bonus.X += 2;
                if (_gameGround[_bonus.X - 1, _bonus.Y - 1] != 'X')
                {
                    DrawBonuses();
                }
            }
            _bonus = new Bonus(2, 21) { CountOfBonuses = 30 };
            for (int i = 0; i < _bonus.CountOfBonuses; i++)
            {
                listBonuses.Add(new Bonus(_bonus.X, _bonus.Y));
                _bonus.ListBonuses = listBonuses;
                _bonus.X += 2;
                if (_gameGround[_bonus.X - 1, _bonus.Y - 1] != 'X')
                {
                    DrawBonuses();
                }
            }
            _bonus.ListBonuses = listBonuses;
        }

        public void DrawBonuses()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(_bonus.X, _bonus.Y);
            Console.Write('$');
        }

        public void DrawSuperBonus()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_superBonus.X, _superBonus.Y);
            Console.Write('@');
        }

        //public void DrawMonster()
        //{
        //    foreach (var monster in _monster.ListMonsters)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.SetCursorPosition(monster.X, monster.Y);
        //        Console.Write('M');
        //    }
        //}
        //public void RemoveMonster()
        //{
        //    foreach (var monster in _monster.ListMonsters)
        //    {
        //        Console.SetCursorPosition(monster.X, monster.Y);
        //        Console.Write(' ');
        //    }
        //}

        //public void DrawBullet(Bullet bullet, List<Bullet> listBullets,char[,] gameGround)
        //{
        //    foreach (var bullets in listBullets)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.SetCursorPosition(bullets.X, bullets.Y);
        //        gameGround[bullets.X, bullets.Y - 1] = '*';
        //        Console.Write('*');
        //    }
        //}

        //public void RemoveBullet(Bullet bullet, List<Bullet> listBullets, char[,] gameGround)
        //{
        //    foreach (var bullets in listBullets)
        //    {
                
        //        Console.SetCursorPosition(bullets.X, bullets.Y);
        //        gameGround[bullets.X, bullets.Y - 1] = ' ';
        //        Console.Write(' ');
        //    }
        //}
    }
}

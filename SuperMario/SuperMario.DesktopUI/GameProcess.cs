using System;
using System.Drawing;
using System.Media;
using System.Timers;
using System.Windows.Forms;
using SuperMario.GameEngine;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Arsenal;
using SuperMario.GameEngine.Сharacter;
using Timer = System.Timers.Timer;

namespace SuperMario.DesktopUI
{
    public partial class GameProcess : Form
    {
        private MapGraound _mapGraound;
        private Game _game;
        private Movement _movement;
        private Mario _mario;
        private Bonus _bonus;
        private SuperBonus _superBonus;
        private char[,] _gameGround;
        private SoundPlayer _soundPlayer;
        private Monster _monster;
        private Sword _sword;
        /*
         * ВВ: тут краще використовувати System.Windows.Forms.Timer,
         * оскільки він працює у головному потоці програми
         */
        private Timer _timer;
        /*
         * ВВ: цей делегат слід видалити, оскільки він не використовується
         */
        public delegate void CloseDelagate();

        #region Const

        private const string CONG_TEXT = "Congratulation";
        private const string WIN_TEXT = "You Win";
        private const string SCORE_TEXT = "Score";
        private const string FAIL_TEXT = "Sorry but";
        private const string LOSE_TEXT = "You Lose";

        #endregion

        public GameProcess()
        {
            InitializeComponent();
        }

        private void GameProcess_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.mario_icon;
            _game = new Game();
            _game.GameInProgress = true;
            GameLoad(sender, e);
        }

        private void GameLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            Init();
            Paint += Draw;
            Paint += DrawCharacters;
            _timer = new Timer();
            _timer.Elapsed += MonsterMoving;
            _timer.Interval = 400;
            _timer.Start();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            _gameGround = Drawing.DrawGame(_bonus, _mapGraound, _gameGround, sender, e);
        }

        private void DrawCharacters(object sender, PaintEventArgs e)
        {
            Drawing.DrawCharacters(_mario, _sword, _monster, sender, e);
        }

        private void Init()
        {
            _mapGraound = new MapGraound(77, 23);
            _gameGround = new char[_mapGraound.Width, _mapGraound.Height];
            _gameGround = _mapGraound.FillTheArray();
            _movement = new Movement();
            _mario = new Mario(2, 3);
            _game = new Game();
            _bonus = new Bonus(2, 2);
            //_bullet = new Bullet(1, 1);
            _sword = new Sword(_mario.X, _mario.Y);
            _monster = new Monster(1, 1);
            _monster.ListMonsters = _monster.CreateMonsters();
            if (_superBonus == null)
            {
                _superBonus = Drawing.FindSuperBonus(_gameGround);
            }
            //Stream str = Properties.Resources.Mario_song;
            //_soundPlayer = new SoundPlayer(str);

        }

        private void WinOrLoseStatus(Game game)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.lblScoreText.Text += SCORE_TEXT;
            scoreBoard.lblScoreCount.Text += _bonus.BonusScore;
            if (game.GameFinished)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
                this.Dispose();
                this.Close();
                scoreBoard.lblCongText.Text += CONG_TEXT;
                scoreBoard.lblWinLoseText.Text += WIN_TEXT;
                scoreBoard.Show();
            }
            else if (game.GameOver)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
                this.Dispose();
                this.Close();
                scoreBoard.lblWinLoseText.Text += LOSE_TEXT;
                scoreBoard.lblWinLoseText.Location = new Point(120, 40);
                scoreBoard.lblScoreText.Location = new Point(120, 90);
                scoreBoard.lblScoreCount.Location = new Point(215, 90);
                scoreBoard.Show();
            }
        }

        private void MonsterMoving(object sender, ElapsedEventArgs e)
        {
            if (_monster.ListMonsters == null || _monster.ListMonsters.Count == 0)
            {
                _timer.Stop();
            }
            _mario.CheckLife(_monster.ListMonsters, _game);
            _monster.MonsterMoving(_gameGround);
            if(_timer != null)
            {
                BeginInvoke(new Action(() =>
                {
                    Refresh();
                    WinOrLoseStatus(_game);
                }));
                Application.Run();
            }
            
        }

        private void GameProcess_KeyDown(object sender, KeyEventArgs key)
        {
            if (_game.GameInProgress)
            {
                switch (key.KeyData)
                {
                    case Keys.Up:
                        _movement.UpButton = true;
                        _movement.RightButton = false;
                        _movement.LeftButton = false;
                        break;
                    case Keys.Right:
                        _movement.RightButton = true;
                        _movement.LeftButton = false;
                        _movement.UpButton = false;
                        break;
                    case Keys.Left:
                        _movement.LeftButton = true;
                        _movement.RightButton = false;
                        _movement.UpButton = false;
                        break;
                    case Keys.Space:
                        if (_mario.CanShot)
                        {
                            if (_sword.ListOfSwords == null || _sword.ListOfSwords.Count == 0)
                            {
                                _sword.UseButton = true;
                                _sword.CheckIsRight(_mario);
                                _sword.Collisions(_monster, _bonus, _gameGround);
                                _sword.UseSword(_mario);
                                Refresh();
                                _sword.UseButton = false;
                                while (_sword.ListOfSwords.Count != 0)
                                {
                                    _sword.DeleteSword();
                                }
                                Refresh();
                            }
                        }
                        break;
                    case Keys.Escape:
                        _timer.Stop();
                        _timer.Dispose();
                        _timer = null;
                        this.Dispose();
                        this.Close();
                        GameMenu menu = new GameMenu();
                        menu.Show();
                        break;

                }
                _movement.CanMove = _mario.ObjectCollisions(_gameGround, _movement, _game);
                if (_movement.CanMove)
                {
                    switch (key.KeyData)
                    {
                        case Keys.Up:
                            _movement.UpButton = true;
                            _mario.MarioMoving(_movement);
                            _mario.CheckLife(_monster.ListMonsters, _game);
                            if (_mario.CanShot == false)
                            {
                                _mario.MarioCanShot(_superBonus.X, _superBonus.Y, _gameGround);
                            }
                            _bonus.CheckScore(_mario.X, _mario.Y, _superBonus, _gameGround);
                            Refresh();
                            _mario.MoveDownAfterJump(_movement);
                            _mario.CheckLife(_monster.ListMonsters, _game);
                            _movement.UpButton = false;
                            break;


                        case Keys.Right:
                            _mario.IsRight = true;
                            _mario.EarthUnderfoot(_gameGround, _movement);
                            _mario.MarioMoving(_movement);
                            _bonus.CheckScore(_mario.X, _mario.Y, _superBonus, _gameGround);
                            _movement.RightButton = false;
                            _mario.CheckLife(_monster.ListMonsters, _game);
                            break;

                        case Keys.Left:
                            _mario.IsRight = false;
                            _mario.EarthUnderfoot(_gameGround, _movement);
                            _mario.MarioMoving(_movement);
                            _bonus.CheckScore(_mario.X, _mario.Y, _superBonus, _gameGround);
                            _mario.CheckLife(_monster.ListMonsters, _game);
                            _movement.LeftButton = false;
                            break;
                    }
                    Refresh();

                }
                WinOrLoseStatus(_game);
            }
        }
    }
}

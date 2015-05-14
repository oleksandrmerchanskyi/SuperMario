using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMario.GameEngine;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Сharacter;

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
        private  char[,] _gameGround;
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
            _game = new Game();
            _game.GameInProgress = true;
            GameLoad(sender,e);
        }

        private void GameLoad(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Init();
            Paint += Draw;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            _gameGround = Drawing.DrawGame(_mario, _bonus, _mapGraound, _gameGround, sender, e);
        }

        private void Init()
        {
            _mapGraound = new MapGraound(77, 23);
            _gameGround = new char[_mapGraound.Width, _mapGraound.Height];
            _movement = new Movement();
            _mario = new Mario(2, 3);
            _game = new Game();
            _bonus = new Bonus(2, 2);
            _superBonus = new SuperBonus(3, 3);
        }

        private void WinOrLoseStatus(Game game)
        {
            
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.lblScoreText.Text += SCORE_TEXT;
            scoreBoard.lblScoreCount.Text += _bonus.BonusScore;
            if (game.GameFinished)
            {
                this.Close();
                scoreBoard.lblCongText.Text += CONG_TEXT;
                scoreBoard.lblWinLoseText.Text += WIN_TEXT;
                scoreBoard.Show();
            }
            else if(game.GameOver)
            {
                this.Close();
                scoreBoard.lblCongText.Text += FAIL_TEXT;
                scoreBoard.lblWinLoseText.Text += LOSE_TEXT;
                scoreBoard.Show();
            }
        }

        private void GameProcess_KeyDown(object sender, KeyEventArgs key)
        {
            if (_game.GameInProgress == true)
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
                        break;

                }
                _movement.CanMove = _mario.ObjectCollisions(_mario, _gameGround, _movement, _game);
                if (_movement.CanMove == true)
                {
                    switch (key.KeyData)
                    {
                        case Keys.Up:
                            _movement.UpButton = true;
                            _movement.MarioMoving(_mario);
                            //if (_mario.CanShot == false)
                            //{
                            //    _mario.MarioCanShot(_mario,_superBonus, _bonus);
                            //}
                            _bonus.CheckScore(_mario, _bonus.ListBonuses, _gameGround);
                            Refresh();
                            _movement.MoveDownAfterJump(_mario);
                            
                            _bonus.CheckScore(_mario, _bonus.ListBonuses, _gameGround);
                            _movement.UpButton = false;
                            WinOrLoseStatus(_game);
                            Refresh();
                            break;


                        case Keys.Right:
                            _mario.LeftOrRight = true;
                            _mario.EarthUnderfoot(_mario, _gameGround, _movement);
                            _movement.MarioMoving(_mario);
                            _bonus.CheckScore(_mario, _bonus.ListBonuses, _gameGround);
                            _movement.RightButton = false;
                            WinOrLoseStatus(_game);
                            Refresh();
                            break;

                        case Keys.Left:
                            _mario.LeftOrRight = false;
                            _mario.EarthUnderfoot(_mario, _gameGround, _movement);
                            _movement.MarioMoving(_mario);
                            _bonus.CheckScore(_mario, _bonus.ListBonuses, _gameGround);
                            _movement.LeftButton = false;
                            WinOrLoseStatus(_game);
                            Refresh();
                            break;
                    }
                }
            }
        }
    }
}

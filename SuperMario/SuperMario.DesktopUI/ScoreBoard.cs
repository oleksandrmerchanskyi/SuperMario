using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMario.GameEngine.Bonuses;

namespace SuperMario.DesktopUI
{
    public partial class ScoreBoard : Form
    {
        public ScoreBoard()
        {
            InitializeComponent();
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.mario_icon;
        }

        private void btnPlayAgain_MouseEnter(object sender, EventArgs e)
        {
            btnPlayAgain.BackgroundImage = Properties.Resources.PlayAgainHover;
        }

        private void btnPlayAgain_MouseLeave(object sender, EventArgs e)
        {
            btnPlayAgain.BackgroundImage = Properties.Resources.PlayAgain;
        }

        private void btnGoToMenu_MouseEnter(object sender, EventArgs e)
        {
            btnGoToMenu.BackgroundImage = Properties.Resources.backToMenuHover;
        }

        private void btnGoToMenu_MouseLeave(object sender, EventArgs e)
        {
            btnGoToMenu.BackgroundImage = Properties.Resources.backToMenu;
        }
        /*
         * ВВ: порушення конвенції іменування обробника події
         */
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnExitGame.BackgroundImage = Properties.Resources.exitGame;
        }
        /*
         * ВВ: порушення конвенції іменування обробника події
         */
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnExitGame.BackgroundImage = Properties.Resources.exitGameHover;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.Close();
            GameProcess gameProcess = new GameProcess();
            gameProcess.Show();
        }

        private void btnGoToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            GameMenu gameMenu = new GameMenu();
            gameMenu.Show();
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

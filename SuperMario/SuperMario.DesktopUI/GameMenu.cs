using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMario.DesktopUI
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        #region ButtonVisualisation

        private void btnStartGame_MouseEnter(object sender, EventArgs e)
        {
            btnStartGame.BackgroundImage = Properties.Resources.btnStartGameHover;
        }

        private void btnStartGame_MouseLeave(object sender, EventArgs e)
        {
            btnStartGame.BackgroundImage = Properties.Resources.btnStartGame;
        }

        private void btnControls_MouseEnter(object sender, EventArgs e)
        {
            btnControls.BackgroundImage = Properties.Resources.btnControlsHover;
        }

        private void btnControls_MouseLeave(object sender, EventArgs e)
        {
            btnControls.BackgroundImage = Properties.Resources.btnControls;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = Properties.Resources.btnExitHover;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = Properties.Resources.btnExit;
        }

        #endregion

        #region ButtonEvents

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Visible = false;
            GameProcess gameProcess = new GameProcess();
            gameProcess.Show();
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            btnControls.NotifyDefault(false);
            ControlsWindow controls = new ControlsWindow();
            controls.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}

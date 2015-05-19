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
    public partial class ControlsWindow : Form
    {
        public ControlsWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            GameMenu gameMenu = new GameMenu();
            gameMenu.Show();
        }

        private void ControlsWindow_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.mario_icon;
        }
    }
}

using System.Windows.Forms;

namespace SuperMario.DesktopUI
{
    partial class GameMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnControls = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartGame.BackgroundImage")));
            this.btnStartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStartGame.FlatAppearance.BorderSize = 0;
            this.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Location = new System.Drawing.Point(439, 220);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(220, 45);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            this.btnStartGame.MouseEnter += new System.EventHandler(this.btnStartGame_MouseEnter);
            this.btnStartGame.MouseLeave += new System.EventHandler(this.btnStartGame_MouseLeave);
            // 
            // btnControls
            // 
            this.btnControls.BackColor = System.Drawing.Color.Transparent;
            this.btnControls.BackgroundImage = global::SuperMario.DesktopUI.Properties.Resources.btnControls;
            this.btnControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnControls.FlatAppearance.BorderSize = 0;
            this.btnControls.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnControls.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControls.Location = new System.Drawing.Point(465, 290);
            this.btnControls.Name = "btnControls";
            this.btnControls.Size = new System.Drawing.Size(166, 45);
            this.btnControls.TabIndex = 1;
            this.btnControls.UseVisualStyleBackColor = true;
            this.btnControls.Click += new System.EventHandler(this.btnControls_Click);
            this.btnControls.MouseEnter += new System.EventHandler(this.btnControls_MouseEnter);
            this.btnControls.MouseLeave += new System.EventHandler(this.btnControls_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::SuperMario.DesktopUI.Properties.Resources.btnExit;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(507, 354);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 45);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SuperMario.DesktopUI.Properties.Resources.SuperMarioBackgroundForMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnControls);
            this.Controls.Add(this.btnStartGame);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Menu";
            this.Text = "Super Mario";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnStartGame;
        public System.Windows.Forms.Button btnControls;
        public System.Windows.Forms.Button btnExit;

    }
}


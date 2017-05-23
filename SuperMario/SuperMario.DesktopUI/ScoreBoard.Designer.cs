using System.Windows.Forms;

namespace SuperMario.DesktopUI
{
    partial class ScoreBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreBoard));
            this.lblScoreText = new System.Windows.Forms.Label();
            this.lblCongText = new System.Windows.Forms.Label();
            this.lblWinLoseText = new System.Windows.Forms.Label();
            this.lblScoreCount = new System.Windows.Forms.Label();
            this.btnExitGame = new System.Windows.Forms.Button();
            this.btnGoToMenu = new System.Windows.Forms.Button();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScoreText
            // 
            this.lblScoreText.AutoSize = true;
            this.lblScoreText.Font = new System.Drawing.Font("Bauhaus 93", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreText.ForeColor = System.Drawing.Color.Gold;
            this.lblScoreText.Location = new System.Drawing.Point(100, 124);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(0, 33);
            this.lblScoreText.TabIndex = 5;
            // 
            // lblCongText
            // 
            this.lblCongText.AutoSize = true;
            this.lblCongText.Font = new System.Drawing.Font("Bauhaus 93", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongText.ForeColor = System.Drawing.Color.Gold;
            this.lblCongText.Location = new System.Drawing.Point(67, 20);
            this.lblCongText.Name = "lblCongText";
            this.lblCongText.Size = new System.Drawing.Size(0, 34);
            this.lblCongText.TabIndex = 6;
            // 
            // lblWinLoseText
            // 
            this.lblWinLoseText.AutoSize = true;
            this.lblWinLoseText.Font = new System.Drawing.Font("Bauhaus 93", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinLoseText.ForeColor = System.Drawing.Color.Gold;
            this.lblWinLoseText.Location = new System.Drawing.Point(121, 74);
            this.lblWinLoseText.Name = "lblWinLoseText";
            this.lblWinLoseText.Size = new System.Drawing.Size(0, 33);
            this.lblWinLoseText.TabIndex = 7;
            // 
            // lblScoreCount
            // 
            this.lblScoreCount.AutoSize = true;
            this.lblScoreCount.Font = new System.Drawing.Font("Bauhaus 93", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreCount.ForeColor = System.Drawing.Color.Gold;
            this.lblScoreCount.Location = new System.Drawing.Point(195, 124);
            this.lblScoreCount.Name = "lblScoreCount";
            this.lblScoreCount.Size = new System.Drawing.Size(0, 33);
            this.lblScoreCount.TabIndex = 8;
            // 
            // btnExitGame
            // 
            this.btnExitGame.BackgroundImage = global::SuperMario.DesktopUI.Properties.Resources.exitGame;
            this.btnExitGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExitGame.FlatAppearance.BorderSize = 0;
            this.btnExitGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExitGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitGame.Location = new System.Drawing.Point(118, 255);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(150, 35);
            this.btnExitGame.TabIndex = 10;
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Click += new System.EventHandler(this.btnExitGame_Click);
            this.btnExitGame.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnExitGame.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // btnGoToMenu
            // 
            this.btnGoToMenu.BackgroundImage = global::SuperMario.DesktopUI.Properties.Resources.backToMenu;
            this.btnGoToMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGoToMenu.FlatAppearance.BorderSize = 0;
            this.btnGoToMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGoToMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGoToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToMenu.Location = new System.Drawing.Point(217, 215);
            this.btnGoToMenu.Name = "btnGoToMenu";
            this.btnGoToMenu.Size = new System.Drawing.Size(150, 35);
            this.btnGoToMenu.TabIndex = 9;
            this.btnGoToMenu.UseVisualStyleBackColor = true;
            this.btnGoToMenu.Click += new System.EventHandler(this.btnGoToMenu_Click);
            this.btnGoToMenu.MouseEnter += new System.EventHandler(this.btnGoToMenu_MouseEnter);
            this.btnGoToMenu.MouseLeave += new System.EventHandler(this.btnGoToMenu_MouseLeave);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlayAgain.BackgroundImage")));
            this.btnPlayAgain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayAgain.FlatAppearance.BorderSize = 0;
            this.btnPlayAgain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlayAgain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAgain.Location = new System.Drawing.Point(18, 215);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(150, 35);
            this.btnPlayAgain.TabIndex = 3;
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            this.btnPlayAgain.MouseEnter += new System.EventHandler(this.btnPlayAgain_MouseEnter);
            this.btnPlayAgain.MouseLeave += new System.EventHandler(this.btnPlayAgain_MouseLeave);
            // 
            // ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(134)))), ((int)(((byte)(243)))));
            this.BackgroundImage = global::SuperMario.DesktopUI.Properties.Resources.ScoreBackground;
            this.ClientSize = new System.Drawing.Size(385, 320);
            this.Controls.Add(this.btnExitGame);
            this.Controls.Add(this.btnGoToMenu);
            this.Controls.Add(this.lblScoreCount);
            this.Controls.Add(this.lblWinLoseText);
            this.Controls.Add(this.lblCongText);
            this.Controls.Add(this.lblScoreText);
            this.Controls.Add(this.btnPlayAgain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 200);
            this.MaximumSize = new System.Drawing.Size(385, 320);
            this.MinimumSize = new System.Drawing.Size(385, 320);
            this.Name = "ScoreBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Mario";
            this.Load += new System.EventHandler(this.ScoreBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayAgain;
        public System.Windows.Forms.Label lblScoreText;
        public System.Windows.Forms.Label lblWinLoseText;
        public System.Windows.Forms.Label lblScoreCount;
        public System.Windows.Forms.Label lblCongText;
        private System.Windows.Forms.Button btnGoToMenu;
        private System.Windows.Forms.Button btnExitGame;
    }
}
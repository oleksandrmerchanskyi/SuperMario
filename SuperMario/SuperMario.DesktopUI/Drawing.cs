using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMario.GameEngine;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Map;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Arsenal;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.DesktopUI
{
    public class Drawing
    {


        private static void DrawMap(Bonus bonus, char[,] gameGround, object sender, PaintEventArgs e)
        {
            for (int i = 0; i < gameGround.GetLength(0); i++)
            {
                for (int j = 0; j < gameGround.GetLength(1); j++)
                {
                    if (gameGround[i, j] == 'X')
                    {
                        DrawWall(i, j, sender, e);
                    }
                    else if (gameGround[i, j] == '[')
                    {
                        DrawPrincess(i, j, sender, e);
                    }
                    else if (gameGround[i, j] == ']')
                    {
                        DrawDoor(i, j, sender, e);
                    }
                    else if (gameGround[i, j] == 'Q')
                    {
                        DrawWall(i, j, sender, e);
                    }
                    else if (gameGround[i, j] == 'B')
                    {
                        DrawBonuses(bonus, gameGround, sender, e);
                    }
                    else if (gameGround[i, j] == 'S')
                    {
                        DrawSuperBonus(i, j, sender, e);
                    }
                    else if (gameGround[i, j] == ' ')
                    {
                        DrawEmpty(i, j, sender, e);
                    }

                }

            }
        }

        public static void DrawDoor(int i, int j, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Door;
            e.Graphics.DrawImage(image, i * 10, j * 25, 10, 25);
        }

        public static void DrawPrincess(int i, int j, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Princess;
            e.Graphics.DrawImage(image, i * 10, j * 25, 10, 25);
        }

        public static void DrawWall(int i, int j, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.block;
            e.Graphics.DrawImage(image, i * 10, j * 25, 10, 25);
        }

        public static void DrawMario(Mario mario, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.marioRight;
            if (!mario.IsRight)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            e.Graphics.DrawImage(image, (mario.X * 10 - 10), (mario.Y * 25 - 25), 10, 25);
        }

        public static char[,] DrawGame(Bonus bonus, MapGraound mapGraound, char[,] gameGround, object sender, PaintEventArgs e)
        {
            DrawMap(bonus, gameGround, sender, e);
            return gameGround;
        }

        public static void DrawCharacters(Mario mario,Sword sword, Monster monster, object sender, PaintEventArgs e)
        {
            DrawMario(mario, sender, e);
            DrawSword(sword, mario, sender, e);
            DrawMonster(monster, sender, e);
        }

        public static void DrawBonuses(Bonus bonus, char [,] gameGround, object sender, PaintEventArgs e)
        {
            List<Bonus> list = new List<Bonus>();
            list = bonus.GenerateBonus(gameGround);
            Image image = Properties.Resources.coin;
            foreach (var b in list)
            {
                e.Graphics.DrawImage(image, (b.X * 10 - 10), (b.Y * 25 - 25), 10, 15);
            }
   
        }

        public static void DrawEmpty(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blue = new SolidBrush(Color.FromArgb(80, 134, 243));
            Rectangle r = new Rectangle((i*10), (j*25), 25, 25);
            e.Graphics.FillRectangle(blue, r);
        }

        public static SuperBonus FindSuperBonus(char[,] gameGround)
        {
            SuperBonus superBonus = new SuperBonus(1,1);
            for (int i = 0; i < gameGround.GetLength(0); i++)
            {
                for (int j = 0; j < gameGround.GetLength(1); j++)
                {
                    if(gameGround[i,j] == 'S')
                    { 
                    superBonus.X = i+1;
                    superBonus.Y = j+1;
                    return superBonus;
                    }
                }
            }
            return superBonus;
        }

        public static void DrawSuperBonus(int i, int j,object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.super_bonus; 
            e.Graphics.DrawImage(image, (i * 10), (j * 25), 10, 25);
        }

        public static void DrawSword(Sword sword, Mario mario,  object sender, PaintEventArgs e)
        {
            
            if (sword.UseButton)
            {
                foreach (var swor in sword.ListOfSwords)
                {
                    Image image = image = Properties.Resources.sword_2;
                    if (!mario.IsRight)
                    {
                        e.Graphics.DrawImage(image, (swor.X * 10 - 3), (swor.Y * 25 - 11), 10, 5);
                    }
                    else
                    {
                        e.Graphics.DrawImage(image, (swor.X * 10 - 16), (swor.Y * 25 - 11), 10, 5); 
                    }
                }
            }
        }
        public static void DrawMonster(Monster monster, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.ghost_right;
            foreach (var m in monster.ListMonsters)
            {
                e.Graphics.DrawImage(image, (m.X * 10 - 10), (m.Y * 25 - 25), 10, 25);
            }
        }
    }
}

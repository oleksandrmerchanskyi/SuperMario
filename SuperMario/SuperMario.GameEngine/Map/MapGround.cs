using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.GameEngine.Map
{
    public class MapGraound
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public MapGraound(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public char[,] FillTheArray()
        {
            char[,] gameGround = new char[this.Width,this.Height];
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
            for (int i = 0; i < gameGround.GetLength(1); i++)
            {
                for (int j = 0; j < gameGround.GetLength(0); j++)
                {
                    if (mapArray[counter] == 'Z')
                    {
                        gameGround[j, i] += ' ';
                    }
                    else if (mapArray[counter] == 'X')
                    {
                        gameGround[j, i] += mapArray[counter];
                    }
                    else if (mapArray[counter] == '[')
                    {
                        gameGround[j, i] += mapArray[counter];
                    }
                    else if (mapArray[counter] == ']')
                    {
                        gameGround[j, i] += mapArray[counter];
                    }
                    else if (mapArray[counter] == 'Q')
                    {
                        gameGround[j, i] += mapArray[counter];
                    }
                    else if (mapArray[counter] == 'B')
                    {
                        gameGround[j, i] += mapArray[counter];
                    }
                    counter++;
                }
            }
            return gameGround;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.GameEngine.Map
{
    //rename to MapGround
    public class MapGraound
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public MapGraound(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}

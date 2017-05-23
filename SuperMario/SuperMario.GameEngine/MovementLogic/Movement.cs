using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Сharacter;
using SuperMario.GameEngine.Arsenal;

namespace SuperMario.GameEngine.MovementLogic
{
    public class Movement
    {
        public bool LeftButton { get; set; }

        public bool RightButton { get; set; }

        public bool UpButton { get; set; }

        public bool CanMove { get; set; }

        public Movement()
        {
            CanMove = false;
            UpButton = false;
            RightButton = false;
            LeftButton = false;
        }
    }
}

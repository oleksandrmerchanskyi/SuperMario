using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.GameEngine
{
    /*
     * Review GY: на мою думку саме цей клас має інкапсулювати всю логіку гри та
     * містити всі ігрові об'єкти.
     */
    /*
     * ВВ: цілком погоджуюся із попереднім коментарем.
     */
    public class Game
    {
        public bool GameInProgress { get; set; }

        public bool GameFinished { get; set; }

        public bool GameOver { get; set; }

        public Game()
        {
            GameInProgress = true;
            GameFinished = false;
            GameOver = false;
        }
    }
}

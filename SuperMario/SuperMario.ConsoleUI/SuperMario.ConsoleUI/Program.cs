using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.ConsoleUI.ConsoleMovement;
using SuperMario.ConsoleUI.Map;

namespace SuperMario.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BackGroundDraw backGroundDraw = new BackGroundDraw();
            backGroundDraw.GameStart();
            backGroundDraw.GameOver();
            backGroundDraw.GameFinished();
            Console.ReadLine();
        }
    }
}

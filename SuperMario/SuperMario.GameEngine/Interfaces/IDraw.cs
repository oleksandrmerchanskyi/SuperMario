using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Interfaces
{
    public interface IDraw
    {
        void ViewMap();

        void MarioInit();

        void DrawMario(Mario mario);

        void RemoveMario(Mario mario);


        //void DrawMonster();

        //void RemoveMonster();
    }
}

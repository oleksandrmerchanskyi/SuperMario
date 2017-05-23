using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine.Enemies;

namespace SuperMario.GameEngine.Tests
{
    [TestClass]
    public class MonsterTest
    {
        [TestMethod]
        public void CreateMonsterTest()
        {
            Monster monster = new Monster(1,1);
            var actual = monster.CreateMonsters();
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void MonsterMovingTest()
        {
            Monster monster = new Monster(2, 2);
            List<Monster> list = new List<Monster>();
            list.Add(new Monster(3,3));
            monster.ListMonsters = list;
            #region ArrayInit
            char[,] gameGround =new char[5,5];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[0, 3] = ' ';
            gameGround[0, 4] = ' ';
            gameGround[1, 0] = 'Q';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = ' ';
            gameGround[1, 4] = ' ';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            gameGround[2, 3] = ' ';
            gameGround[2, 4] = '';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = ' ';
            gameGround[3, 2] = ' ';
            gameGround[3, 3] = ' ';
            gameGround[3, 4] = ' ';
            gameGround[4, 0] = ' ';
            gameGround[4, 1] = ' ';
            gameGround[4, 2] = ' ';
            gameGround[4, 3] = ' ';
            gameGround[4, 4] = ' ';
            #endregion
            monster.CurrentDirection = "Right";
            monster.MonsterMoving(gameGround);
            Assert.AreEqual(list[0].X, 3);
            monster.CurrentDirection = "Left";
            monster.MonsterMoving(gameGround);
            Assert.AreEqual(list[0].X, 4);
            
        }
    }
}

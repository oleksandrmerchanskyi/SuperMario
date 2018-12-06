using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Tests
{
    [TestClass]
    public class BonusTest
    {
        [TestMethod]
        public void CheckCheckScoreTest()
        {
            Mario mario = new Mario(1,1);
            SuperBonus sb = new SuperBonus(2,2);
            Bonus bonus = new Bonus(1,1);
            Mario mario1 = new Mario(2, 2);
            bonus.BonusScore = 0;
            bonus.ListBonuses = new List<Bonus>();
            bonus.ListBonuses.Add(bonus);
            #region ArrayInit
            char[,] gameGround = new char[5, 5];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[0, 2] = 'X';
            gameGround[0, 3] = 'X';
            gameGround[0, 4] = 'X';
            gameGround[1, 0] = 'X';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = ' ';
            gameGround[1, 4] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            gameGround[2, 3] = ' ';
            gameGround[2, 4] = 'X';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = ' ';
            gameGround[3, 2] = ' ';
            gameGround[3, 3] = ' ';
            gameGround[3, 4] = 'X';
            gameGround[4, 0] = 'X';
            gameGround[4, 1] = 'X';
            gameGround[4, 2] = 'X';
            gameGround[4, 3] = 'X';
            gameGround[4, 4] = 'X';
            #endregion
            bonus.CheckScore(mario.X, mario.Y, sb, gameGround);
            Assert.AreEqual(bonus.ListBonuses.Count, 0);
            Assert.AreEqual(bonus.BonusScore, 50);
            bonus.CheckScore(mario1.X, mario1.Y, sb, gameGround);
            Assert.AreEqual(bonus.BonusScore, 250);
        }

        [TestMethod]
        public void GenereteBonusesTest()
        {
            Bonus bonus = new Bonus(1, 1);
            #region ArrayInit
            char[,] gameGround = new char[2, 2];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[1, 0] = 'B';
            gameGround[1, 1] = 'B'; 
            #endregion
            var actual = bonus.GenerateBonus(gameGround);
            Assert.IsNotNull(actual);
        }
    }
}

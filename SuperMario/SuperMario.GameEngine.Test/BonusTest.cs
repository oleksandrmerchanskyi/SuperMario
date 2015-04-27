using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Test
{
    [TestClass]
    public class BonusTest
    {
        [TestMethod]
        public void CheckScoreTest()
        {
            Mario mario = new Mario(1,1);
            Bonus bonus = new Bonus(1,1);
            bonus.BonusScore = 0;
            List<Bonus> list = new List<Bonus>();
            list.Add(bonus);
            bonus.CheckScore(mario, list);
            Assert.AreEqual(list.Count, 0);
            Assert.AreEqual(bonus.BonusScore, 50);
        }
    }
}

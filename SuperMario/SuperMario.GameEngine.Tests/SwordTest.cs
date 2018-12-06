using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine.Arsenal;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Tests
{
    [TestClass]
    public class SwordTest
    {
        [TestMethod]
        public void CheckIsRightTest()
        {
            Mario mario = new Mario(1,1);
            Sword sword = new Sword(1,1);
            sword.CheckIsRight(mario);
            Assert.IsTrue(sword.IsRight);
            mario.IsRight = false;
            sword.CheckIsRight(mario);
            Assert.IsFalse(sword.IsRight);
        }
        [TestMethod]
        public void UseSwordTest()
        {
            Mario mario = new Mario(1, 1);
            Sword sword = new Sword(1, 1);
            sword.ListOfSwords = new List<Sword>();
            sword.ListOfSwords.Add(sword);
            sword.UseButton = true;
            sword.IsRight = true;
            sword.UseSword(mario);
            Assert.AreEqual(sword.ListOfSwords[0].X, 2);
            sword.ListOfSwords.Add(new Sword(4,4));
            sword.IsRight = false;
            sword.UseSword(mario);
            Assert.AreEqual(sword.ListOfSwords[1].X, 1);
        }
        [TestMethod]
        public void DeleteSwordTest()
        {
            Mario mario = new Mario(1, 1);
            Sword sword = new Sword(1, 1);
            sword.ListOfSwords = new List<Sword>();
            sword.ListOfSwords.Add(sword);
            sword.UseButton = false;
            sword.DeleteSword();
            Assert.AreEqual(sword.ListOfSwords.Count, 0);
        }

        [TestMethod]
        public void SwordCollisionFirstTest()
        {
            Sword sword = new Sword(6, 1);
            sword.ListOfSwords = new List<Sword>();
            sword.ListOfSwords.Add(sword);
            Monster monstr = new Monster(6, 1);
            Bonus bonus = new Bonus(1, 1);
            monstr.ListMonsters = new List<Monster>();
            monstr.ListMonsters.Add(monstr);
            #region ArrayInit
            char[,] gameGround = new char[8, 4];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[0, 3] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = ' ';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' '; 
            gameGround[2, 3] = ' ';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = ' ';
            gameGround[3, 2] = ' ';
            gameGround[3, 3] = ' ';
            gameGround[4, 0] = ' ';
            gameGround[4, 1] = ' ';
            gameGround[4, 2] = ' ';
            gameGround[4, 3] = ' ';
            gameGround[5, 0] = 'X';
            gameGround[5, 1] = ' ';
            gameGround[5, 2] = ' ';
            gameGround[5, 3] = ' ';
            gameGround[6, 0] = 'X';
            gameGround[6, 1] = ' ';
            gameGround[6, 2] = ' ';
            gameGround[6, 3] = ' ';
            gameGround[7, 0] = 'X';
            gameGround[7, 1] = ' ';
            gameGround[7, 2] = ' ';
            gameGround[7, 3] = ' ';
            #endregion
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(monstr.ListMonsters.Count, 0);
            Assert.AreEqual(bonus.BonusScore, 500);
            monstr.ListMonsters.Add(new Monster(7,1));
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(monstr.ListMonsters.Count, 0);
            Assert.AreEqual(bonus.BonusScore, 1000);
            monstr.ListMonsters.Add(new Monster(3, 1));
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(monstr.ListMonsters.Count, 0);
            Assert.AreEqual(bonus.BonusScore, 1500);
            monstr.ListMonsters.Add(new Monster(2, 1));
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(monstr.ListMonsters.Count, 0);
            Assert.AreEqual(bonus.BonusScore, 2000);
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(gameGround[7,0], ' ');
        }

        [TestMethod]
        public void SwordCollisionSecondTest()
        {
            Sword sword = new Sword(7, 1);
            sword.ListOfSwords = new List<Sword>();
            sword.ListOfSwords.Add(sword);
            Monster monstr = new Monster(1, 1);
            monstr.ListMonsters = new List<Monster>();
            monstr.ListMonsters.Add(monstr);
            Bonus bonus = new Bonus(1, 1);
            #region ArrayInit
            char[,] gameGround = new char[9, 4];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[0, 3] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = ' ';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            gameGround[2, 3] = ' ';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = ' ';
            gameGround[3, 2] = ' ';
            gameGround[3, 3] = ' ';
            gameGround[4, 0] = ' ';
            gameGround[4, 1] = 'X';
            gameGround[4, 2] = ' ';
            gameGround[4, 3] = ' ';
            gameGround[5, 0] = 'X';
            gameGround[5, 1] = ' ';
            gameGround[5, 2] = 'X';
            gameGround[5, 3] = ' ';
            gameGround[6, 0] = ' ';
            gameGround[6, 1] = ' ';
            gameGround[6, 2] = ' ';
            gameGround[6, 3] = ' ';
            gameGround[7, 0] = ' ';
            gameGround[7, 1] = ' ';
            gameGround[7, 2] = ' ';
            gameGround[7, 3] = ' ';
            gameGround[8, 0] = 'X';
            gameGround[8, 1] = ' ';
            gameGround[8, 2] = ' ';
            gameGround[8, 3] = ' ';
            #endregion
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(gameGround[6, 0], ' ');
            sword.ListOfSwords.Remove(sword);
            Sword s = new Sword(8,2);
            sword.ListOfSwords.Add(s);
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(gameGround[4, 1], ' ');
            sword.ListOfSwords.Remove(s);
            sword.ListOfSwords.Add(new Sword(8, 3));
            sword.Collisions(monstr, bonus, gameGround);
            Assert.AreEqual(gameGround[5, 2], ' ');
        }

    }
}

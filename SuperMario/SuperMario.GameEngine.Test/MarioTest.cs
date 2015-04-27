using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Test
{
    [TestClass]
    public class MarioTest
    {
        [TestMethod]
        public void MarioCanShotTest()
        {
            Mario mario = new Mario(1,1);
            SuperBonus superBonus = new SuperBonus(1,1);
            Bonus bonus = new Bonus(2,2);
            bonus.BonusScore = 0;
            mario.MarioCanShot(mario, superBonus, bonus);
            Assert.IsTrue(mario.CanShot);
            Assert.AreEqual(bonus.BonusScore, 200);
        }

        [TestMethod]
        public void ObjectCollisionRightFalseTest()
        {
            Movement move= new Movement();
            move.RightButton = true;
            Mario mario = new Mario(1,1);
            char[,] gameGround = new char[3,3];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[0, 2] = 'X';
            gameGround[1, 0] = 'X';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = 'X';
            gameGround[2, 2] = 'X';
            mario.ObjectCollisions(mario, gameGround, move);
            Assert.IsFalse(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionRightTrueTest()
        {
            Movement move = new Movement();
            move.RightButton = true;
            Mario mario = new Mario(1, 1);
            char[,] gameGround = new char[3, 3];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[2, 0] = ' ';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            mario.ObjectCollisions(mario, gameGround, move);
            Assert.IsTrue(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionLeftFalseTest()
        {
            Movement move = new Movement();
            move.LeftButton = true;
            Mario mario = new Mario(2, 1);
            char[,] gameGround = new char[3, 3];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[0, 2] = 'X';
            gameGround[1, 0] = 'X';
            gameGround[1, 1] = 'X';
            gameGround[1, 2] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = 'X';
            mario.ObjectCollisions(mario, gameGround, move);
            Assert.IsFalse(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionLeftTrueTest()
        {
            Movement move = new Movement();
            move.LeftButton = true;
            Mario mario = new Mario(2, 1);
            char[,] gameGround = new char[3, 3];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[2, 0] = ' ';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            mario.ObjectCollisions(mario, gameGround, move);
            Assert.IsTrue(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionUpFalseTest()
        {
            Movement move = new Movement();
            move.UpButton = true;
            Mario mario = new Mario(2, 3);
            char[,] gameGround = new char[3, 3];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[0, 2] = 'X';
            gameGround[1, 0] = 'X';
            gameGround[1, 1] = 'X';
            gameGround[1, 2] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = 'X';
            gameGround[2, 2] = 'X';
            mario.ObjectCollisions(mario, gameGround, move);
            Assert.IsFalse(move.CanMove);
        }

        [TestMethod]
        public void ObjectCollisionUpTrueTest()
        {
            Movement move = new Movement();
            move.UpButton = true;
            Mario mario = new Mario(2, 3);
            char[,] gameGround = new char[3, 3];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[2, 0] = ' ';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            mario.ObjectCollisions(mario, gameGround, move);
            Assert.IsTrue(move.CanMove);
        }

        [TestMethod]
        public void CheckLifeFirstTest()
        {
            Mario mario = new Mario(1,1);
            Game game = new Game();
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster(2,1));
            mario.CheckLife(mario, monsters, game);
            Assert.IsFalse(mario.Life);
            Assert.IsTrue(game.GameOver);
            Assert.IsFalse(game.GameInProgress);
        }
        [TestMethod]
        public void CheckLifeSecondTest()
        {
            Mario mario = new Mario(1, 1);
            Game game = new Game();
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster(1, 1));
            mario.CheckLife(mario, monsters, game);
            Assert.IsFalse(mario.Life);
            Assert.IsTrue(game.GameOver);
            Assert.IsFalse(game.GameInProgress);
        }
        [TestMethod]
        public void CheckLifeThirdTest()
        {
            Mario mario = new Mario(2, 1);
            Game game = new Game();
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster(1, 1));
            mario.CheckLife(mario, monsters, game);
            Assert.IsFalse(mario.Life);
            Assert.IsTrue(game.GameOver);
            Assert.IsFalse(game.GameInProgress);
        }

        [TestMethod]
        public void EarthUnderfootRightTest()
        {
            Mario mario = new Mario(0,0);
            Movement move = new Movement();
            move.RightButton = true;
            char[,] gameGround = new char[2,3];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = 'X';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = 'X';
            mario.EarthUnderfoot(mario, gameGround, move);
            Assert.AreEqual(mario.X, 1);
            Assert.AreEqual(mario.Y,2);
        }
        [TestMethod]
        public void EarthUnderfootLeftTest()
        {
            Mario mario = new Mario(3, 0);
            Movement move = new Movement();
            move.LeftButton = true;
            char[,] gameGround = new char[4, 3];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = 'X';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = 'X';
            gameGround[2, 0] = ' ';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = 'X';
            gameGround[3, 0] = ' ';
            gameGround[3, 1] = ' ';
            gameGround[3, 2] = 'X';
            mario.EarthUnderfoot(mario, gameGround, move);
            Assert.AreEqual(mario.X, 2);
            Assert.AreEqual(mario.Y, 2);
        }
        [TestMethod]
        public void EarthUnderfootTest()
        {
            Mario mario = new Mario(3, 2);
            Movement move = new Movement();
            char[,] gameGround = new char[4, 3];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[0, 2] = 'X';
            gameGround[1, 0] = 'X';
            gameGround[1, 1] = 'X';
            gameGround[1, 2] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = 'X';
            gameGround[2, 2] = 'X';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = 'X';
            gameGround[3, 2] = 'X';
            mario.EarthUnderfoot(mario, gameGround, move);
            Assert.AreEqual(mario.Y, 2);
        }
    }
}

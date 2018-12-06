using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine.Bonuses;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Tests
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
            #region ArrayInit
            char[,] gameGround = new char[5, 5];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[0, 3] = ' ';
            #endregion
            mario.MarioCanShot(superBonus.X, superBonus.Y, gameGround);
            Assert.IsTrue(mario.CanShot);
        }
        [TestMethod]
        public void TestMarioMovingLeft()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.LeftButton = true;
            mario.MarioMoving(move);
            Assert.AreEqual(mario.X, 0);

        }
        [TestMethod]
        public void TestMarioMovingRight()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.RightButton = true;
            mario.MarioMoving(move);
            Assert.AreEqual(mario.X, 2);

        }
        [TestMethod]
        public void TestMarioMovingUp()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.UpButton = true;
            mario.MarioMoving(move);
            Assert.AreEqual(mario.Y, 0);

        }
        [TestMethod]
        public void TestMarioMovingReturn()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            var actual = mario.MarioMoving(move);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void TestMoveDownAfterJumpReturn()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.UpButton = true;
            var actual = mario.MoveDownAfterJump(move);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void TestMoveDownAfterJump()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            mario.MoveDownAfterJump(move);
            Assert.AreEqual(mario.Y, 2);
        }

        [TestMethod]
        public void ObjectCollisionRightFalseTest()
        {
            Movement move= new Movement();
            move.RightButton = true;
            Game game = new Game();
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
            mario.ObjectCollisions(gameGround, move, game);
            Assert.IsFalse(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionRightTrueTest()
        {
            Movement move = new Movement();
            move.RightButton = true;
            Mario mario = new Mario(1, 1);
            Game game = new Game();
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
            mario.ObjectCollisions(gameGround, move, game);
            Assert.IsTrue(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionLeftFalseTest()
        {
            Movement move = new Movement();
            move.LeftButton = true;
            Game game = new Game();
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
            mario.ObjectCollisions(gameGround, move, game);
            Assert.IsFalse(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionLeftTrueTest()
        {
            Movement move = new Movement();
            move.LeftButton = true;
            Mario mario = new Mario(2, 1);
            Game game = new Game();
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
            mario.ObjectCollisions(gameGround, move, game);
            Assert.IsTrue(move.CanMove);
        }
        [TestMethod]
        public void ObjectCollisionUpFalseTest()
        {
            Movement move = new Movement();
            move.UpButton = true;
            Mario mario = new Mario(2, 3);
            Game game = new Game();
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
            mario.ObjectCollisions(gameGround, move, game);
            Assert.IsFalse(move.CanMove);
        }

        [TestMethod]
        public void ObjectCollisionUpTrueTest()
        {
            Movement move = new Movement();
            move.UpButton = true;
            Mario mario = new Mario(2, 3);
            Game game = new Game();
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
            mario.ObjectCollisions(gameGround, move, game);
            Assert.IsTrue(move.CanMove);
        }

        [TestMethod]
        public void CheckLifeFirstTest()
        {
            Mario mario = new Mario(1,1);
            Game game = new Game();
            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster(2,1));
            mario.CheckLife(monsters, game);
            Assert.IsFalse(mario.IsAlive);
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
            mario.CheckLife(monsters, game);
            Assert.IsFalse(mario.IsAlive);
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
            mario.CheckLife(monsters, game);
            Assert.IsFalse(mario.IsAlive);
            Assert.IsTrue(game.GameOver);
            Assert.IsFalse(game.GameInProgress);
        }

        [TestMethod]
        public void EarthUnderfootRightTest()
        {
            Mario mario = new Mario(3,0);
            Movement move = new Movement();
            move.RightButton = true;
            char[,] gameGround = new char[4,3];
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
            mario.EarthUnderfoot(gameGround, move);
            Assert.AreEqual(mario.X, 4);
            Assert.AreEqual(mario.Y,2);
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
            mario.EarthUnderfoot(gameGround, move);
            Assert.AreEqual(mario.Y, 2);
        }
    }
}

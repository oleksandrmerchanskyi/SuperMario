using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario.GameEngine;
using SuperMario.GameEngine.Enemies;
using SuperMario.GameEngine.MovementLogic;
using SuperMario.GameEngine.Shooting;
using SuperMario.GameEngine.Сharacter;

namespace SuperMario.GameEngine.Test
{
    [TestClass]
    public class MovementTest
    {
        [TestMethod]
        public void TestMarioMovingLeft()
        {
            var mario = new Mario(1,1);
            var move = new Movement();
            move.LeftButton = true;
            move.MarioMoving(mario);
            Assert.AreEqual(mario.X,0);

        }
        [TestMethod]
        public void TestMarioMovingRight()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.RightButton = true;
            move.MarioMoving(mario);
            Assert.AreEqual(mario.X, 2);

        }
        [TestMethod]
        public void TestMarioMovingUp()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.UpButton = true;
            move.MarioMoving(mario);
            Assert.AreEqual(mario.Y, 0);

        }
        [TestMethod]
        public void TestMarioMovingReturn()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            var actual = move.MarioMoving(mario);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void TestMoveDownAfterJumpReturn()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.UpButton = true; 
            var actual = move.MoveDownAfterJump(mario);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void TestMoveDownAfterJump()
        {
            var mario = new Mario(1, 1);
            var move = new Movement();
            move.MoveDownAfterJump(mario);
            Assert.AreEqual(mario.Y, 2);
        }

        [TestMethod]
        public void CheckMoveMonsterRight()
        {
            var monster = new Monster(2,2);
            var move = new Movement();
            Mario mario = new Mario(1,1);
            Game game = new Game();
            List<Bullet> list = new List<Bullet>();
            list.Add(new Bullet(1,1));
            List<Monster> listMonsters = new List<Monster>();
            listMonsters.Add(monster);
            char[,] gameGround = new char[5,5];
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
            move.MonsterMoving(monster, listMonsters, gameGround, mario, game, list);
            Assert.AreEqual(listMonsters[0].X, 3);
        }
        [TestMethod]
        public void CheckMoveMonsterCollision()
        {
            var monster = new Monster(2, 2);
            var move = new Movement();
            Mario mario = new Mario(1, 1);
            Game game = new Game();
            List<Bullet> list = new List<Bullet>();
            list.Add(new Bullet(1, 1));
            List<Monster> listMonsters = new List<Monster>();
            listMonsters.Add(monster);
            char[,] gameGround = new char[5, 5];
            gameGround[0, 0] = 'X';
            gameGround[0, 1] = 'X';
            gameGround[0, 2] = 'X';
            gameGround[0, 3] = 'X';
            gameGround[0, 4] = 'X';
            gameGround[1, 0] = 'X';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = 'X';
            gameGround[1, 4] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            gameGround[2, 3] = 'X';
            gameGround[2, 4] = 'X';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = 'X';
            gameGround[3, 2] = 'X';
            gameGround[3, 3] = 'X';
            gameGround[3, 4] = 'X';
            gameGround[4, 0] = 'X';
            gameGround[4, 1] = 'X';
            gameGround[4, 2] = 'X';
            gameGround[4, 3] = 'X';
            gameGround[4, 4] = 'X';
            move.MonsterMoving(monster, listMonsters, gameGround, mario, game, list);
            Assert.AreEqual(listMonsters[0].X, 2);
        }
        [TestMethod]
        public void CheckMoveMonsterLeft()
        {
            var monster = new Monster(2, 2);
            monster.LeftOrRight = true;
            var move = new Movement();
            Mario mario = new Mario(1, 1);
            Game game = new Game();
            List<Bullet> list = new List<Bullet>();
            list.Add(new Bullet(1, 1));
            List<Monster> listMonsters = new List<Monster>();
            listMonsters.Add(monster);
            char[,] gameGround = new char[5, 5];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[0, 3] = ' ';
            gameGround[0, 4] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = 'X';
            gameGround[1, 4] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            gameGround[2, 3] = 'X';
            gameGround[2, 4] = 'X';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = 'X';
            gameGround[3, 2] = 'X';
            gameGround[3, 3] = 'X';
            gameGround[3, 4] = 'X';
            gameGround[4, 0] = 'X';
            gameGround[4, 1] = 'X';
            gameGround[4, 2] = 'X';
            gameGround[4, 3] = 'X';
            gameGround[4, 4] = 'X';
            move.MonsterMoving(monster, listMonsters, gameGround, mario, game, list);
            Assert.AreEqual(listMonsters[0].X, 1);
        }
        [TestMethod]
        public void CheckMonsterFirstDied()
        {
            var monster = new Monster(2, 2);
            List<Monster> mons = new List<Monster>();
            mons.Add(monster);
            var move = new Movement();
            List<Bullet> list = new List<Bullet>();
            list.Add(new Bullet(1, 2));
            move.MonsterLife(monster, mons,list);
            Assert.AreEqual(mons.Count, 0);
        }
        [TestMethod]
        public void CheckMonsterSecondDied()
        {
            var monster = new Monster(3, 2);
            monster.LeftOrRight = true;
            Movement move = new Movement();
            Game game = new Game();
            List<Monster> mons = new List<Monster>();
            mons.Add(monster);
            mons[0].LeftOrRight = true;
            List<Bullet> list = new List<Bullet>();
            list.Add(new Bullet(1, 2));
            Mario mario = new Mario(2,2);
            char[,] gameGround = new char[5, 5];
            gameGround[0, 0] = ' ';
            gameGround[0, 1] = ' ';
            gameGround[0, 2] = ' ';
            gameGround[0, 3] = ' ';
            gameGround[0, 4] = ' ';
            gameGround[1, 0] = ' ';
            gameGround[1, 1] = ' ';
            gameGround[1, 2] = ' ';
            gameGround[1, 3] = 'X';
            gameGround[1, 4] = 'X';
            gameGround[2, 0] = 'X';
            gameGround[2, 1] = ' ';
            gameGround[2, 2] = ' ';
            gameGround[2, 3] = 'X';
            gameGround[2, 4] = 'X';
            gameGround[3, 0] = 'X';
            gameGround[3, 1] = 'X';
            gameGround[3, 2] = 'X';
            gameGround[3, 3] = 'X';
            gameGround[3, 4] = 'X';
            gameGround[4, 0] = 'X';
            gameGround[4, 1] = 'X';
            gameGround[4, 2] = 'X';
            gameGround[4, 3] = 'X';
            gameGround[4, 4] = 'X';
            move.MonsterMoving(monster, mons, gameGround, mario, game, list);
            Assert.IsFalse(mario.Life);
        }
    }
}

using System;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game_Tests
{
    [TestClass]
    public class GameLevelTests
    {
        private Game.Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game.Game(new LevelStorage());
        }

        [TestMethod]
        public void TestGetLevelWidth()
        {
            _game.Load("Level 1");
            const int expectedWidth = 2;
            var actualWidth = _game.LevelStorage.CurrentLevel.Width;
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void TestGetLevelHeight()
        {
            _game.Load("Level 1");
            const int expectedHeight = 3;
            var actualHeight = _game.LevelStorage.CurrentLevel.Height;
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void TestGetLevelCountWithOneLevel()
        {
            _game.Load("Level 1");
            const int expectedLevelCount = 1;
            var actualLevelCount = _game.LevelStorage.LevelCount();
            Assert.AreEqual(expectedLevelCount, actualLevelCount);
        }

        [TestMethod]
        public void TestGetLevelCountWithTwoLevels()
        {
            _game.Load("Level 1");
            _game.Load("Level 2");
            const int expectedLevelCount = 2;
            var actualLevelCount = _game.LevelStorage.LevelCount();
            Assert.AreEqual(expectedLevelCount, actualLevelCount);
        }

        [TestMethod]
        public void TestRecentlyAddedLevelIsCurrentLevelByCheckingSize()
        {
            _game.Load("Level 1");
            var expectedLevelSize = new[] {2, 3};
            var actualLevelSize = new[] {_game.LevelStorage.CurrentLevel.Width, _game.LevelStorage.CurrentLevel.Height};
            Assert.AreEqual(expectedLevelSize[0], actualLevelSize[0]);
            Assert.AreEqual(expectedLevelSize[1], actualLevelSize[1]);
        }

        [TestMethod]
        public void TestSetLevelChangesCurrentLevelbyCheckingSize()
        {
            _game.Load("Level 1");
            _game.Load("Level 2");
            _game.LevelStorage.SetLevel(0);
            var expectedLevelSize = new[] {2, 3};
            var actualLevelSize = new[] {_game.LevelStorage.CurrentLevel.Width, _game.LevelStorage.CurrentLevel.Height};
            Assert.AreEqual(expectedLevelSize[0], actualLevelSize[0]);
            Assert.AreEqual(expectedLevelSize[1], actualLevelSize[1]);
        }

        [TestMethod]
        public void TestSetLevelThrowsExceptionIfNumberIsOutOfRange()
        {
            _game.Load("Level 1");
            _game.Load("Level 2");
            Assert.ThrowsException<IndexOutOfRangeException>(() => _game.LevelStorage.SetLevel(5),
                "That id is not valid");
            Assert.ThrowsException<IndexOutOfRangeException>(() => _game.LevelStorage.SetLevel(-1),
                "That id is not valid");
        }

        [TestMethod]
        public void TestRemoveLevelWithOneLevel()
        {
            _game.Load("Level 1");
            _game.LevelStorage.RemoveLevel(0);
            const int expectedLevelCount = 0;
            var actualLevelCount = _game.LevelStorage.LevelCount();
            Assert.AreEqual(expectedLevelCount, actualLevelCount);
        }
    }
}
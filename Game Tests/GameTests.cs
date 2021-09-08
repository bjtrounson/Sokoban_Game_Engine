using Engine_Base;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game_Tests
{
    [TestClass]
    public class GameTests
    {
        private Game.Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game.Game(new LevelStorage());
            _game.LevelStorage.LoadLevel("Player-Movement-Test");
        }

        private static ListLevelData ConvertLevelStartingDataToLevelData(ListStartingLevelData startingLevelData)
        {
            var convertedLevel = new ListLevelData();
            convertedLevel.AddRange(startingLevelData);
            return convertedLevel;
        }

        [TestMethod]
        public void Restart_CurrentLevel_StartingLevelDataEqualsLevelData()
        {
            _game.Move(Direction.Up);
            _game.Move(Direction.Right);
            _game.Restart();
            var expectedLevelData =
                ConvertLevelStartingDataToLevelData(_game.LevelStorage.CurrentLevel.StartingLevelData);
            var actualLevelData = _game.LevelStorage.CurrentLevel.LevelData;
            CollectionAssert.AreEqual(expectedLevelData, actualLevelData);
        }

        [TestMethod]
        public void Load_CheckingLevelSize_ReturnsWidthTwoAndHeightThree()
        {
            _game.Load("Level 1");
            var expectedLevelSize = new[] {2, 3};
            var actualLevelSize = new[] {_game.LevelStorage.CurrentLevel.Width, _game.LevelStorage.CurrentLevel.Height};
            CollectionAssert.AreEqual(expectedLevelSize, actualLevelSize);
        }

        [TestMethod]
        public void IsFinished_CompletesAllGoals_ReturnsTrue()
        {
            var levelData = new ListISquare
            {
                new Wall(new Position(0, 0)), new Wall(new Position(1, 0)), new Wall(new Position(2, 0)),
                new Wall(new Position(3, 0)), new Wall(new Position(4, 0)),
                new Wall(new Position(0, 1)), new Empty(new Position(1, 1)), new Player(new Position(2, 1)),
                new Empty(new Position(3, 1)), new Wall(new Position(4, 1)),
                new Wall(new Position(0, 2)), new Empty(new Position(1, 2)), new Block(new Position(2, 2)),
                new Goal(new Position(3, 2)), new Wall(new Position(4, 2)),
                new Wall(new Position(0, 3)), new Empty(new Position(1, 3)), new Empty(new Position(2, 3)),
                new Empty(new Position(3, 3)), new Wall(new Position(4, 3)),
                new Wall(new Position(0, 4)), new Wall(new Position(1, 4)), new Wall(new Position(2, 4)),
                new Wall(new Position(3, 4)), new Wall(new Position(4, 4))
            };
            _game.LevelStorage.AddLevel(new Level(4, 4, levelData));
            _game.Move(Direction.Left);
            _game.Move(Direction.Down);
            _game.Move(Direction.Right);
            var isLevelFinish = _game.IsFinished();
            Assert.IsTrue(isLevelFinish);
        }

        [TestMethod]
        public void IsFinished_AllGoalsNotCompleted_ResultFalse()
        {
            _game.Load("Level 2");
            var levelFinished = _game.IsFinished();
            Assert.IsFalse(levelFinished);
        }
    }
}
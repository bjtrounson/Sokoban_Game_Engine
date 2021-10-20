using BaseNS;
using GameNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestNS
{
    [TestClass]
    public class GameBlockMovementTests
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
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
            _game = new Game(new LevelStorage());
            var level = new Level();
            level.CreateLevel(4, 4, levelData);
            _game.LevelStorage.AddLevel(level);
            //_game.Load("Level 2");
        }

        [TestMethod]
        public void Move_BlockMovesOntoGoal_GoalIsCompleted()
        {
            _game.Move(Direction.Left);
            _game.Move(Direction.Down);
            _game.Move(Direction.Right);
            const int expectedCompletedCount = 1;
            var actualCompletedCount = _game.LevelStorage.CurrentLevel.GetCompletedGoals();
            Assert.AreEqual(expectedCompletedCount, actualCompletedCount);
        }

        [TestMethod]
        public void Move_BlockMovesAwayFromGoal_GoalGoesUnComplete()
        {
            _game.Move(Direction.Left);
            _game.Move(Direction.Down);
            _game.Move(Direction.Right);
            _game.Move(Direction.Up);
            _game.Move(Direction.Right);
            _game.Move(Direction.Down);
            const int expectedCompletedCount = 0;
            var actualCompletedCount = _game.LevelStorage.CurrentLevel.GetCompletedGoals();
            Assert.AreEqual(expectedCompletedCount, actualCompletedCount);
        }
    }
}
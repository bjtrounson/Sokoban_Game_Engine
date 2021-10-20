using BaseNS;
using GameNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestNS
{
    [TestClass]
    public class GamePlayerMovementTests
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
        }

        [TestMethod]
        public void Move_PlayerMovesIntoBlock_BlockPositionChanges()
        {
            _game.Move(Direction.Down);
            var expectedSquareType = typeof(Block);
            var actualSquareType = _game.LevelStorage.CurrentLevel.GetISquareAtPosition(2, 3).GetType();
            Assert.AreEqual(expectedSquareType, actualSquareType);
        }

        [TestMethod]
        public void Move_PlayerMovesIntoBlock_BlockPositionDoesntChangeBecauseOfWall()
        {
            _game.Move(Direction.Left);
            _game.Move(Direction.Down);
            _game.Move(Direction.Right);
            _game.Move(Direction.Right);
            var expectedSquareType = typeof(Block);
            var actualSquareType = _game.LevelStorage.CurrentLevel.GetISquareAtPosition(3, 2).GetType();
            Assert.AreEqual(expectedSquareType, actualSquareType);
        }

        [TestMethod]
        public void Move_PlayerMovesIntoBlock_PlayerPositionDoesntChangeWhenBlockCantMove()
        {
            _game.Move(Direction.Left);
            _game.Move(Direction.Down);
            _game.Move(Direction.Right);
            _game.Move(Direction.Right);
            var expectedSquareType = typeof(Player);
            var actualSquareType = _game.LevelStorage.CurrentLevel.GetISquareAtPosition(2, 2).GetType();
            Assert.AreEqual(expectedSquareType, actualSquareType);
        }

        [TestMethod]
        public void Move_PlayerMovesOnGoal_PlayerStoresGoal()
        {
            _game.Move(Direction.Right);
            _game.Move(Direction.Down);
            var hasPlayerGoal = _game.LevelStorage.CurrentLevel.GetPlayer().Goal;
            Assert.IsNotNull(hasPlayerGoal);
        }

        [TestMethod]
        public void Move_PlayerMovesAwayFromGoal_PlayerDropsGoal()
        {
            _game.Move(Direction.Right);
            _game.Move(Direction.Down);
            _game.Move(Direction.Down);
            var doesntHavePlayerGoal = _game.LevelStorage.CurrentLevel.GetPlayer().Goal;
            Assert.IsNull(doesntHavePlayerGoal);
        }

        [TestMethod]
        public void Move_PlayerMovesOnGoal_PlayerPartChanges()
        {
            _game.Move(Direction.Right);
            _game.Move(Direction.Down);
            const Part expectedPart = Part.PlayerOnGoal;
            var actualPart = _game.LevelStorage.CurrentLevel.GetPlayer().SquarePart;
            Assert.AreEqual(expectedPart, actualPart);
        }

        [TestMethod]
        public void Move_PlayerMovesAwayFromGoal_PlayerPartChanges()
        {
            _game.Move(Direction.Right);
            _game.Move(Direction.Down);
            _game.Move(Direction.Down);
            const Part expectedPark = Part.Player;
            var actualPart = _game.LevelStorage.CurrentLevel.GetPlayer().SquarePart;
            Assert.AreEqual(expectedPark, actualPart);
        }
    }
}
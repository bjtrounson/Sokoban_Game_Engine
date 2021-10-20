using BaseNS;
using GameNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestNS
{
    [TestClass]
    public class GameMovementTests
    {
        private Game _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new Game(new LevelStorage());
            _game.LevelStorage.LoadLevel("Player-Movement-Test");
        }

        [TestMethod]
        public void Move_DirectionUp_ReturnsNewPlayerPosition()
        {
            _game.Move(Direction.Up);
            var expectedPosition = new Position(2, 1);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void Move_DirectionDown_ReturnsNewPlayerPosition()
        {
            _game.Move(Direction.Down);
            var expectedPosition = new Position(2, 3);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void Move_DirectionLeft_ReturnsNewPlayerPosition()
        {
            _game.Move(Direction.Left);
            var expectedPosition = new Position(1, 2);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void Move_DirectionRight_ReturnsNewPlayerPosition()
        {
            _game.Move(Direction.Right);
            var expectedPosition = new Position(3, 2);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void Move_DirectionRightAndDown_ReturnsNewPlayerPosition()
        {
            _game.Move(Direction.Right);
            _game.Move(Direction.Down);
            var expectedPosition = new Position(3, 3);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void GetMoveCount_PlayerMovement_ReturnsNumberOne()
        {
            _game.Move(Direction.Up);
            const int expectedMoveCount = 1;
            var actualMoveCount = _game.GetMoveCount();
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }

        [TestMethod]
        public void GetMoveCount_PlayerMovement_ReturnsNumberTwo()
        {
            _game.Move(Direction.Up);
            _game.Move(Direction.Right);
            const int expectedMoveCount = 2;
            var actualMoveCount = _game.GetMoveCount();
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }

        [TestMethod]
        public void Undo_PlayerMovement_PlayerPositionEqualsPreviousPosition()
        {
            _game.Move(Direction.Down);
            _game.Undo();
            var expectedPosition = new Position(2, 2);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void Undo_PlayerMovement_PlayerPositionEqualsTwoMovesBeforePosition()
        {
            _game.Move(Direction.Down);
            _game.Move(Direction.Right);
            _game.Move(Direction.Up);
            _game.Undo();
            _game.Undo();
            var expectedPosition = new Position(2, 3);
            var actualPosition = _game.LevelStorage.CurrentLevel.GetPlayer().Position;
            Assert.AreEqual(expectedPosition, actualPosition);
        }
    }
}
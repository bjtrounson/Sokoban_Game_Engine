using System.Linq;
using Engine_Base;

namespace Game
{
    public class Game : IGame
    {
        public Game(LevelStorage levelStorage)
        {
            LevelStorage = levelStorage;
        }

        public LevelStorage LevelStorage { get; }

        /// <summary>
        ///     Moves the Player to a new Position.
        /// </summary>
        /// <param name="moveDirection">Direction</param>
        public void Move(Direction moveDirection)
        {
            var player = LevelStorage.CurrentLevel.GetPlayer();
            ISquare squareAtPos;
            Position newPos;
            switch (moveDirection)
            {
                // Mental Note for future retard Ben that won't be able to mentally grasp what this aids switch statement is doing.
                // Also if I have left this here and handed in the assessment like this be mind the abuse I call myself above lol.
                // So for example with going the new Position of the player is going to be it current Position with a offset of -1 on its Y axis.
                // We will grab the square that is at the position to check later on.
                // We will check weather its okay to move to the position using are check method. e.g. Checks weather there is not a wall there.
                // If there is no wall, We will check if the square if a block.
                // If it is then check the block above to see if its not a wall.
                // If that is also true then update the block (If there is one) and the player
                case Direction.Up:
                    newPos = new Position(player.Position.X, player.Position.Y - 1);
                    squareAtPos = LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X, newPos.Y);
                    if (CheckMove(newPos))
                    {
                        if (squareAtPos.GetType() == typeof(Block))
                            if (LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X, newPos.Y - 1).GetType() !=
                                typeof(Wall))
                                squareAtPos.Position = new Position(newPos.X, newPos.Y - 1);
                        player.Position = newPos;
                        player.MoveCount++;
                    }

                    break;
                case Direction.Down:
                    newPos = new Position(player.Position.X, player.Position.Y + 1);
                    squareAtPos = LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X, newPos.Y);
                    if (CheckMove(newPos))
                    {
                        if (squareAtPos.GetType() == typeof(Block))
                            if (LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X, newPos.Y + 1).GetType() !=
                                typeof(Wall))
                                squareAtPos.Position = new Position(newPos.X, newPos.Y + 1);
                        player.Position = newPos;
                        player.MoveCount++;
                    }

                    break;
                case Direction.Left:
                    newPos = new Position(player.Position.X - 1, player.Position.Y);
                    squareAtPos = LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X, newPos.Y);
                    if (CheckMove(newPos))
                    {
                        if (squareAtPos.GetType() == typeof(Block))
                            if (LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X - 1, newPos.Y).GetType() !=
                                typeof(Wall))
                                squareAtPos.Position = new Position(newPos.X - 1, newPos.Y);
                        player.Position = newPos;
                        player.MoveCount++;
                    }

                    break;
                case Direction.Right:
                    newPos = new Position(player.Position.X + 1, player.Position.Y);
                    squareAtPos = LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X, newPos.Y);
                    if (CheckMove(newPos))
                    {
                        if (squareAtPos.GetType() == typeof(Block))
                            if (LevelStorage.CurrentLevel.GetISquareAtIndex(newPos.X + 1, newPos.Y).GetType() !=
                                typeof(Wall))
                                squareAtPos.Position = new Position(newPos.X + 1, newPos.Y);
                        player.Position = newPos;
                        player.MoveCount++;
                    }

                    break;
            }
        }

        /// <summary>
        ///     Gets the Players move count.
        /// </summary>
        /// <returns>Returns a integer of how many move the player has taken</returns>
        public int GetMoveCount()
        {
            return LevelStorage.CurrentLevel.GetPlayer().MoveCount;
        }

        /// <summary>
        ///     Undoes the previous move by making the current position as the previous move.
        /// </summary>
        public void Undo()
        {
            var player = LevelStorage.CurrentLevel.GetPlayer();
            player.Position = player.PrevPositions.Last();
            if (player.PrevPositions.Count > 1) player.PrevPositions.RemoveAt(player.PrevPositions.Count - 1);
        }

        /// <summary>
        ///     Resets the Current Level data to the Starting Level data when the Level object was created.
        /// </summary>
        public void Restart()
        {
            var resetLevel = new ListLevelData();
            resetLevel.AddRange(LevelStorage.CurrentLevel.StartingLevelData);
            LevelStorage.CurrentLevel.LevelData = resetLevel;
        }

        /// <summary>
        ///     Checks if the Level is finished.
        /// </summary>
        /// <returns>Returns a bool if the Level is completed or not.</returns>
        public bool IsFinished()
        {
            return LevelStorage.CurrentLevel.Completed;
        }

        /// <summary>
        ///     Loads a stored level by a given Level Name e.g. "Level 1", "Level 2"
        /// </summary>
        /// <param name="newLevel">string newLevel</param>
        public void Load(string newLevel)
        {
            switch (newLevel)
            {
                case "Level 1":
                    LevelStorage.LoadLevel("Level-1");
                    break;
                case "Level 2":
                    LevelStorage.LoadLevel("Level-2");
                    break;
            }
        }

        /// <summary>
        ///     Checks weather a player can move to a different position.
        /// </summary>
        /// <param name="checkPosition">Position to check</param>
        /// <returns>Returns a bool if the Player can move or not.</returns>
        private bool CheckMove(Position checkPosition)
        {
            var squareAtPos = LevelStorage.CurrentLevel.GetISquareAtIndex(checkPosition.X, checkPosition.Y);
            return squareAtPos.GetType() == typeof(Empty) || squareAtPos.GetType() == typeof(Block) ||
                   squareAtPos.GetType() == typeof(Goal);
        }
    }
}
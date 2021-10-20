using System;
using System.Linq;
using BaseNS;

namespace GameNS
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
            Position playerNewPos;
            Position squareNewPos;
            switch (moveDirection)
            {
                case Direction.Up:
                    playerNewPos = new Position(player.Position.X, player.Position.Y - 1);
                    squareNewPos = new Position(playerNewPos.X, playerNewPos.Y - 1);
                    MovementAlgorithm(playerNewPos, squareNewPos, player);
                    break;
                case Direction.Down:
                    playerNewPos = new Position(player.Position.X, player.Position.Y + 1);
                    squareNewPos = new Position(playerNewPos.X, playerNewPos.Y + 1);
                    MovementAlgorithm(playerNewPos, squareNewPos, player);
                    break;
                case Direction.Left:
                    playerNewPos = new Position(player.Position.X - 1, player.Position.Y);
                    squareNewPos = new Position(playerNewPos.X - 1, playerNewPos.Y);
                    MovementAlgorithm(playerNewPos, squareNewPos, player);
                    break;
                case Direction.Right:
                    playerNewPos = new Position(player.Position.X + 1, player.Position.Y);
                    squareNewPos = new Position(playerNewPos.X + 1, playerNewPos.Y);
                    MovementAlgorithm(playerNewPos, squareNewPos, player);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moveDirection), moveDirection, null);
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
            return LevelStorage.CurrentLevel.GetTotalGoals() == LevelStorage.CurrentLevel.GetCompletedGoals();
        }

        /// <summary>
        ///     Loads a some preset levels by a given Level Name e.g. "Level 1", "Level 2"
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
        private bool AllowMove(Position checkPosition)
        {
            var squareAtPos = LevelStorage.CurrentLevel.GetISquareAtPosition(checkPosition.X, checkPosition.Y);
            return squareAtPos.GetType() == typeof(Empty) || squareAtPos.GetType() == typeof(Block) ||
                   squareAtPos.GetType() == typeof(Goal);
        }

        private void MovementAlgorithm(Position playerNewPos, Position squareNewPos, Player player)
        {
            var squareNextToPlayer = LevelStorage.CurrentLevel.GetISquareAtPosition(playerNewPos.X, playerNewPos.Y);
            var squareNextToSquare = LevelStorage.CurrentLevel.GetISquareAtPosition(squareNewPos.X, squareNewPos.Y);
            var playerIndex = LevelStorage.CurrentLevel.GetIndexForISquare(player);
            var squareIndex = LevelStorage.CurrentLevel.GetIndexForISquare(squareNextToPlayer);
            if (!AllowMove(playerNewPos)) return;
            if (squareNextToPlayer.GetType() == typeof(Block))
            {
                if (squareNextToSquare.GetType() == typeof(Wall)) return;
                var block = (Block) squareNextToPlayer;
                var indexForNewBlock =
                    LevelStorage.CurrentLevel.GetIndexForISquare(
                        LevelStorage.CurrentLevel.GetISquareAtPosition(squareNewPos.X, squareNewPos.Y));
                UpdatePlayerPlaceInLevel(player, playerIndex, squareIndex, playerNewPos);
                if (squareNextToSquare.GetType() == typeof(Goal))
                {
                    block.SquarePart = Part.BlockOnGoal;
                    block.Goal = (Goal) squareNextToSquare;
                    block.Goal.Completed = true;
                    UpdateBlockInLevel(block, squareNextToSquare, squareIndex, indexForNewBlock, squareNewPos, true);
                }
                else
                {
                    UpdateBlockInLevel(block, squareNextToSquare, squareIndex, indexForNewBlock, squareNewPos, false);
                }
            }
            else
            {
                UpdatePlayerPlaceInLevel(player, playerIndex, squareIndex, playerNewPos);
                if (squareNextToPlayer.GetType() != typeof(Goal)) return;
                player.SquarePart = Part.PlayerOnGoal;
                player.Goal = (Goal) squareNextToPlayer;
            }
        }

        private void ChangeObjectAtIndex(ISquare square, int index)
        {
            LevelStorage.CurrentLevel.LevelData[index] = square;
        }

        private void UpdatePlayerPlaceInLevel(Player player, int playerIndex, int squareIndex, Position newPos)
        {
            if (player.Goal is not null)
            {
                ChangeObjectAtIndex(player.Goal, playerIndex);
                player.Goal = null;
                player.SquarePart = Part.Player;
            }
            else
            {
                ChangeObjectAtIndex(new Empty(player.Position), playerIndex);
            }

            player.PrevPositions.Add(player.Position);
            player.Position = newPos;
            player.MoveCount++;
            ChangeObjectAtIndex(player, squareIndex);
        }

        private void UpdateBlockInLevel(Block block, ISquare squareNextToSquare, int squareIndex, int indexForNewBlock,
            Position blockNewPos, bool addGoal)
        {
            if (addGoal)
            {
                block.SquarePart = Part.BlockOnGoal;
                block.Goal = (Goal) squareNextToSquare;
                block.Goal.Completed = true;
            }
            else
            {
                if (block.Goal is not null)
                {
                    block.Goal.Completed = false;
                    LevelStorage.CurrentLevel.GetPlayer().Goal = block.Goal;
                    block.Goal = null;
                }
            }

            block.Position = blockNewPos;
            ChangeObjectAtIndex(block, indexForNewBlock);
        }
    }
}
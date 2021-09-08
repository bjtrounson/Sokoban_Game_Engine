using System.Linq;
using System.Xml.Serialization;

namespace Engine_Base
{
    [XmlRoot]
    public class Level : ILevel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ListLevelData LevelData { get; set; }
        public ListStartingLevelData StartingLevelData { get; set; }

        /// <summary>
        ///     Creates a new level with width, height and LevelData.
        /// </summary>
        /// <param name="width">Width of the Level. Starts at 0</param>
        /// <param name="height">Height of the Level. Starts at 0</param>
        /// <param name="levelData">
        ///     The level data contains a list of objects that are apart of the Level. e.g. Wall, Player and
        ///     Goal
        /// </param>
        public Level(int width, int height, ListISquare levelData)
        {
            Width = width;
            Height = height;
            LevelData = LevelDataConvertor(levelData);
            StartingLevelData = StartingLevelDataConvertor(levelData);
        }

        /// <summary>
        ///     Creates a level with width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Level(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Parameterless Constructor for the XMLSerializer.
        /// </summary>
        public Level()
        {
        }

        /// <summary>
        ///     Gets a Goal object at a given X and Y axis.
        /// </summary>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <returns>Returns a Goal</returns>
        public Goal GetGoalAtPosition(int gridX, int gridY)
        {
            Goal goalAtPos = null;
            foreach (var square in LevelData.Where(square => square.GetType() == typeof(Goal))
                .Where(square => square.Position.X == gridX && square.Position.Y == gridY)) goalAtPos = (Goal) square;
            return goalAtPos;
        }

        /// <summary>
        ///     Gets a Part Enum at a given X and Y axis.
        /// </summary>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <returns>Returns a Part Enum</returns>
        public Part GetPartAtPosition(int gridX, int gridY)
        {
            var squarePart = Part.Empty;
            foreach (var square in LevelData.Where(
                square => (square.Position.X == gridX) & (square.Position.Y == gridY))) squarePart = square.SquarePart;
            return squarePart;
        }

        /// <summary>
        ///     Gets a object that inherits off the ISquare Interface at a given X and Y axis.
        /// </summary>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <returns>Returns a ISquare object</returns>
        public ISquare GetISquareAtPosition(int gridX, int gridY)
        {
            ISquare squareResult = null;
            foreach (var square in LevelData.Where(
                square => (square.Position.X == gridX) & (square.Position.Y == gridY)))
                squareResult = square;
            return squareResult;
        }

        /// <summary>
        ///     Gets the total goals in the Level Data.
        /// </summary>
        /// <returns>Returns a int of total goals</returns>
        public int GetTotalGoals()
        {
            var count = 0;
            foreach (var square in LevelData.Where(square =>
                square.GetType() == typeof(Goal) || square.GetType() == typeof(Block)))
                if (square.GetType() == typeof(Goal))
                {
                    count++;
                }
                else
                {
                    var block = (Block) square;
                    if (block.Goal != null) count++;
                }

            return count;
        }


        /// <summary>
        ///     Gets the total completed goals in the Level Data.
        /// </summary>
        /// <returns>Returns a int of how many completed goals</returns>
        public int GetCompletedGoals()
        {
            return (from square in LevelData where square.GetType() == typeof(Block) select (Block) square).Count(
                block => block.Goal is not null);
        }

        /// <summary>
        ///     Gets the Player object in the Level Data.
        /// </summary>
        /// <returns>Returns a Player Object or null if there isn't a Player</returns>
        public Player GetPlayer()
        {
            Player player = null;
            foreach (var square in LevelData.Where(square => square.GetType() == typeof(Player)))
                player = (Player) square;
            return player;
        }

        public int GetIndexForISquare(ISquare square)
        {
            var index = 0;
            foreach (var (obj, i) in LevelData.Select((value, i) => (value, i)))
                if (obj == square)
                    index = i;
            return index;
        }

        private ListLevelData LevelDataConvertor(ListISquare levelData)
        {
            var resultData = new ListLevelData();
            resultData.AddRange(levelData);
            return resultData;
        }

        private ListStartingLevelData StartingLevelDataConvertor(ListISquare levelData)
        {
            var resultData = new ListStartingLevelData();
            resultData.AddRange(levelData);
            return resultData;
        }
    }
}
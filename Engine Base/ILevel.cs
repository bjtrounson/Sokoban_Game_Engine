namespace Engine_Base
{
    public interface ILevel
    {
        public int Width { get; }
        public int Height { get; }
        public ListLevelData LevelData { get; set; }
        public ListStartingLevelData StartingLevelData { get; }
        public bool Completed { get; set; }

        /// <summary>
        ///     Iterates through all goals in the level and returns the goal at the given position.
        /// </summary>
        /// <param name="gridX">The X axis or row that the goal is on.</param>
        /// <param name="gridY">The Y axis or column that the goal is on.</param>
        /// <returns>If a goal is found it returns a Goal if no goal can be found it returns null.</returns>
        public Goal GetGoalAtIndex(int gridX, int gridY);

        /// <summary>
        ///     Iterates through all Squares in the level and returns the part enum at the given position.
        /// </summary>
        /// <param name="gridX">The X axis or row that the goal is on.</param>
        /// <param name="gridY">The Y axis or column that the goal is on.</param>
        /// <returns>Returns a Part Enum</returns>
        public Part GetPartAtIndex(int gridX, int gridY);

        public ISquare GetISquareAtIndex(int gridX, int gridY);

        /// <summary>
        ///     Iterate through the LevelData check for Square Types that are Goals.
        /// </summary>
        /// <returns>Total Goals in the LevelData.</returns>
        public int GetTotalGoals();

        /// <summary>
        ///     Iterates through the LevelData and Checks for goals that have been Completed.
        /// </summary>
        /// <returns>Returns the number of Completed Goals.</returns>
        public int GetCompletedGoals();

        public Player GetPlayer();
    }
}
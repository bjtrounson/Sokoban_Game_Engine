using System;
using BaseNS;

namespace GameNS
{
    public class LevelBuilder : ILevelBuilder
    {
        private readonly LevelStorage _levelStorage;

        public LevelBuilder(LevelStorage levelStorage)
        {
            _levelStorage = levelStorage;
        }

        public void CreateLevel(int width, int height)
        {
            _levelStorage.AddLevel(new Level(width, height));
        }

        public int GetLevelWidth()
        {
            return _levelStorage.CurrentLevel.Width;
        }

        public int GetLevelHeight()
        {
            return _levelStorage.CurrentLevel.Height;
        }

        public void AddBlock(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddWall(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddGoal(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddEmpty(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddBlockOnGoal(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddPlayerOnGoal(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public Part GetPartAtIndex(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        public bool CheckValid()
        {
            throw new NotImplementedException();
        }
    }
}
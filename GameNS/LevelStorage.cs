using System;
using System.Collections.Generic;
using BaseNS;
using FilerNS;

namespace GameNS
{
    public class LevelStorage
    {
        private readonly List<Level> _allLevels = new();
        public Level CurrentLevel { get; private set; }

        /// <summary>
        ///     Adds a level to the level list.
        /// </summary>
        /// <param name="level">The level to add to the list</param>
        public void AddLevel(Level level)
        {
            _allLevels.Add(level);
            CurrentLevel = level;
        }

        /// <summary>
        ///     Sets a the current level from the level list by a given id.
        /// </summary>
        /// <param name="id">The id of the level to be the current level</param>
        /// <exception cref="IndexOutOfRangeException">If id given is out of range of LevelCount</exception>
        public void SetLevel(int id)
        {
            if (id > LevelCount() || id < 0)
                throw new IndexOutOfRangeException("That id is not valid");
            CurrentLevel = _allLevels[id];
        }

        /// <summary>
        ///     Removes a level in the Level list at a certain id.
        /// </summary>
        /// <param name="id">Id of Level to remove</param>
        public void RemoveLevel(int id)
        {
            _allLevels.RemoveAt(id);
        }

        /// <summary>
        ///     Gets the amount of Levels in the Level list.
        /// </summary>
        /// <returns>Returns the Count of levels in the list.</returns>
        public int LevelCount()
        {
            return _allLevels.Count;
        }

        /// <summary>
        ///     Saves the current active level into a XML file.
        /// </summary>
        /// <param name="fileName">File name to be saved as.</param>
        public void SaveCurrentLevel(string fileName)
        {
            var saver = new Saver(CurrentLevel);
            saver.Save(fileName, new Fileable(CurrentLevel));
        }

        /// <summary>
        ///     Loads a level from a file.
        /// </summary>
        /// <param name="fileName">file name of the level to load</param>
        public void LoadLevel(string fileName)
        {
            var loader = new Loader();
            loader.Load(fileName);
            var level = loader.Level;
            _allLevels.Add(level);
            CurrentLevel = level;
        }
    }
}
using System;
using BaseNS;
using FilerNS;

namespace GameNS
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var levelOneData = new ListISquare
            {
                new Wall(new Position(0, 0)), new Wall(new Position(1, 0)), new Wall(new Position(2, 0)),
                new Wall(new Position(3, 0)), new Wall(new Position(4, 0)),
                new Wall(new Position(0, 1)), new Empty(new Position(1, 1)), new Empty(new Position(2, 1)),
                new Empty(new Position(3, 1)), new Wall(new Position(4, 1)),
                new Wall(new Position(0, 2)), new Empty(new Position(1, 2)), new Player(new Position(2, 2)),
                new Empty(new Position(3, 2)), new Wall(new Position(4, 2)),
                new Wall(new Position(0, 3)), new Empty(new Position(1, 3)), new Block(new Position(2, 3)),
                new Empty(new Position(3, 3)), new Wall(new Position(4, 3)),
                new Wall(new Position(0, 4)), new Wall(new Position(1, 4)), new Wall(new Position(2, 4)),
                new Wall(new Position(3, 4)), new Wall(new Position(4, 4))
            };
            /*var level = new Level();
            level.CreateLevel(4, 5, levelOneData);
            var levelStorage = new LevelStorage();
            var game = new Game(levelStorage);
            game.LevelStorage.AddLevel(level);
            game.LevelStorage.SaveCurrentLevel("Player-Movement-Test");
            Console.WriteLine(game.LevelStorage.CurrentLevel.GetPlayer().Position);*/
            var loader = new Loader();
            Console.WriteLine(loader.Load("Level-1"));
            /*var levelData = new ListISquare
            {
                new Wall(new Position(0, 0)),
                new Wall(new Position(1, 0)),
                new Wall(new Position(2, 0)),
                new Wall(new Position(0, 1)),
                new Player(new Position(1, 1)),
                new Wall(new Position(2, 1)),
                new Wall(new Position(0, 2)),
                new Goal(new Position(1, 2)),
                new Wall(new Position(2, 2)),
                new Wall(new Position(0, 3)),
                new Wall(new Position(1, 3)),
                new Wall(new Position(2, 3))
            };*/
            //var level = new Level(2, 3, levelData);

            //game.Load("Level 1");
            //levelStorage.LoadLevel("Level-1");
            //Console.WriteLine("<--- LevelData --->");
            //Console.WriteLine(levelStorage.CurrentLevel.LevelData.Count);
            //foreach (var square in levelStorage.CurrentLevel.LevelData) Console.WriteLine(square.GetType());
            //Console.WriteLine("<--- LevelData --->");
            //Console.WriteLine("<--- StartingLevelData --->");
            //Console.WriteLine(levelStorage.CurrentLevel.StartingLevelData.Count);
            //foreach (var square in levelStorage.CurrentLevel.StartingLevelData) Console.WriteLine(square.GetType());
            //Console.WriteLine("<--- StartingLevelData --->");
        }
    }
}
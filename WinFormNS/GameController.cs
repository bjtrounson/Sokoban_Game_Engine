using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNS;
using BaseNS;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormNS
{
    public class GameController
    {
        private Game _game;
        private IGameView _view;
        public GameController(Game game, IGameView view)
        {
            _view = view;
            _game = game;
        }

        public void CreateLevel()
        {
            var level = new Level();
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
            level.CreateLevel("Level 1", 4, 4, levelData);
            _game.LevelStorage.AddLevel(level);
            GenerateLevelButtons(_game.LevelStorage.CurrentLevel);
        }

        public void MoveCharacter(Direction direction)
        {
            Player player;
            Position playerBehindPos;
            Position playerPos;
            Position playerInFrontPos;
            Part squarePartBehind;
            Part squarePart;
            Part squarePartInFront;
            Button playerButtonBehind;
            Button playerButton;
            Button playerButtonInFront;
            switch (direction)
            {
                case Direction.Up:
                    _game.Move(direction);
                    player = _game.LevelStorage.CurrentLevel.GetPlayer();
                    playerBehindPos = new Position(player.Position.X, player.Position.Y + 1);
                    playerPos = new Position(player.Position.X, player.Position.Y);
                    playerInFrontPos = new Position(player.Position.X, player.Position.Y - 1);
                    UpdateViewButtons(playerBehindPos, playerPos, playerInFrontPos);
                    break;
                case Direction.Down:
                    _game.Move(direction);
                    player = _game.LevelStorage.CurrentLevel.GetPlayer();
                    playerBehindPos = new Position(player.Position.X, player.Position.Y - 1);
                    playerPos = new Position(player.Position.X, player.Position.Y);
                    playerInFrontPos = new Position(player.Position.X, player.Position.Y + 1);
                    UpdateViewButtons(playerBehindPos, playerPos, playerInFrontPos);
                    break;
                case Direction.Right:
                    _game.Move(direction);
                    player = _game.LevelStorage.CurrentLevel.GetPlayer();
                    playerBehindPos = new Position(player.Position.X - 1, player.Position.Y);
                    playerPos = new Position(player.Position.X, player.Position.Y);
                    playerInFrontPos = new Position(player.Position.X + 1, player.Position.Y);
                    UpdateViewButtons(playerBehindPos, playerPos, playerInFrontPos);
                    break;
                case Direction.Left:
                    _game.Move(direction);
                    player = _game.LevelStorage.CurrentLevel.GetPlayer();
                    playerBehindPos = new Position(player.Position.X + 1, player.Position.Y);
                    playerPos = new Position(player.Position.X, player.Position.Y);
                    playerInFrontPos = new Position(player.Position.X - 1, player.Position.Y);
                    UpdateViewButtons(playerBehindPos, playerPos, playerInFrontPos);
                    break;
            }

        }

        public void RestartCurrentLevel()
        {
            _game.Restart();
            PurgeLevelButtons();
            GenerateLevelButtons(_game.LevelStorage.CurrentLevel);
        }

        private void UpdateViewButtons(Position behindPos, Position currentPos, Position inFrontPos) 
        {
            // Getting Square Parts at certain positions
            var squarePartBehind = _game.LevelStorage.CurrentLevel.GetPartAtIndex(behindPos.X, behindPos.Y);
            var squarePart = _game.LevelStorage.CurrentLevel.GetPartAtIndex(currentPos.X, currentPos.Y);
            var squarePartInFront = _game.LevelStorage.CurrentLevel.GetPartAtIndex(inFrontPos.X, inFrontPos.Y);
            // Getting Buttons at certain positions
            var playerButtonBehind = _view.GetButtonAtIndex(behindPos.X, behindPos.Y);
            var playerButton = _view.GetButtonAtIndex(currentPos.X, currentPos.Y);
            var playerButtonInFront = _view.GetButtonAtIndex(inFrontPos.X, inFrontPos.Y);
            _view.ChangeButton(playerButtonBehind, squarePartBehind);
            _view.ChangeButton(playerButton, squarePart);
            _view.ChangeButton(playerButtonInFront, squarePartInFront);
        }

        private void GenerateLevelButtons(Level level)
        {
            foreach (var square in level.LevelData)
            {
                CreateButton((char)square.SquarePart, square.Position.X, square.Position.Y);
            }
        }

        private void PurgeLevelButtons() 
        {
            for (int width = 0; width < _game.LevelStorage.CurrentLevel.Width; ++width) 
            {
                for (int height = 0; height < _game.LevelStorage.CurrentLevel.Height; ++height) 
                {
                    _view.RemoveButton("btn_" + width + "_" + height);
                }
            }
        }

        private void CreateButton(char squareName, int row, int column)
        {
            Button button = new();
            button.Name = "btn_" + row.ToString() + "_" + column.ToString();
            button.Height = 50;
            button.Width = 50;
            button.Text = squareName.ToString();
            button.Font = new Font("Arial", 20);
            button.Visible = true;
            button.Click += new System.EventHandler(this.SquareButtonClick);

            _view.AddButton(button, row, column);
        }

        private void SquareButtonClick(object sender, EventArgs e) 
        {
            Button btn = sender as Button;
            Form1 view = _view as Form1;
            view.ButtonNameLabel.Text = btn.Name;
        }
    }
}

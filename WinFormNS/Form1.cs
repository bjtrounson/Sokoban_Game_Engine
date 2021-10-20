using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseNS;

namespace WinFormNS
{
    public partial class Form1 : Form, IGameView
    {
        private GameController _gameCtrl;
        public Label ButtonNameLabel;

        public Form1()
        {
            InitializeComponent();
            ButtonNameLabel = (Label) Controls.Find("label2", true)[0];
        }

        public void SetController(GameController gameController) 
        {
            _gameCtrl = gameController;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            _gameCtrl.MoveCharacter(Direction.Left);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            _gameCtrl.MoveCharacter(Direction.Down);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            _gameCtrl.MoveCharacter(Direction.Right);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            _gameCtrl.MoveCharacter(Direction.Up);
        }

        private void createLevelButton_Click(object sender, EventArgs e)
        {
            _gameCtrl.CreateLevel();
        }

        private void restartLevelButton_Click(object sender, EventArgs e)
        {
            _gameCtrl.RestartCurrentLevel();
        }

        public void AddButton(Button button, int gridX, int gridY) 
        {
            var margin = 10;
            button.Location = new Point(margin + button.Width * gridX, margin + button.Height * gridY);
            Controls.Add(button);
        }

        public void RemoveButton(string btnName) 
        {
            Controls.RemoveByKey(btnName);
        }

        public Button GetButtonAtIndex(int gridX, int gridY)
        {
            Control control = Controls.Find("btn_" + gridX + "_" + gridY, true)[0];
            Button button = control as Button;
            return button;
        }

        public void ChangeButton(Button button, Part squarePart)
        {
            button.Text = ((char)squarePart).ToString();
        }
    }
}

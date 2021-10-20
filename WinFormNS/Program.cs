using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameNS;

namespace WinFormNS
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frmMain = new();
            Game game = new(new LevelStorage());
            GameController gameCtrl = new(game, frmMain);
            frmMain.SetController(gameCtrl);
            Application.Run(frmMain);
        }
    }
}

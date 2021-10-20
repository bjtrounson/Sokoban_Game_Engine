using BaseNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormNS
{
    public interface IGameView
    {
        Button GetButtonAtIndex(int gridX, int gridY);
        void ChangeButton(Button button, Part squarePart);
        void AddButton(Button button, int gridX, int gridY);
        void RemoveButton(string btnName);
    }
}

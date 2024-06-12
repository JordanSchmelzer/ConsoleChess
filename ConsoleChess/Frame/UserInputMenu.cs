using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class UserInputMenu
    {
        private int SelectedIndex;
        private string Prompt;
        private string[] Options;

        public UserInputMenu(string prompt, string[] options)
        {
            this.Prompt = prompt;
            this.Options = options;
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            return 0;
        }

        private void DisplayRender()
        {

        }

        private void DisplayOptions()
        {

        }
    }
}

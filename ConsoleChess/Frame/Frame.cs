using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Frame
    {
        public int x;
        public int y;

        public Frame() 
        {

        }
        public void SetupNextLine()
        {
            // Prevents color from leaking to the right of tile
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                                                ");
            // Shift to next line
            Console.Write('\n');
        }

    }
}

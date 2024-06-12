using System;
using static System.Console;

namespace ConsoleChess
{
    public class Menu
    {
        private int SelectedIndex;
        private string Prompt;
        private string[] Options;

        public Menu(string prompt, string[] options)
        {
            this.Prompt = prompt;
            this.Options = options;
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update SelectedIndex based on arrow keys.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1; 
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

        private void DisplayOptions()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(Prompt);
            ResetColor();
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if(i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
            ForegroundColor = ConsoleColor.DarkYellow;
            string footerDecoration = @"

                     ,....,
                  ,::::::<
                 ,::/^\""``.
                ,::/, `   e`.
               ,::; |        '.
               ,::|  \___,-.  c)
               ;::|     \   '-'
               ;::|      \
               ;::|   _.=`\
               `;:|.=` _.=`\
                 '|_.=`   __\
                 `\_..==`` /
                  .'.___.-'.
                 /          \
            jgs ('--......--')
                /'--......--'\
                `""--......--""
            Knight by Joan G. Stark
";
            WriteLine("\nw\n\n"+footerDecoration);

            ResetColor();
        }
    }
}

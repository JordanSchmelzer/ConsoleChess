using System;
using static System.Console;

namespace ConsoleChess
{
    internal class GameMenu
    {
        private int SelectedIndex;
        private string Prompt;
        private string[] Options;

        public GameMenu(string prompt, string[] options)
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
                // Draw the game board

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

                if (i == SelectedIndex)
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
        }
    }
}


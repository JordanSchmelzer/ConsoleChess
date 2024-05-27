﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    internal class Program 
    {

        public static World world = new World();
    
        public static void Main(string[] args)
        {
            StartUp();
            //StartMenu();
            Draw();
            GameOver();
        }

        public static void StartUp() 
        { 
            Console.Clear();
        }

        public static void GameOver() 
        {
            string[] lines = new string[] { "Thanks for playing!", "Press any key to exit" };

            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }

        public static void StartMenu()
        {
            // Draw the Gui, wait for selection
            string[] lines = new string[] { "Welcome to Console Chess!", "", "Play", "Exit" };

            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }

        public static void Draw()
        {
            // Draw row
            for (int row = 0; row < World.Size; row++) 
            {
                // Draws a each column in row
                for (int col = 0; col < World.Size; col++)
                {
                    world.GetTile(row, col).type.Render();
                }
                SetupNextLine();
            }
        }

        public static void SetupNextLine()
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

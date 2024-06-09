using ConsoleChess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    internal class Program
    {
        public static GameBoard gameboard = new GameBoard();
        public static Game game = new Game(gameboard);
        public static Frame frame = new Frame(game);
        
        public static void Main(string[] args)
        {
            gameboard.frame = frame;
            Console.Title = "Console Chess v0.1";

            game.Initialize(new HumanPlayer(true),new HumanPlayer(false));
            gameboard.UpdateFrame();
            frame.Render();

            string userInput;
            while (true)
            {
                if (game.getStatus() == EnumGameStatus.FOREFIT) { Console.WriteLine("GG! I give up."); break; }

                userInput = Console.ReadLine().Trim();

                if(userInput == "r")
                {
                    Console.Clear();
                    // After these two lines the console is empty
                    // and the scrollbars are removed or disabled.
                    Console.WriteLine("\x1b[3J");
                    frame.Render();
                }
                if (userInput == "q!"){break;}
                if (userInput == "pass") { ; }
                if (userInput == "undo") { ; }
                if (userInput == "ff") { game.SetStatus(EnumGameStatus.FOREFIT); }
                if (userInput.Contains(" ")) 
                { 
                    game.MoveGamePieces(userInput);

                    Console.WriteLine("Confirm?");
                    Console.ReadLine();

                    game.gameBaord.UpdateFrame();

                    frame.Render(); 
                }
            }
        }
    }
}

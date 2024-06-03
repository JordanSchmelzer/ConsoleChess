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
        public static World world = new World();
        public static HumanPlayer p1 = new HumanPlayer(true);
        public static HumanPlayer p2 = new HumanPlayer(false);
        public static Game game = new Game(world);
        // public static Frame frame = new Frame();

        public static void Main(string[] args)
        {
            Console.Title = "Console Chess v0.1";
            InitializeGame();

            string userInput;
            while (true)
            {
                // Check game state
                if (game.getStatus() == EnumGameStatus.FOREFIT) { Console.WriteLine("GG! I give up."); break; }

                userInput = Console.ReadLine().Trim();
                // Refresh the screen
                if(userInput == "r")
                {
                    Console.Clear();
                    // After these two lines the console is empty and the scrollbars
                    // are removed or disabled. The cursor is on the second line (
                    // and there could be a few chars from the last input). To prevent
                    // that I called the clear command again.
                    Console.WriteLine("\x1b[3J");
                    DrawWorldToConsole();
                }
                // Exit the application
                if (userInput == "q!"){break;}
                // Pass the turn to the next player
                if (userInput == "pass") { ; }
                // Let the player retract the move if their turn
                if (userInput == "undo") { ; }
                // Let the player forefit
                if (userInput == "ff") { game.setStatus(EnumGameStatus.FOREFIT); }
                
                // Let the player move
                if (userInput.Contains(">"))
                {
                    MoveGamePieces(userInput);
                }
            }
        }
        public static void InitializeGame()
        {
            game.initialize(p1, p2);
            game.setStatus(EnumGameStatus.ACTIVE);
            Console.Clear();
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            UpdateTiles();
            DrawWorldToConsole();
        }
        public static int DecodeMoveCommand(string inputString)
        {
            if(int.TryParse(inputString, out int parsedValue))
            {
                return parsedValue;
            }
            else
            {
                switch (inputString)
                {
                    case "a": return 1;
                    case "b": return 2;
                    case "c": return 3;
                    case "d": return 4;
                    case "e": return 5;
                    case "f": return 6;
                    case "g": return 7;
                    case "h": return 8;
                    default: return 99;
                }
            }
        }
        public static void MoveGamePieces(string userInput)
        {
            try
            {
                int startX;
                int startY;
                int endX;
                int endY;

                string userInputStartY = Convert.ToString(userInput[0]);
                string userInputStartX = Convert.ToString(userInput[1]);
                string userInputEndY = Convert.ToString(userInput[3]);
                string userInputEndX = Convert.ToString(userInput[4]);

                startX = 8 - DecodeMoveCommand(userInputStartX);
                startY = DecodeMoveCommand(userInputStartY) -1;
                endX = 8 - DecodeMoveCommand(userInputEndX);
                endY = DecodeMoveCommand(userInputEndY) -1;

                if (game.playerMove(game.currentTurn, startX, startY, endX, endY))
                {
                    world.SetChessBoardSquareTiles();
                    UpdateTiles();
                    world.DrawBoardSquareCoordinates();
                    Console.Clear();
                    DrawWorldToConsole();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid Move! {userInput} is not valid.");
                }
            }
            catch
            {

            }
        }
        public static void UpdateTiles()
        {
            for (int i = 0; i < 8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    BoardSquare boardSquare = world.getBox(i, j);
                    if (boardSquare.getPiece() is Queen)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            world.DrawWhiteQueen(i * 8, j * 8);
                        }
                        else
                        {
                            world.DrawBlackQueen(i * 8, j * 8);
                        }
                    }

                    if (boardSquare.getPiece() is King)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            world.DrawWhiteKing(i * 8, j * 8, new Tile(TileTypes.Black), new Tile(TileTypes.White));
                        }
                        else
                        {
                            world.DrawBlackKing(i * 8, j * 8, new Tile(TileTypes.Black), new Tile(TileTypes.DarkGrey));
                        }
                    }

                    if (boardSquare.getPiece() is Pawn)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            world.DrawWhitePawn(i * 8, j * 8);
                        }
                        else
                        {
                            world.DrawBlackPawn(i * 8, j * 8);
                        }
                    }

                    if (boardSquare.getPiece() is Rook)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            world.DrawWhiteRook(i * 8, j * 8);
                        }
                        else
                        {
                            world.DrawBlackRook(i * 8, j * 8);
                        }
                    }

                    if (boardSquare.getPiece() is Bishop)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            world.DrawWhiteBishop(i * 8, j * 8);
                        }
                        else
                        {
                            world.DrawBlackBishop(i * 8, j * 8);
                        }
                    }

                    if (boardSquare.getPiece() is Knight)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            world.DrawWhiteKnight(i * 8, j * 8);
                        }
                        else
                        {
                            world.DrawBlackKnight(i * 8, j * 8);
                        }
                    }
                }
            }
        }
        public static void DrawWorldToConsole()
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
            // Prompt
            if (game.currentTurn.whiteSide)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It is white's turn to move");
            }
            else 
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It is black's turn to move"); 
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

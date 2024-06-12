using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Game
    {
        private GameRenderer gameRenderer;
        private GameBoard gameBoard;

        private Player[] players = new Player[2];
        public Player currentTurn;
        public EnumGameStatus gameStatus;
        public List<Move> movesPlayed = new List<Move>();
        public static HumanPlayer p1 = new HumanPlayer(true);
        public static HumanPlayer p2 = new HumanPlayer(false);

        public Game()
        {
            gameRenderer = new GameRenderer();
        }

        public EnumGameStatus Run()
        {
            Initialize(p1,p2);

            do
            {
                gameRenderer.Render(gameBoard);

                Console.ForegroundColor = ConsoleColor.White;
                if (currentTurn.whiteSide)
                {
                    Console.WriteLine("It's White's turn to move!");
                }
                else 
                {
                    Console.WriteLine("It's Black's turn to move!");
                }
                Console.WriteLine("Move Syntax: <Start Coordinates><SPACE><End Coordinates> [ex: b2 b4]");
                Console.WriteLine("Enter Move: ");
                string userInput = Console.ReadLine();

                // To do write a private bool to check if user input is valid
                //if()
                //{

                //}

                PlayerMove(currentTurn);
                SwitchActivePlayer();
            } while (this.gameStatus == EnumGameStatus.ACTIVE);

            return 0;
        }

        public void PlayerMove(Player player)
        {
            Console.WriteLine();

            BoardSquare startBox = gameBoard.GetBoardSquare(0, 0);
            BoardSquare endBox = gameBoard.GetBoardSquare(1, 0);

            Move move = new Move(player, startBox, endBox, gameBoard);
            //return this.MakeMove(move, player);
        }


        private void Initialize(Player p1, Player p2)
        {
            this.gameStatus = EnumGameStatus.ACTIVE;
            this.gameBoard = new GameBoard();

            players[0] = p1;
            players[1] = p2;

            if (p1.isWhiteSide())
            {
                this.currentTurn = p1;
            }
            else
            {
                this.currentTurn = p2;
            }
            movesPlayed.Clear();
        }
        public bool IsEnd()
        {
            return this.GetStatus() != EnumGameStatus.ACTIVE;
        }
        private EnumGameStatus GetStatus()
        {
            return this.gameStatus;
        }
        private void SetStatus(EnumGameStatus status)
        {
            this.gameStatus = status;
        }

        //public bool MoveGamePieces(string userInput)
        //{
        //    try
        //    {
        //        string userInputStartY = Convert.ToString(userInput[0]);
        //        string userInputStartX = Convert.ToString(userInput[1]);
        //        string userInputEndY = Convert.ToString(userInput[3]);
        //        string userInputEndX = Convert.ToString(userInput[4]);

        //        int startX = 8 - DecodeMoveCommand(userInputStartX);
        //        int startY = DecodeMoveCommand(userInputStartY) - 1;
        //        int endX = 8 - DecodeMoveCommand(userInputEndX);
        //        int endY = DecodeMoveCommand(userInputEndY) - 1;

        //        if (PlayerMove(currentTurn, startX, startY, endX, endY))
        //        {
        //            // TODO fix this, wasteful. Fix chain of bools goign on here
        //            BoardSquare startBox = gameBoard.GetBoardSquare(startX, startY);
        //            BoardSquare endBox = gameBoard.GetBoardSquare(endX, endY);

        //            Move move = new Move(currentTurn, startBox, endBox, gameBoard);

        //            move.PreviewMove(); // Set the boardsquare to preview mode

        //            //this.gameBaord.frame.Render();

        //            Console.ForegroundColor = ConsoleColor.White;
        //            Console.WriteLine("Confirm Move?");
        //            Console.ReadLine();

        //            move.Execute();
        //            move.ResetPreview(); // Set the boardsquare preview mode to false

        //            //this.gameBaord.frame.Render();

        //            return true;
        //        }
        //        else
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine($"Invalid Move! {userInput} is not valid.");
        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Error: {e}");
        //    }
        //    return false;
        //}


        private bool MakeMove(Move move, Player player)
        {
            IGamePiece sourcePiece = move.getStart().getPiece();

            // Disallow these actions
            if (sourcePiece == null)
            {
                Console.WriteLine("Invalid Move, try again!");
                return false;
            }
            if (player != currentTurn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It's not your turn to move a piece");
                return false;
            }
            if (sourcePiece.isWhite() != player.isWhiteSide())
            {
                Console.WriteLine("Invalid Move, you tried to move a piece that wasnt yours.");
                return false;
            }

            // Check Piece Type Move Specifics
            if (!sourcePiece.canMove(move, gameBoard))
            {
                return false;
            }

            return true;
        }

        private void SwitchActivePlayer()
        {
            if (this.currentTurn == players[0])
            {
                this.currentTurn = players[1];
            }
            else
            {
                this.currentTurn = players[0];
            }
        }
        private int DecodeMoveCommand(string inputString)
        {
            if (int.TryParse(inputString, out int parsedValue))
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
    }
}

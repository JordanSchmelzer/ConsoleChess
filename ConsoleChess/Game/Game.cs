using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleChess
{
    public class Game
    {
        private readonly ILogger<Game> _logger;

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
            //_logger = logger;
            gameRenderer = new GameRenderer();
            //_logger.LogDebug("Game Class Initialized - For testing purposes");
        }
        private void Initialize(Player p1, Player p2)
        {
            this.gameStatus = EnumGameStatus.ACTIVE;
            this.gameBoard = new GameBoard();
           
            this.gameBoard.ResetChessPiecesOnBoard();

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
        public EnumGameStatus Run()
        {
            Initialize(p1,p2);
            do
            {
                gameRenderer.Render(gameBoard);
                PrintUserInputMenu();

                string userInput = ReadLine();
                switch (ParseUserInputCommand(userInput.Trim()))
                {
                    case EnumUserCommandType.MOVE:
                        if (PlayerMove(userInput))
                        {
                            // if the move worked, is the game still going?
                            if (IsWhiteWin()) { return 0; }
                            if (IsBlackWin()) { return 0; }
                            SwitchActivePlayer();
                        }
                        break;

                    case EnumUserCommandType.INVALID:
                        break;

                    case EnumUserCommandType.FOREFIT:
                        WriteLine($"FF detected");
                        return 0;
                }
            } while (this.gameStatus == EnumGameStatus.ACTIVE);

            return 0;
        }
        private bool IsWhiteWin() 
        {
            List<IGamePiece> pieces = new List<IGamePiece>();
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if(gameBoard.GetBoardSquare(i, j).getPiece() is King)
                    {
                        pieces.Add(gameBoard.GetBoardSquare(i, j).getPiece());

                    }
                }
            }
            // if only the white king remains
            if (pieces.Count != 2 && pieces[0].isWhite() == true)
            {
                WriteLine("White wins");
                ReadKey(true);
                return true;
            }
            return false;
        }
        private bool IsBlackWin()
        {
            List<IGamePiece> pieces = new List<IGamePiece>();
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (gameBoard.GetBoardSquare(i, j).getPiece() is King)
                    {
                        pieces.Add(gameBoard.GetBoardSquare(i, j).getPiece());

                    }
                }
            }
            // if only the white king remains
            if (pieces.Count != 2 && pieces[0].isWhite() != true)
            {
                WriteLine("Black Wins");
                ReadKey(true);
                return true;
            }
            return false;
        }
        private void PrintUserInputMenu()
        {
            // Consider another object to manage this state
            ForegroundColor = ConsoleColor.Cyan;
            if (currentTurn.whiteSide)
            {
                WriteLine("[Turn] It's White's turn to move!");
            }
            else
            {
                WriteLine("[Turn] It's Black's turn to move!");
            }
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("[Move Syntax ] <Start Coordinates><SPACE><End Coordinates> [ex: b2 b4]");

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Enter Move:");
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
        public bool PlayerMove(string playerInput)
        {
            string userInputStartY = Convert.ToString(playerInput[0]);
            string userInputStartX = Convert.ToString(playerInput[1]);
            string userInputEndY = Convert.ToString(playerInput[3]);
            string userInputEndX = Convert.ToString(playerInput[4]);

            int startX = 8 - DecodeMoveCommand(userInputStartX);
            int startY = DecodeMoveCommand(userInputStartY) - 1;
            int endX = 8 - DecodeMoveCommand(userInputEndX);
            int endY = DecodeMoveCommand(userInputEndY) - 1;

            BoardSquare startBox = gameBoard.GetBoardSquare(startX, startY);
            BoardSquare endBox = gameBoard.GetBoardSquare(endX, endY);
            Move move = new Move(currentTurn, startBox, endBox, gameBoard);

            if (IsMyTurn(move) == false) { return false; }
            if (move.getStart().getPiece() == null)
            {
                return false;
            }
            if (move.getStart().getPiece().canMove(move))
            {
                move.PreviewMove();
                gameRenderer.Render(gameBoard);
                if (TakeBackMove(move)) { return false; }
                return true;
            }
            else
            {
                WriteLine($"Invalid move! {playerInput}");
                ReadLine();
                return false;
            }
        }

        private bool IsMyTurn(Move move)
        {
            if ( move.getStart().getPiece() != null)
            {
                if (currentTurn.isWhiteSide() != move.getStart().getPiece().isWhite())
                {
                    return false;
                }
            }
            return true;
        }
        private bool TakeBackMove(Move move)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Keep Move? (Press 'n' to undo or any key to keep)");

            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.N || keyPressed == ConsoleKey.U)
            {
                move.Undo();
                //gameRenderer.Render(gameBoard);
                move.ResetPreview();
                return true;
            }
            move.ResetPreview();
            return false;
        }
        private EnumUserCommandType ParseUserInputCommand(string userInput)
        {
            if (
                (userInput.Length == 5) &&
                (Char.IsLetter(userInput[0])) &&
                (Char.IsNumber(userInput[1])) &&
                (userInput[2] == ' ' ) &&
                (Char.IsLetter(userInput[3])) &&
                (Char.IsNumber(userInput[4]))
                )
            {
                return EnumUserCommandType.MOVE;
            }
            if (userInput == "ff")
            {
                this.SetStatus(EnumGameStatus.FOREFIT);
            }
            return EnumUserCommandType.INVALID;
        }
        private EnumGameStatus GetStatus()
        {
            return this.gameStatus;
        }
        private void SetStatus(EnumGameStatus status)
        {
            this.gameStatus = status;
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
    }
}

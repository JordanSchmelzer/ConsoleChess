using System;
using System.Collections.Generic;
using static System.Console;

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
            string gameMessage = "";
            do
            {
                gameRenderer.Render(gameBoard);

                ForegroundColor = ConsoleColor.Cyan;
                if (currentTurn.whiteSide)
                {
                    WriteLine("[Turn] It's White's turn to move!");
                }
                else 
                {
                    WriteLine("[Turn] It's Black's turn to move!");
                }
                ForegroundColor = ConsoleColor.White;
                WriteLine($"[Game Message]: {gameMessage}");
                ForegroundColor = ConsoleColor.Gray;
                WriteLine("[Move Syntax ] <Start Coordinates><SPACE><End Coordinates> [ex: b2 b4]");
                ForegroundColor= ConsoleColor.Green;
                WriteLine("Enter Move:");

                string userInput = ReadLine();

                switch (ParseUserInputCommand(userInput.Trim()))
                {
                    case EnumUserCommandType.MOVE:
                        if (PlayerMove(userInput))
                        {
                            gameMessage = $"Move accepted: {userInput}";
                            SwitchActivePlayer();
                        }
                        break;

                    case EnumUserCommandType.INVALID:
                        gameMessage = "Input not recognized as command.";
                        break;

                }
            } while (this.gameStatus == EnumGameStatus.ACTIVE);

            return 0;
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
            if (userInput == "quit")
            {
                this.SetStatus(EnumGameStatus.FOREFIT);
            }
            return EnumUserCommandType.INVALID;
        }
        public bool PlayerMove(string playerInput)
        {
            WriteLine($"Log! Move {playerInput}");

            // Janky but it'll do!
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

            if (move.getStart().getPiece() == null)
            {
                return false;
            }

            if (move.getStart().getPiece().canMove(move))
            {
                move.PreviewMove();
                gameRenderer.Render(gameBoard);

                ForegroundColor = ConsoleColor.Green;
                WriteLine("Keep Move? (Press 'n' to undo or any key to keep)");

                ConsoleKey keyPressed;
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.N)
                {
                    move.Undo();
                    gameRenderer.Render(gameBoard);
                    ForegroundColor= ConsoleColor.Green;
                    WriteLine("Move undone! Press any key to continue...");
                    ReadKey(true);
                    return false;
                }
                // Leave the move rendered on the board
                move.ResetPreview();

                return true;
            }
            else
            {
                WriteLine($"Invalid move! {playerInput}");
                ReadLine();
                return false;
            }
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

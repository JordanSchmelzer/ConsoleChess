using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Game
    {
        private Player[] players = new Player[2];
        public GameBoard gameBaord;
        public Player currentTurn;
        private EnumGameStatus gameStatus;
        private List<Move> movesPlayed = new List<Move>();
        public static HumanPlayer p1 = new HumanPlayer(true);
        public static HumanPlayer p2 = new HumanPlayer(false);

        public Game(GameBoard gameBoard)
        {
            this.gameBaord = gameBoard;
        }

        public void Initialize(Player p1, Player p2)
        {
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
        public bool isEnd()
        {
            return this.getStatus() != EnumGameStatus.ACTIVE;
        }
        public EnumGameStatus getStatus()
        {
            return this.gameStatus;
        }
        public void SetStatus(EnumGameStatus status)
        {
            this.gameStatus = status;
        }

        public void MoveGamePieces(string userInput)
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
                startY = DecodeMoveCommand(userInputStartY) - 1;
                endX = 8 - DecodeMoveCommand(userInputEndX);
                endY = DecodeMoveCommand(userInputEndY) - 1;

                if (playerMove(currentTurn, startX, startY, endX, endY))
                {
                    //UpdateTiles();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid Move! {userInput} is not valid.");
                }
            }
            catch { }
        }

        public bool playerMove(Player player,
                               int startX,
                               int startY,
                               int endX,
                               int endY)
        {
            BoardSquare startBox = gameBaord.GetBoardSquare(startX, startY);
            BoardSquare endBox = gameBaord.GetBoardSquare(endX, endY);

            Move move = new Move(player, startBox, endBox, gameBaord);
            return this.MakeMove(move, player);
        }

        private bool MakeMove(Move move, Player player)
        {
            IGamePiece sourcePiece = move.getStart().getPiece();

            if (sourcePiece == null)
            {
                Console.WriteLine("Invalid Move, try again!");
                return false;
            }

            // valid player 
            if (player != currentTurn)
            {
                Console.WriteLine("It's not your turn to move a piece");
                return false;
            }

            if (sourcePiece.isWhite() != player.isWhiteSide())
            {
                Console.WriteLine("Invalid Move, you tried to move a piece that wasnt yours.");
                return false;
            }

            // valid move for piece? 
            if (!sourcePiece.canMove(move, gameBaord))
            {
                return false;
            }

            // Make the move
            move.getEnd().setPiece(sourcePiece);
            move.getStart().setPiece(null);

            // set the current turn to the other player 
            if (this.currentTurn == players[0]){this.currentTurn = players[1];}
            else{this.currentTurn = players[0];}
           
            return true;
        }

        public int DecodeMoveCommand(string inputString)
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

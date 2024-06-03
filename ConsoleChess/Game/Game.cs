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
        private World world;
        public Player currentTurn;
        private EnumGameStatus gameStatus;
        private List<Move> movesPlayed = new List<Move>();

        public Game(World world)
        {
            this.world = world;
        }

        public void initialize(Player p1, Player p2)
        {
            players[0] = p1;
            players[1] = p2;

            //world.resetBoard();

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

        public void setStatus(EnumGameStatus status)
        {
            this.gameStatus = status;
        }

        public bool playerMove(Player player,
                               int startX,
                               int startY,
                               int endX,
                               int endY)
        {
            BoardSquare startBox = world.getBox(startX, startY);
            BoardSquare endBox = world.getBox(endX, endY);
            Move move = new Move(player, startBox, endBox);
            return this.makeMove(move, player);
        }

        private bool makeMove(Move move, Player player)
        {
            //move.getEnd().setPiece(move.getStart().getPiece());
            //world.boxes[endX, endY].setPiece(move.getStart().getPiece());
            //move.getStart().setPiece(null);

            IGamePiece sourcePiece = move.getStart().getPiece();
            if (sourcePiece == null)
            {
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
                Console.WriteLine("Error, you tried to move a piece that wasnt yours.\n Move syntax is {startRow},{etartColumn}>{endRow},{endColumn}");
                return false;
            }

            // valid move? 
            if (!sourcePiece.canMove(this.world,
                                     move.getStart(),
                                     move.getEnd()))
            {
                return false;
            }

            // kill? 
            //IGamePiece destPiece = move.getStart().getPiece();
            //if (destPiece != null)
            //{
            //    destPiece.setKilled(true);
            //    move.setPieceKilled(destPiece);
            //}

            // castling? 
            //if (sourcePiece != null 
            //    && sourcePiece.isCastlingMove()) 
            //{
            //    move.setCastlingMove(true);
            //}

            // store the move 
            //movesPlayed.add(move);

            // move piece from the stat box to end box 
            move.getEnd().setPiece(move.getStart().getPiece());
            move.getStart().setPiece(null);

            //if (destPiece != null && destPiece instanceof King) {
            //    if (player.isWhiteSide())
            //    {
            //        this.setStatus(GameStatus.WHITE_WIN);
            //    }
            //    else
            //    {
            //        this.setStatus(GameStatus.BLACK_WIN);
            //    }
            //}

            // set the current turn to the other player 
            if (this.currentTurn == players[0])
            {
                this.currentTurn = players[1];
            }
            else
            {
                this.currentTurn = players[0];
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    internal class Pawn : IGamePiece
    {

        public Pawn(bool white) : base(white)
        {

        }

        override
        public bool canMove(Move move, GameBoard gameBaord)
        {
            // Does the target square have a piece of the same color as the moving piece? 
            // TODO fix this, i get null error
            if (move.getStart().getPiece().isWhite() == move.getEnd().getPiece().isWhite())
            {
                return false;
            }

            // Check if causes check
            // TODO: build this

            // Check forward movement
            if (move.player.isWhiteSide()) 
            {
                // white forward is negative GameRow
                if(move.deltaRow() > 0)
                {
                    return false;
                }
            }
            else
            {
                // black forward is positive GameRow
                if(move.deltaRow() < 0)
                {
                    return false;
                }

            }

            // If making a 2 square move north or south, determine if in starting position
            if ((Math.Abs(move.deltaRow()) == 2) && 
                (move.deltaCol() == 0))
            {
                if (!this.HasMoved())
                {
                    return true;
                }
            }

            // Check diagonal capture
            if (Math.Abs(move.deltaCol()) == 1 && 
                Math.Abs(move.deltaRow()) == 1 )
            {
                return true;
            }

            // Is en-passant?
            if (!move.getStart().getPiece().HasMoved())
            {
                if (Math.Abs(move.deltaRow()) == 2 && 
                    Math.Abs(move.deltaCol()) == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public override bool isCastlingMove(BoardSquare start, BoardSquare end, GameBoard g)
        {
            return false;
        }
    }
}

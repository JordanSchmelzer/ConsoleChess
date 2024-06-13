using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    class Knight: IGamePiece
    {
        public Knight(bool white) : base(white)
        {
            
        }

        override
        public bool canMove(Move move)
        {
            // Does the target square have a piece of the same color as the moving piece? 
            if (move.getEnd().getPiece() != null)
            {
                if (move.getStart().getPiece().isWhite() ==
                   (move.getEnd().getPiece().isWhite()))
                {
                    return false;
                }
            }

            // is this an L shaped move?
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();
            if (
                !(
                    ((Math.Abs(deltaRow) == 2 && Math.Abs(deltaCol) == 1)) 
                    ||
                    ((Math.Abs(deltaRow) == 1 && Math.Abs(deltaRow) == 2))
                  )
               )
            {
                return false;
            }

            // Check L capture
            if (move.getEnd().getPiece() != null)
            {
                Console.WriteLine("Log: Diagonal Capture Accepted");
                return true;
            }
            // If landing on null square allow this move
            if (move.getEnd().getPiece() == null)
            {
                Console.WriteLine("Log: Diagonal Move Accepted");
                return true;
            }

            return false;
        }
        public override bool isCastlingMove(Move move)
        {
            return false;
        }

    }
}

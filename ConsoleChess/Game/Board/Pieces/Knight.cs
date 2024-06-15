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
            IGamePiece endPiece = move.getEnd().getPiece();
            IGamePiece startPiece = move.getStart().getPiece();
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            // dont let player take their own piece
            if (endPiece != null)
            {
                if (endPiece.isWhite() == startPiece.isWhite())
                {
                    return false;
                }
            }

            // is this an L shaped move?
            if (absDeltaRow > 2 || absDeltaCol > 2) 
            {
                return false;
            }
            if (absDeltaRow < 1 || absDeltaRow < 1)
            {
                return false;
            }

            if ((absDeltaRow == 2 && absDeltaCol != 1) ||
               ((absDeltaRow) == 1 && absDeltaCol != 2))
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
            Console.WriteLine("Invalid Move! Reason: Not a recognized valid move.");
            return false;
        }
        public override bool isCastlingMove(Move move)
        {
            return false;
        }

    }
}

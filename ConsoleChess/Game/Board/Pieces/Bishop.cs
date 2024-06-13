using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    internal class Bishop : IGamePiece
    {

        public Bishop(bool white) : base(white)
        {

        }
        override
        public bool canMove(Move move)
        {
            // Check if causes check
            // TODO: build this

            // Does the target square have a piece of the same color as the moving piece? 
            if (move.getEnd().getPiece() != null)
            {
                if (move.getStart().getPiece().isWhite() ==
                   (move.getEnd().getPiece().isWhite()))
                {
                    return false;
                }
            }

            // enforce diagonal move
            if (move.direction == EnumMoveDirections.NORTH ||
                move.direction == EnumMoveDirections.EAST ||
                move.direction == EnumMoveDirections.SOUTH ||
                move.direction == EnumMoveDirections.WEST)
            {
                return false;
            }

            // check if the diagonal move intersects any pieces
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();

            if (Math.Abs(deltaRow) > 1 && Math.Abs(deltaCol) > 1)
            {
                int startRow = move.getStart().getGameRow();
                int startCol = move.getStart().getGameCol();

                int rowIterator = 0;
                int colIterator = 0;

                if (move.direction == EnumMoveDirections.NORTHEAST)
                {
                    rowIterator = -1;
                    colIterator = 1;
                }
                if (move.direction == EnumMoveDirections.SOUTHEAST)
                {
                    rowIterator = 1;
                    colIterator = 1;
                }
                if (move.direction == EnumMoveDirections.SOUTHWEST)
                {
                    rowIterator = 1;
                    colIterator = -1;
                }
                if (move.direction == EnumMoveDirections.NORTHWEST)
                {
                    rowIterator = -1;
                    colIterator = -1;
                }

                for (int i = 0; i < (deltaRow - 1); i++)
                {
                    BoardSquare nextDiagonalBoardSquare =
                        move.gameBoard.boardSquare[startRow + rowIterator,startCol + colIterator];
                    if (nextDiagonalBoardSquare.getPiece() != null)
                    {
                        return false;
                    }
                }
            }

            // Check diagonal capture
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
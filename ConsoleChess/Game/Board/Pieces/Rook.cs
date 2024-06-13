using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    internal class Rook: IGamePiece
    {
        public Rook(bool white) : base(white)
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

            // Check if causes check
            // TODO: build this

            // enforce move directions
            if (move.direction == EnumMoveDirections.NORTHEAST ||
                move.direction ==EnumMoveDirections.SOUTHEAST ||
                move.direction == EnumMoveDirections.SOUTHWEST ||
                move.direction == EnumMoveDirections.NORTHWEST)
            {
                return false;
            }

            // check if the ordinal move intersects any pieces
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol(); 

            if (Math.Abs(deltaRow) > 1 && Math.Abs(deltaCol) > 1) 
            {
                int startRow = move.getStart().getGameRow();
                int startCol = move.getStart().getGameCol();

                int rowIterator = 0;
                int colIterator = 0;

                if (move.direction == EnumMoveDirections.NORTH)
                {
                    rowIterator = -1;
                    colIterator = 0;
                }
                if (move.direction == EnumMoveDirections.EAST)
                {
                    rowIterator = 0;
                    colIterator = 1;
                }
                if (move.direction == EnumMoveDirections.SOUTH)
                {
                    rowIterator = 1;
                    colIterator = 0;
                }
                if (move.direction == EnumMoveDirections.WEST)
                {
                    rowIterator = 0;
                    colIterator = -1;
                }

                for (int i = 0; i < move.deltaRow(); i++)
                {
                    BoardSquare nextDiagonalBoardSquare = 
                        move.gameBoard.boardSquare[startRow + rowIterator,
                                                startCol + colIterator];
                    if (nextDiagonalBoardSquare.getPiece() != null)
                    {
                        return false;
                    }
                }
            }

            // Check ordinal capture
            if ((move.getEnd().getPiece() != null))
            {
                Console.WriteLine("Log: Ordinal Capture Accepted");
                return true;
            }

            // If landing on null square allow this move
            if (move.getEnd().getPiece() == null) 
            {
                Console.WriteLine("Log: Ordinal Move Accepted");
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

using System;

namespace ConsoleChess.Pieces
{
    public class Queen : IGamePiece
    {
        public Queen(bool white) : base(white) { }
        
        public override bool CanMove(Move move) {
            if (IsTargetMyOwnPiece(move) == true) {
                return false;
            }

            // What kind of move is it?
            if (move._direction == EnumMoveDirections.NORTH || move._direction == EnumMoveDirections.EAST ||
                move._direction == EnumMoveDirections.SOUTH || move._direction == EnumMoveDirections.WEST) {
                return IsValidOrdinal(move);
            }
            else {
                return IsValidDiagonal(move);
            }
        }
        private bool IsValidDiagonal(Move move) {
            IGamePiece endPiece = move.getEnd().getPiece();
            int deltaRow = move.DeltaRow();
            int deltaCol = move.DeltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            //  Diagonal moves are always an equal ratio
            if (absDeltaRow == 0 || absDeltaCol == 0) {
                return false; 
            }

            if (absDeltaRow / absDeltaCol != 1) { 
                return false; 
            }

            // set the vector of motion
            int rowIterator = 0;
            int colIterator = 0;

            if (move._direction == EnumMoveDirections.NORTHEAST) {
                rowIterator = -1;
                colIterator = 1;
            }
            if (move._direction == EnumMoveDirections.SOUTHEAST) {
                rowIterator = 1;
                colIterator = 1;
            }
            if (move._direction == EnumMoveDirections.SOUTHWEST) {
                rowIterator = 1;
                colIterator = -1;
            }
            if (move._direction == EnumMoveDirections.NORTHWEST) {
                rowIterator = -1;
                colIterator = -1;
            }

            // Are there any pieces in the way of this move?
            int startRow = move.getStart().GameCol;
            int startCol = move.getStart().GameRow;
            for (int i = 1; i < absDeltaCol; i++) {
                int shiftRow = rowIterator * i;
                int shiftCol = colIterator * i;
                int nextRow = shiftRow + startRow;
                int nextCol = shiftCol + startCol;

                BoardSquare boardSquare = move._gameBoard.GetBoardSquare(nextRow, nextCol);

                if (boardSquare.getPiece() != null) {
                    return false;
                }
            }

            // This is a capture move
            if (endPiece != null) {
                return true;
            }

            // this is a move
            if (endPiece == null) {
                return true;
            }

            return false;
        }
        private bool IsValidOrdinal(Move move)
        {
            int deltaRow = move.DeltaRow();
            int deltaCol = move.DeltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            if (move._direction == EnumMoveDirections.NORTH || move._direction == EnumMoveDirections.EAST ||
                move._direction == EnumMoveDirections.SOUTH || move._direction == EnumMoveDirections.WEST)
            {
                // one coordinate vector has to be 0
                if ((absDeltaRow > 1 && absDeltaCol != 0) ||
                    (deltaRow != 0 && absDeltaCol > 1))
                {
                    return false;
                }

                // set the vector of motion
                int rowIterator = 0;
                int colIterator = 0;

                if (move._direction == EnumMoveDirections.NORTH)
                {
                    rowIterator = -1;
                    colIterator = 0;
                }
                if (move._direction == EnumMoveDirections.EAST)
                {
                    rowIterator = 0;
                    colIterator = 1;
                }
                if (move._direction == EnumMoveDirections.SOUTH)
                {
                    rowIterator = 1;
                    colIterator = 0;
                }
                if (move._direction == EnumMoveDirections.WEST)
                {
                    rowIterator = 0;
                    colIterator = -1;
                }

                // Gameboard layout example:
                // Top Left Black Rook gameboard[0,0]
                // Bottom Right White Rook gameboard[7,7]

                // Are there any pieces in the way of this move?
                int startRow = move.getStart().getGameCol();
                int startCol = move.getStart().getGameRow();

                // ROW
                for (int i = 1; i < absDeltaRow; i++)
                {
                    int shiftRow = rowIterator * i;
                    int nextRow = shiftRow + startRow;


                    BoardSquare adjacentBoardSquare =
                        move._gameBoard.boardSquare[nextRow, startCol];


                    if (adjacentBoardSquare.getPiece() != null)
                    {
                        return false;
                    }
                }
                // COLUMN
                for (int i = 1; i < absDeltaCol; i++)
                {
                    int shiftCol = colIterator * i;
                    int nextCol = shiftCol + startCol;


                    BoardSquare adjacentBoardSquare =
                        move._gameBoard.boardSquare[startRow, nextCol];


                    if (adjacentBoardSquare.getPiece() != null)
                    {
                        return false;
                    }
                }

                // Check ordinal capture
                if ((move.getEnd().piece != null))
                {
                    return true;
                }
                // If landing on null square allow this move
                if (move.getEnd().piece == null)
                {
                    return true;
                }
    
                return false;
            }
            return false;
        }
        private bool IsTargetMyOwnPiece(Move move)
        {
            IGamePiece endPiece = move.getEnd().getPiece();
            IGamePiece startPiece = move.getStart().getPiece();

            if (endPiece != null)
            {
                if (endPiece.isWhite() == startPiece.isWhite())
                {
                    return true;
                }
            }
            return false;
        }
    }
}

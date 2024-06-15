using System;

namespace ConsoleChess
{
    public class King : IGamePiece
    {
        private bool castlingDone =false;
        private GameBoard board;

        public King(bool white) : base(white)
        {
            //this.board = board;
        }

        override
        public bool canMove(Move move)
        {
            if (IsTargetMyOwnPiece(move) == true) { return false; }

            // What kind of move is it?
            if (move.direction == EnumMoveDirections.NORTH || move.direction == EnumMoveDirections.EAST ||
                move.direction == EnumMoveDirections.SOUTH || move.direction == EnumMoveDirections.WEST)
            {
                return IsValidOrdinal(move);
            }
            else
            {
                return IsValidDiagonal(move);
            }
        }

        private bool IsValidOrdinal(Move move)
        {
            // ordinal move rules
            if (move.direction == EnumMoveDirections.NORTH || move.direction == EnumMoveDirections.EAST ||
                move.direction == EnumMoveDirections.SOUTH || move.direction == EnumMoveDirections.WEST)
            {
                // check if the diagonal move intersects any pieces
                int deltaRow = move.deltaRow();
                int deltaCol = move.deltaCol();

                if (Math.Abs(deltaRow) == 1 && Math.Abs(deltaCol) == 1)
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

            }
            if (IsValidCapture(move)) { return true; }
            if (IsValidMove(move)) { return true; }

            return false;
        }
        private bool IsValidDiagonal(Move move)
        {
            // Diagonal Move Rules
            if (move.direction == EnumMoveDirections.NORTHEAST ||
                move.direction == EnumMoveDirections.SOUTHEAST ||
                move.direction == EnumMoveDirections.SOUTHWEST ||
                move.direction == EnumMoveDirections.NORTHWEST)
            {
                // check if the diagonal move intersects any pieces
                int deltaRow = move.deltaRow();
                int deltaCol = move.deltaCol();

                if (Math.Abs(deltaRow) == 1 && Math.Abs(deltaCol) == 1)
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
                        BoardSquare nextDiagonalBoardSquare = move.gameBoard.boardSquare[startRow + rowIterator,
                                                                                         startCol + colIterator];
                        if (nextDiagonalBoardSquare.getPiece() != null)
                        {
                            return false;
                        }
                    }
                }
            }

            if (IsValidCapture(move)) { return true; }
            if (IsValidMove(move)) { return true; }

            return false;
        }
        private bool IsValidMove(Move move)
        {
            // If landing on null square allow this move
            if (move.getEnd().getPiece() == null)
            {
                Console.WriteLine("Log: Diagonal Move Accepted");
                return true;
            }
            return false;
        }
        private bool IsValidCapture(Move move)
        {
            // Check capture
            if (move.getEnd().getPiece() != null)
            {
                Console.WriteLine("Log: Diagonal Capture Accepted");
                return true;
            }

            return false;
        }
        public bool isCastlingDone()
        {
            return this.castlingDone = true;
        }
        private bool isValidCastling(Move move)
        {
            if (this.isCastlingDone())
            {
                return false;
            }
            // Logic for returning true or false
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
        public override bool isCastlingMove(Move move)
        {
            // check if the starting and ending positin are correct
            //return this.isValidCastling(this.board, move.getStart(), move.getEnd());
            return false;
        }
    }
}
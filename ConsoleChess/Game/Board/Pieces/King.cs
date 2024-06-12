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
        public bool canMove(Move move, GameBoard gameBoard)
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

            // ordinal move rules
            if (move.direction == EnumMoveDirections.NORTH ||
                move.direction == EnumMoveDirections.EAST ||
                move.direction == EnumMoveDirections.SOUTH ||
                move.direction == EnumMoveDirections.WEST)
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
                            gameBoard.boardSquare[startRow + rowIterator,
                                                    startCol + colIterator];
                        if (nextDiagonalBoardSquare.getPiece() != null)
                        {
                            return false;
                        }
                    }
                }

            }

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
                        BoardSquare nextDiagonalBoardSquare =
                            gameBoard.boardSquare[startRow + rowIterator, startCol + colIterator];
                        if (nextDiagonalBoardSquare.getPiece() != null)
                        {
                            return false;
                        }
                    }
                }

            }

            // Check capture
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

        public bool isCastlingDone()
        {
            return this.castlingDone = true;
        }

        private bool isValidCastling(GameBoard world,
                                     BoardSquare start,
                                     BoardSquare end)
        {
            if (this.isCastlingDone())
            {
                return false;
            }
            // Logic for returning true or false
            return false;
        }

        public override bool isCastlingMove(BoardSquare start, BoardSquare end, GameBoard g)
        {
            // check if the starting and ending positin are correct
            return this.isValidCastling(this.board, start, end);
        }
    }
}

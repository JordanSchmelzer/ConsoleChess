using ConsoleChess.Pieces;
using System;

namespace ConsoleChess
{
    public class King : IGamePiece
    {
        //private bool castlingDone =false;
        //private GameBoard board;

        public King(bool white) : base(white)
        {
            //this.board = board;
        }

        override
        public bool canMove(Move move)
        {
            if (IsTargetMyOwnPiece(move) == true) { return false; }

            // Is this a castle?
            if (!this.HasMoved() && Math.Abs(move.deltaCol()) == 2)
            {
                if (move._direction == EnumMoveDirections.WEST)
                {
                    if (move._player.isWhiteSide())
                    {
                        BoardSquare rookBoardSquare = move._gameBoard.GetBoardSquare(0,7);
                        if (rookBoardSquare.getPiece() is Rook &&
                            rookBoardSquare.piece.HasMoved() == false && 
                            move._gameBoard.GetBoardSquare(7,1).getPiece() == null &&
                            move._gameBoard.GetBoardSquare(7,2).getPiece() == null &&
                            move._gameBoard.GetBoardSquare(7,3).getPiece() == null)
                        {
                            move._isCastle = true;
                            return true;
                        }
                    }
                    else
                    {
                        BoardSquare rookBoardSquare = move._gameBoard.GetBoardSquare(0,0);
                        if (rookBoardSquare.getPiece() is Rook &&
                            rookBoardSquare.piece.HasMoved() == false &&
                            move._gameBoard.GetBoardSquare(0,1).getPiece() == null &&
                            move._gameBoard.GetBoardSquare(0,2).getPiece() == null &&
                            move._gameBoard.GetBoardSquare(0,3).getPiece() == null)
                        {
                            move._isCastle = true;
                            return true;
                        }
                    }
                }
                else if (move._direction == EnumMoveDirections.EAST)
                {
                    if (move._player.isWhiteSide())
                    {
                        BoardSquare rookBoardSquare = move._gameBoard.GetBoardSquare(7,7);
                        if (rookBoardSquare.getPiece() is Rook &&
                            rookBoardSquare.piece.HasMoved() == false &&                            
                            move._gameBoard.GetBoardSquare(7, 5).getPiece() == null &&
                            move._gameBoard.GetBoardSquare(7, 6).getPiece() == null)
                        {
                            move._isCastle = true;
                            return true;
                        }
                    }
                    else
                    {
                        BoardSquare rookBoardSquare = move._gameBoard.GetBoardSquare(7,0);
                        if (rookBoardSquare.getPiece() is Rook &&
                            rookBoardSquare.piece.HasMoved() == false &&
                            move._gameBoard.GetBoardSquare(0, 5).getPiece() == null &&
                            move._gameBoard.GetBoardSquare(0, 6).getPiece() == null)
                        {
                            move._isCastle = true;
                            return true;
                        }
                    }
                }
            }

            // What kind of move is it?
            if (move._direction == EnumMoveDirections.NORTH || move._direction == EnumMoveDirections.EAST ||
                move._direction == EnumMoveDirections.SOUTH || move._direction == EnumMoveDirections.WEST)
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
            if (move._direction == EnumMoveDirections.NORTH || move._direction == EnumMoveDirections.EAST ||
                move._direction == EnumMoveDirections.SOUTH || move._direction == EnumMoveDirections.WEST)
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

                    for (int i = 0; i < move.deltaRow(); i++)
                    {
                        BoardSquare nextDiagonalBoardSquare =
                            move._gameBoard.boardSquare[startRow + rowIterator,
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
            if (move._direction == EnumMoveDirections.NORTHEAST ||
                move._direction == EnumMoveDirections.SOUTHEAST ||
                move._direction == EnumMoveDirections.SOUTHWEST ||
                move._direction == EnumMoveDirections.NORTHWEST)
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

                    if (move._direction == EnumMoveDirections.NORTHEAST)
                    {
                        rowIterator = -1;
                        colIterator = 1;
                    }
                    if (move._direction == EnumMoveDirections.SOUTHEAST)
                    {
                        rowIterator = 1;
                        colIterator = 1;
                    }
                    if (move._direction == EnumMoveDirections.SOUTHWEST)
                    {
                        rowIterator = 1;
                        colIterator = -1;
                    }
                    if (move._direction == EnumMoveDirections.NORTHWEST)
                    {
                        rowIterator = -1;
                        colIterator = -1;
                    }

                    for (int i = 0; i < (deltaRow - 1); i++)
                    {
                        BoardSquare nextDiagonalBoardSquare = move._gameBoard.boardSquare[startRow + rowIterator,
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
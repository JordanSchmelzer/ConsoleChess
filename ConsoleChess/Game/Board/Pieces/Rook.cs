﻿using System;

namespace ConsoleChess.Pieces
{
    internal class Rook : IGamePiece
    {
        public Rook(bool white) : base(white) { }

        override
        public bool canMove(Move move)
        {
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            // dont let player take their own piece
            if (IsTargetMyOwnPiece(move) == true) { return false; }

            // Only allow North East South West
            if (move.direction == EnumMoveDirections.NORTHEAST || move.direction == EnumMoveDirections.SOUTHEAST ||
                move.direction == EnumMoveDirections.SOUTHWEST || move.direction == EnumMoveDirections.NORTHWEST)
            {
                return false;
            }

            // one coordinate vector has to be 0
            if ((absDeltaRow > 1 && absDeltaCol != 0) ||
                (deltaRow != 0 && absDeltaCol > 1))
            {
                return false;
            }

            if (IsPathToEndSquareClear(move) == false) { return false; }
            if (IsValidMove(move)) { return true; }
            if (IsValidCapture(move)) { return true; }

            Console.WriteLine("Invalid Move! Reason: Not a recognized valid move.");
            return false;
        }
        private bool IsPathToEndSquareClear(Move move)
        {
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

            // Gameboard layout example:
            // Top Left Black Rook gameboard[0,0]
            // Bottom Right White Rook gameboard[7,7]

            // Are there any pieces in the way of this move?
            int startRow = move.getStart().getGameCol();
            int startCol = move.getStart().getGameRow();
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            // ROW
            for (int i = 1; i < absDeltaRow; i++)
            {
                int shiftRow = rowIterator * i;
                int nextRow = shiftRow + startRow;

                Console.WriteLine($"Move Multiplier: {i}; Shifting row {shiftRow}; shifting column {startCol}");

                BoardSquare adjacentBoardSquare =
                    move.gameBoard.boardSquare[nextRow, startCol];

                Console.WriteLine($"gameBoard Row {nextRow}; gameBoard Col {startCol}; Piece {adjacentBoardSquare.piece}; IsWhite ");

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

                Console.WriteLine($"Move Multiplier: {i}; Shifting row {startRow}; shifting column {shiftCol}");

                BoardSquare adjacentBoardSquare =
                    move.gameBoard.boardSquare[startRow, nextCol];

                Console.WriteLine($"gameBoard Row {startRow}; gameBoard Col {nextCol}; Piece {adjacentBoardSquare.piece}; IsWhite ");

                if (adjacentBoardSquare.getPiece() != null)
                {
                    return false;
                }
            }

            return true; 
        }
        private bool IsValidMove(Move move)
        {
            // Check ordinal capture
            if ((move.getEnd().piece != null))
            {
                Console.WriteLine("Log: Ordinal Capture Accepted");
                return true;
            }
            return false;
        }
        private bool IsValidCapture(Move move)
        {
            // If landing on null square allow this move
            if (move.getEnd().piece == null)
            {
                Console.WriteLine("Log: Ordinal Move Accepted");
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
            return false;
        }
    }
}

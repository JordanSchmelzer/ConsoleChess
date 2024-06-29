﻿using System;

namespace ConsoleChess.Pieces
{
    internal class Bishop : IGamePiece
    {
        public Bishop(bool white) : base(white) { }
    
        public override bool CanMove(Move move) {
            int deltaRow = move.DeltaRow();
            int deltaCol = move.DeltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            if (IsTargetMyOwnPiece(move) == true) { 
                return false;
            }
            if (absDeltaRow == 0 || absDeltaCol == 0) { 
                return false; 
            }
            if (absDeltaRow / absDeltaCol != 1) { 
                return false; 
            }
            if (IsCardinalMove(move._direction)) {
                return false; 
            }
            if (IsPathToEndSquareClear(move) == false) {
                return false; 
            }
            if (IsValidDiagonalCapture(move)) { 
                return true; 
            }
            if (IsValidDiagonalMove(move)) { 
                return true; 
            }
            
            return false;
        }

        private bool IsPathToEndSquareClear(Move move) {
            int deltaCol = move.DeltaCol();
            int absDeltaCol = Math.Abs(deltaCol);
            Tuple<int, int> directionIterator = ReturnRowAndColScanDirections(move._direction);
            int startRow = move.getStart().GameCol;
            int startCol = move.getStart().GameRow;
            for (int i = 1; i < absDeltaCol; i++) {
                int shiftRow = directionIterator.Item1 * i;
                int shiftCol = directionIterator.Item2 * i;
                int nextRow = shiftRow + startRow;
                int nextCol = shiftCol + startCol;
                BoardSquare boardSquare = move._gameBoard.GetBoardSquare(nextRow, nextCol);
                if (boardSquare.getPiece() != null) {
                    return false;
                }
            }
            return true; 
        }

        private bool IsValidDiagonalCapture(Move move) {
            // This is a capture move
            if (move.getEnd().getPiece() != null) {
                return true;
            }
            return false;
        }

        private bool IsValidDiagonalMove(Move move) {
            if (move.getEnd().getPiece() == null) {
                return true;
            }
            return false;
        }

        private bool IsTargetMyOwnPiece(Move move) {
            IGamePiece endPiece = move.getEnd().getPiece();
            IGamePiece startPiece = move.getStart().getPiece();
            if (endPiece != null) {
                if (endPiece.isWhite() == startPiece.isWhite()) {
                    return true;
                }
            }
            return false;
        }
    }
}
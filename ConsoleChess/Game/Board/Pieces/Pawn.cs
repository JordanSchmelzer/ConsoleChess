﻿using System;

namespace ConsoleChess.Pieces
{
    internal class Pawn : IGamePiece
    {
        public Pawn(bool white) : base(white) { }

        override
        public bool CanMove(Move move)
        {
            // Fail conditions
            if (IsTargetMyOwnPiece(move) == true) { 
                return false; }
            if (IsPawnMoveForward(move) == false) { 
                return false; }

            // Pass conditions
            if (IsValidTwoForwardSquareMove(move)) { 
                return true; }
            if (IsValidDiagonalCapture(move)) {
                return true; }
            if (IsValidEnPassant(move)) { 
                return true; }
            if (IsOneSquareFormwardMove(move)) { 
                return true; }

            // Default
            return false;
        }
        private bool IsValidTwoForwardSquareMove(Move move)
        {
            int absDeltaRow = Math.Abs(move.DeltaRow());
            int absDeltaCol = Math.Abs(move.DeltaCol());
            if ((absDeltaRow == 2 && absDeltaCol == 0) == false) {
                return false;
            }
            IGamePiece endPiece = move.getEnd().getPiece();
            IGamePiece thisPiece = move.getStart().getPiece();
            if (this.HasMoved() == true) {
                return false; 
            }
            if (endPiece != null) { 
                return false; 
            }
            int forwardRowMove;
            if (thisPiece.isWhite()) {
                forwardRowMove = -1;
            }
            else {
                forwardRowMove = 1;
            }
            BoardSquare nextSquareForward =
                move._gameBoard.GetBoardSquare(move.getStart().getGameCol() + forwardRowMove,
                                               move.getStart().getGameRow());
            if (nextSquareForward.getPiece() != null) {
                return false;
            }
            return true;
        }

        private bool IsValidDiagonalCapture(Move move) {
            int absDeltaCol = Math.Abs(move.DeltaCol());
            int absDeltaRow = Math.Abs(move.DeltaRow());
            IGamePiece targetPiece = move.getEnd().getPiece();
            if (absDeltaCol == 1 && 
                absDeltaRow == 1 && 
                targetPiece != null){
                return true;
            }
            return false;
        }

        private bool IsOneSquareFormwardMove(Move move)
        {
            int absDeltaCol = Math.Abs(move.DeltaCol());
            int absDeltaRow = Math.Abs(move.DeltaRow());
            IGamePiece targetPiece = move.getEnd().getPiece();
            if (absDeltaRow == 1 &&
                absDeltaCol == 0 &&
                targetPiece == null) {
                if (IsPiecePromotion(move)) { return true; }
                return true;
            }
            return false;
        }

        private bool IsValidEnPassant(Move move)
        {
            int absDeltaRow = Math.Abs(move.DeltaRow());
            int absDeltaCol = Math.Abs(move.DeltaCol());
            IGamePiece thisPiece = move.getStart().getPiece();
            IGamePiece targetPiece = move.getEnd().getPiece();
            if (absDeltaRow == 2 &&
                absDeltaCol == 1 &&
                thisPiece.HasMoved() == false){
                if (targetPiece != null){
                    return true;
                }
            }
            return false;
        }

        private bool IsPawnMoveForward(Move move) {
            // Check forward movement
            if (move._player.isWhiteSide()) {
                // white forward is negative GameRow
                int deltaRow = move.DeltaRow();
                if (deltaRow > 0) {
                    return false;
                }
            }
            else {
                // black forward is positive GameRow
                int deltaRow = move.DeltaRow();
                if (deltaRow < 0) {
                    return false;
                }
            }
            return true;
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

        public bool IsPiecePromotion(Move move) {
            // is this a pawn promotion move?
            if (move._player.isWhiteSide()) {
                if (move.getEnd().getGameCol() == 0) {
                    move._isPawnPromotion = true;
                    return true;
                }
            }
            else {
                if (move.getEnd().getGameCol() == 7) {
                    move._isPawnPromotion = true;
                    return true;
                }
            }
            return false;
        }
    }
}
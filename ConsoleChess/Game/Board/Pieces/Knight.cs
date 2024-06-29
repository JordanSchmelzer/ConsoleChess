using System;

namespace ConsoleChess.Pieces
{
    class Knight: IGamePiece
    {
        public Knight(bool white) : base(white) { }

        override
        public bool CanMove(Move move)
        {
            // 
            if (IsTargetMyOwnPiece(move)) { return false; }
            if (IsLShapedMove(move) == false) { return false; }

            // Pass Conditions
            if (IsValidCapture(move)) { return true; }
            if (IsValidMove(move)) { return true; }

            // Default
            return false;
        }
        private bool IsValidCapture(Move move)
        {
            // Check L capture
            if (move.getEnd().getPiece() != null)
            {
                return true;
            }
            return false;
        }
        private bool IsValidMove(Move move)
        {
            // If landing on null square allow this move
            if (move.getEnd().getPiece() == null)
            {
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
        private bool IsLShapedMove(Move move)
        {
            int deltaRow = move.DeltaRow();
            int deltaCol = move.DeltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);
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
            return true;
        }
    }
}

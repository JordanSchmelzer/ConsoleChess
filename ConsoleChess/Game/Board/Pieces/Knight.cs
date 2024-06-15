using System;

namespace ConsoleChess.Pieces
{
    class Knight: IGamePiece
    {
        public Knight(bool white) : base(white) { }

        override
        public bool canMove(Move move)
        {
            if (IsTargetMyOwnPiece(move)) { return false; }
            if (IsLShapedMove(move) == false) { return false; }
            if (IsValidCapture(move)) { return true; }
            if (IsValidMove(move)) { return true; }

            Console.WriteLine("Invalid Move! Reason: Not a recognized valid move.");
            return false;
        }
        private bool IsValidCapture(Move move)
        {
            // Check L capture
            if (move.getEnd().getPiece() != null)
            {
                Console.WriteLine("Log: Diagonal Capture Accepted");
                return true;
            }
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
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            // is this an L shaped move?
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
        
        // public bool IsMoveCheckMate(){}
        // public bool IsMove
        public override bool isCastlingMove(Move move)
        {
            return false;
        }
        
    }
}

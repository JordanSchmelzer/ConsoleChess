using System;

namespace ConsoleChess.Pieces
{
    internal class Rook : IGamePiece
    {
        public Rook(bool white) : base(white) { }

        override
        public bool CanMove(Move move)
        {
            int deltaRow = move.DeltaRow();
            int deltaCol = move.DeltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            // Fail Conditions
            if (IsTargetMyOwnPiece(move) == true) { return false; }
            if (!IsCardinalMove(move._direction)) { return false; }
            if ((absDeltaRow > 1 && absDeltaCol != 0) || (deltaRow != 0 && absDeltaCol > 1)) { return false; }
            if (IsPathToEndSquareClear(move) == false) { return false; }

            // Pass Conditions
            if (IsValidMove(move)) { return true; }
            if (IsValidCapture(move)) { return true; }

            // Default
            return false;
        }
        private bool IsPathToEndSquareClear(Move move)
        {
            int deltaCol = move.DeltaCol();
            int absDeltaCol = Math.Abs(deltaCol);
            int deltaRow = move.DeltaRow();
            int absDeltaRow = Math.Abs(deltaRow);

            Tuple<int, int> directionIterator = ReturnRowAndColScanDirections(move._direction);

            int countOfSquaresToCheck = 0;
            switch (move._direction)
            {
                case EnumMoveDirections.EAST:
                    countOfSquaresToCheck = absDeltaCol;
                    break;
                case EnumMoveDirections.WEST:
                    countOfSquaresToCheck = absDeltaCol;
                    break;
                case EnumMoveDirections.NORTH:
                    countOfSquaresToCheck = absDeltaRow;
                    break;
                case EnumMoveDirections.SOUTH:
                    countOfSquaresToCheck = absDeltaRow;
                    break;
            }

            int startRow = move.getStart().GameCol;
            int startCol = move.getStart().GameRow;

            for (int i = 1; i < countOfSquaresToCheck; i++)
            {
                int shiftRow = directionIterator.Item1 * i;
                int shiftCol = directionIterator.Item2 * i;
                int nextRow = shiftRow + startRow;
                int nextCol = shiftCol + startCol;

                BoardSquare boardSquare = move._gameBoard.GetBoardSquare(nextRow, nextCol);
                if (boardSquare.getPiece() != null)
                {
                    return false;
                }
            }

            return true;
        }
        private bool IsValidMove(Move move)
        {
            if ((move.getEnd().piece == null))
            {
                return true;
            }
            return false;
        }
        private bool IsValidCapture(Move move)
        {
            // If landing on null square allow this move
            if (move.getEnd().piece != null)
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
    }
}

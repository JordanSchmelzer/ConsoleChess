using System.Collections.Generic;
using System;

namespace ConsoleChess
{
    public abstract class IGamePiece
    {
        private bool killed = false;
        private bool white = false;
        private bool hasMoved = false;
        private bool isPreview = false;

        public IGamePiece(bool white)
        {
            this.setWhite(white);

        }

        public bool isWhite()
        {
            return this.white;
        } 
        public void setWhite(bool white) 
        {
            this.white = white;
        }

        public bool isKilled()
        {
            return this.killed;
        }
        public void setKilled(bool killed)
        {
            this.killed = killed;
        }

        public abstract bool CanMove(Move move);

        public void SetMoved(bool hasMoved)
        {
            this.hasMoved = hasMoved;
        }
        public bool HasMoved()
        {
            return this.hasMoved;
        }

        public bool getPreview()
        {
            return this.isPreview;
        }
        public void setPreview(bool isPreview)
        {
            this.isPreview = isPreview;
        }

        /// <summary>
        /// This is the algorithm to knowing if player king is in check
        /// </summary>
        /// <returns></returns>
        public bool IsPlayersKingInCheck(GameBoard board, Player currentPlayer)
        {
            BoardSquare kingSquare = null;
            bool isWhite = currentPlayer.isWhiteSide();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board.GetBoardSquare(row, col).getPiece() is King &&
                       board.GetBoardSquare(row, col).getPiece().isWhite() == currentPlayer.isWhiteSide())
                    {
                        kingSquare = board.GetBoardSquare(row, col);
                    }
                }
            }
            List<BoardSquare> attackVectors = new List<BoardSquare>();
            foreach (EnumMoveDirections e in Enum.GetValues(typeof(EnumMoveDirections)))
            {
                attackVectors.Add(FirstVisiblePieceInDirection(board, kingSquare, e));
            }
            foreach (BoardSquare potentialAttackerSquare in attackVectors)
            {
                if (potentialAttackerSquare != null)
                {
                    Move checkMove = new Move(currentPlayer, potentialAttackerSquare, kingSquare, board);
                    if (potentialAttackerSquare.piece.CanMove(checkMove))
                    {
                        Console.WriteLine("King is in check from: ");
                        return true;
                    }
                }
            }
            Console.WriteLine("King is not in check");
            return false;
        }
        private BoardSquare FirstVisiblePieceInDirection(GameBoard board,
                                                        BoardSquare pieceSquare,
                                                        EnumMoveDirections direction)
        {
            Tuple<int, int> scanVector = ReturnRowAndColScanDirections(direction);
            int rowIterator = scanVector.Item1;
            int colIterator = scanVector.Item2;
            int startRow = pieceSquare.GameCol;
            int startCol = pieceSquare.GameRow;    

            for (int i = 1; i < 8; i++)
            {
                int nextRow = (rowIterator * i) + startRow;
                int nextCol = (colIterator * i) + startCol;

                if (nextRow > 7 || nextCol > 7 || nextRow < 0 || nextCol < 0) { return null; }

                BoardSquare nextSquare = board.GetBoardSquare(nextRow, nextCol);
                if (nextSquare.piece != null)
                {
                    return nextSquare;
                }
            }
            return null;
        }
        public Tuple<int, int> ReturnRowAndColScanDirections(EnumMoveDirections direction)
        {
            int rowIterator = 0;
            int colIterator = 0;

            if (direction == EnumMoveDirections.NORTH)
            {
                rowIterator = -1;
                colIterator = 0;
            }
            if (direction == EnumMoveDirections.EAST)
            {
                rowIterator = 0;
                colIterator = 1;
            }
            if (direction == EnumMoveDirections.SOUTH)
            {
                rowIterator = 1;
                colIterator = 0;
            }
            if (direction == EnumMoveDirections.WEST)
            {
                rowIterator = 0;
                colIterator = -1;
            }
            if (direction == EnumMoveDirections.NORTHEAST)
            {
                rowIterator = -1;
                colIterator = 1;
            }
            if (direction == EnumMoveDirections.SOUTHEAST)
            {
                rowIterator = 1;
                colIterator = 1;
            }
            if (direction == EnumMoveDirections.SOUTHWEST)
            {
                rowIterator = 1;
                colIterator = -1;
            }
            if (direction == EnumMoveDirections.NORTHWEST)
            {
                rowIterator = -1;
                colIterator = -1;
            }

            return new Tuple<int, int>(rowIterator, colIterator);
        }
        public bool IsDiagonalMove(EnumMoveDirections direction)
        {
            throw new NotImplementedException("todo");
            return false;
        }
        public bool IsCardinalMove(EnumMoveDirections direction)
        {
            if (direction == EnumMoveDirections.NORTH || direction == EnumMoveDirections.EAST ||
                direction == EnumMoveDirections.SOUTH || direction == EnumMoveDirections.WEST)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static class PieceTypes
    {
        public static readonly PieceType WhitePawn;
        public static readonly PieceType WhiteRook;
        public static readonly PieceType WhiteBishop;
        public static readonly PieceType WhiteKight;
        public static readonly PieceType WhiteQueen;
        public static readonly PieceType WhiteKing;

        public static readonly PieceType BlackPawn;
        public static readonly PieceType BlackRook;
        public static readonly PieceType BlackKight;
        public static readonly PieceType BkackBishop;
        public static readonly PieceType BlackQueen;
        public static readonly PieceType BlackKing;


        static PieceTypes()
        {
            WhitePawn = new PieceType("WhitePawn", 0, 0);
            WhiteRook = new PieceType("WhiteRook", 0, 0);
            WhiteBishop = new PieceType("WhiteBishop", 0, 0);
            WhiteKight = new PieceType("WhiteKight", 0, 0);
            WhiteQueen = new PieceType("WhiteQueen", 0, 0);
            WhiteKing = new PieceType("WhiteKing", 0, 0);

            BlackPawn = new PieceType("BlackPawn", 0, 0);
            BlackRook = new PieceType("BlackRook", 0, 0);
            BlackKight = new PieceType("BlackBishop", 0, 0);
            BkackBishop = new PieceType("BlackKight", 0, 0);
            BlackQueen = new PieceType("BlackQueen", 0, 0);
            BlackKing = new PieceType("BlackKing", 0, 0);
        }
    }
    public class PieceType
    {
        public string Name;
        public int GameRow;
        public int GameCol;

        public PieceType(string name,
                          int gameRow,
                          int gameCol)
        {
            this.Name = name;
            this.GameRow = gameRow;
            this.GameCol = gameCol;
        }

        public void Move()
        {

        }
    }
}

using System.Collections.Generic;
using System;
using ConsoleChess.Pieces;

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

        // Generate a list of possible moves

        /// <summary>
        /// This is the algorithm to knowing if player king is in check
        /// </summary>
        /// <returns></returns>
        public bool IsPlayersKingInCheck(Move move)
        {
            BoardSquare kingSquare = ReturnPlayersKingBoardSquare(move);
            List<BoardSquare> attackVectors = PottentialAttackersBoardSquares(move, kingSquare);
            List<BoardSquare> activeThreats = AttackingPieces(move, attackVectors, kingSquare);

            // of all the potential attack squares, there are no pieces able to attack the king
            if (activeThreats.Count == 0) 
            {
                return false; 
            }
            if (activeThreats.Count > 0)
            {
                return  true; 
            }
            return false;
        }

        private List<BoardSquare> AttackingPieces(Move move,
                                                  List<BoardSquare> potentialAttackers,
                                                  BoardSquare kingSquare)
        {
            List<BoardSquare> activeThreats = new List<BoardSquare>(potentialAttackers.Count);
            if (potentialAttackers.Count == 0) 
            {
                return activeThreats;
            }

            // check to see if any of these pieces are able to attack the kingsquare
            foreach (BoardSquare potentialAttackerSquare in potentialAttackers)
            {
                if (potentialAttackerSquare != null)
                {
                    Move checkMove = new Move(move._player,
                                              potentialAttackerSquare,
                                              kingSquare,
                                              move._gameBoard);

                    if (potentialAttackerSquare.piece.CanMove(checkMove))
                    {
                        Console.WriteLine($"King is in check from: {potentialAttackerSquare.piece}");
                        activeThreats.Add(potentialAttackerSquare);
                    }
                }
            }

            return activeThreats;
        }

        private List<BoardSquare> PottentialAttackersBoardSquares(Move move, BoardSquare kingSquare)
        {
            // List all of the squares that can directly see the king with no piece inbetween
            List<BoardSquare> attackVectors = new List<BoardSquare>();
            BoardSquare boardSquare;

            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.SOUTH, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.NORTH, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.EAST, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.WEST, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.NORTHEAST, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.NORTHWEST, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.SOUTHWEST, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.SOUTHEAST, move._player);
            if (boardSquare != null) { attackVectors.Add(boardSquare); }

            BoardSquare potentialKnight = null;
            // NorthEast       
            potentialKnight = PotentialKnightAttacker(move, kingSquare, -2, 1);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight);}

            potentialKnight = PotentialKnightAttacker(move, kingSquare, -1, 2);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            // SouthEast
            potentialKnight = PotentialKnightAttacker(move, kingSquare, 1, 2);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            potentialKnight = PotentialKnightAttacker(move, kingSquare, 2, 1);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            // SouthWest
            potentialKnight = PotentialKnightAttacker(move, kingSquare, 2, -1);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            potentialKnight = PotentialKnightAttacker(move, kingSquare, 1, -2);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            // NorthWest
            potentialKnight = PotentialKnightAttacker(move, kingSquare, -1, -2);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            potentialKnight = PotentialKnightAttacker(move, kingSquare, -2, -11);
            if (potentialKnight != null) { attackVectors.Add(potentialKnight); }

            return attackVectors;
        }

        private BoardSquare PotentialKnightAttacker(Move move, BoardSquare kingSquare, int row, int col)
        {
            int kingSquareRow = kingSquare.getGameRow();
            int kingSquareCol = kingSquare.getGameCol();
            int deltaRow = kingSquareRow + row;
            int deltaCol = kingSquareCol + col;

            if (deltaCol > 8 && deltaCol <= 0 &&
                deltaRow > 8 && deltaRow <= 0)
            {
                BoardSquare potentialKnight = move._gameBoard.GetBoardSquare(deltaRow, deltaCol);
                if (potentialKnight.getPiece() is Knight && 
                    potentialKnight.getPiece().isWhite() !=
                    move._player.isWhiteSide())
                {
                    return potentialKnight;
                }
            }
            return null;
        }

        private BoardSquare ReturnPlayersKingBoardSquare(Move move)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (move._gameBoard.GetBoardSquare(row, col).getPiece() is King &&
                       move._gameBoard.GetBoardSquare(row, col).getPiece().isWhite() == move._player.isWhiteSide())
                    {
                        return move._gameBoard.GetBoardSquare(row, col);
                    }
                }
            }
            return null;
        }

        private BoardSquare FirstVisiblePieceInDirection(GameBoard board,
                                                        BoardSquare pieceSquare,
                                                        EnumMoveDirections direction,
                                                        Player player)
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
                    if (nextSquare.piece.isWhite() != player.isWhiteSide())
                    {
                        return nextSquare;
                    }
                    return null;
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

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
        public abstract bool CanMove(Move move);

        public bool isWhite() { 
            return this.white;
        } 

        public void setWhite(bool white) {
            this.white = white;
        }

        public bool isKilled() {
            return this.killed;
        }

        public void setKilled(bool killed) {
            this.killed = killed;
        }

        public void SetMoved(bool hasMoved) {
            this.hasMoved = hasMoved;
        }

        public bool HasMoved() {
            return this.hasMoved;
        }

        public bool getPreview() {
            return this.isPreview;
        }

        public void setPreview(bool isPreview) {
            this.isPreview = isPreview;
        }

        public Tuple<int, int> ReturnRowAndColScanDirections(EnumMoveDirections direction) {
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

        public bool IsDiagonalMove(EnumMoveDirections direction) {
            throw new NotImplementedException("todo");
            //return false;
        }

        public bool IsCardinalMove(EnumMoveDirections direction) {
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

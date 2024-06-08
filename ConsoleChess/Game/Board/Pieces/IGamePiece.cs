using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public abstract class IGamePiece
    {
        private bool killed = false;
        private bool white = false;
        private bool hasMoved = false;

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

        public abstract bool canMove(Move move, GameBoard gameBaord);

        public void SetMoved()
        {
            this.hasMoved = true;
        }
        public bool HasMoved()
        {
            return this.hasMoved;
        }


        public abstract bool isCastlingMove(BoardSquare start, BoardSquare end, GameBoard board);
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

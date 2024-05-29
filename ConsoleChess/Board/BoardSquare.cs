using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class BoardSquare
    {
        public int GameRow;
        public int GameCol;
        private IGamePiece piece;

        public BoardSquare(int gameCol,
                           int gameRow,
                           IGamePiece piece)
        {
            this.setGameRow(gameRow);
            this.setGameCol(gameCol);
            this.setPiece(piece);
        }

        public IGamePiece getPiece() 
        { 
            return this.piece; 
        }

        public void setPiece(IGamePiece piece) 
        {
            this.piece = piece; 
        }

        public int getGameCol()
        {
            return this.GameCol;
        }

        public void setGameCol(int xPos) 
        { 
            this.GameCol = xPos; 
        }

        public int getGameRow() 
        {
            return this.GameRow;
        }

        public void setGameRow(int yPos) 
        { 
            this.GameRow = yPos;
        }
    }
    public class BoardSquareTypes 
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


        static BoardSquareTypes()
        {
            WhitePawn = new PieceType("White", 0, 0);
            WhiteRook = new PieceType("Black", 0, 0);
        }
    }
    public class BoardSquaresType
    {
        public string Name;
        public int GameRow;
        public int GameCol;

        public BoardSquaresType(string name,
                                int gameRow,
                                int gameCol)
        {
            this.Name = name;
            this.GameRow = gameRow;
            this.GameCol = gameCol;
        }

        public void Move(int targetRow, int targetCol)
        {

        }
    }
}

using ConsoleChess.Pieces;
using System;

namespace ConsoleChess
{
    public class GameBoard
    {
        public const int Size = 64;
        public const int PixelsPerBoardSquare = 8;
        public const int BoardSquaresPerRowCol = 8;
        public BoardSquare[,] boardSquare;

        public GameBoard()
        {
            ResetChessPiecesOnBoard();
        }

        public BoardSquare GetBoardSquare(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                throw new Exception("Chess board index out of bound!");
            }
            return boardSquare[x, y];
        }
        public void ResetChessPiecesOnBoard()
        {
            // initialize white pieces
            this.boardSquare = new BoardSquare[8, 8];

            // Setup Black
            this.boardSquare[0, 0] = new BoardSquare(0, 0, new Rook(false));
            this.boardSquare[0, 1] = new BoardSquare(0, 1, new Knight(false));
            this.boardSquare[0, 2] = new BoardSquare(0, 2, new Bishop(false));
            this.boardSquare[0, 3] = new BoardSquare(0, 3, new Queen(false));
            this.boardSquare[0, 4] = new BoardSquare(0, 4, new King(false));
            this.boardSquare[0, 5] = new BoardSquare(0, 5, new Bishop(false));
            this.boardSquare[0, 6] = new BoardSquare(0, 6, new Knight(false));
            this.boardSquare[0, 7] = new BoardSquare(0, 7, new Rook(false));

            this.boardSquare[1, 0] = new BoardSquare(1, 0, new Pawn(false));
            this.boardSquare[1, 1] = new BoardSquare(1, 1, new Pawn(false));
            this.boardSquare[1, 2] = new BoardSquare(1, 2, new Pawn(false));
            this.boardSquare[1, 3] = new BoardSquare(1, 3, new Pawn(false));
            this.boardSquare[1, 4] = new BoardSquare(1, 4, new Pawn(false));
            this.boardSquare[1, 5] = new BoardSquare(1, 5, new Pawn(false));
            this.boardSquare[1, 6] = new BoardSquare(1, 6, new Pawn(false));
            this.boardSquare[1, 7] = new BoardSquare(1, 7, new Pawn(false));

            // Setup White
            this.boardSquare[6, 0] = new BoardSquare(6, 0, new Pawn(true));
            this.boardSquare[6, 1] = new BoardSquare(6, 1, new Pawn(true));
            this.boardSquare[6, 2] = new BoardSquare(6, 2, new Pawn(true));
            this.boardSquare[6, 3] = new BoardSquare(6, 3, new Pawn(true));
            this.boardSquare[6, 4] = new BoardSquare(6, 4, new Pawn(true));
            this.boardSquare[6, 5] = new BoardSquare(6, 5, new Pawn(true));
            this.boardSquare[6, 6] = new BoardSquare(6, 6, new Pawn(true));
            this.boardSquare[6, 7] = new BoardSquare(6, 7, new Pawn(true));

            this.boardSquare[7, 0] = new BoardSquare(7, 0, new Rook(true));
            this.boardSquare[7, 1] = new BoardSquare(7, 1, new Knight(true));
            this.boardSquare[7, 2] = new BoardSquare(7, 2, new Bishop(true));
            this.boardSquare[7, 3] = new BoardSquare(7, 3, new Queen(true));
            this.boardSquare[7, 4] = new BoardSquare(7, 4, new King(true));
            this.boardSquare[7, 5] = new BoardSquare(7, 5, new Bishop(true));
            this.boardSquare[7, 6] = new BoardSquare(7, 6, new Knight(true));
            this.boardSquare[7, 7] = new BoardSquare(7, 7, new Rook(true));

            // initialize remaining boxes without any piece 
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.boardSquare[i, j] = new BoardSquare(i, j, null);
                }
            }
        }

    }
}

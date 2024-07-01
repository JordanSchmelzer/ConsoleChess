using ConsoleChess.Pieces;
using System;

namespace ConsoleChess
{
    public class GameBoard
    {
        public const int Size = 64;
        public const int PixelsPerBoardSquare = 8;
        public const int BoardSquaresPerRowCol = 8;

        public BoardSquare[,] boardSquare { get; set; }

        public GameBoard() {
            boardSquare = new BoardSquare[BoardSquaresPerRowCol, BoardSquaresPerRowCol];
        }

        public BoardSquare GetBoardSquare(int x, int y) {
            if (x < 0 || x > 7 || y < 0 || y > 7) {
                // something has gone wrong if this happens.
                throw new Exception("Chess board index out of bound!");
            }
            return boardSquare[x, y];
        }

        public void PlacePiece(int row, int col, IGamePiece piece) {
            BoardSquare newSquare = new BoardSquare(row, col, piece);
            boardSquare[row, col] = newSquare;
        }

        public void InitializeAllSquaresNull() {
            for(int i = 0; i < BoardSquaresPerRowCol; i++) {
                for (int j = 0; j < BoardSquaresPerRowCol; j++) {
                    this.boardSquare[i, j] = new BoardSquare(i, j, null);
                }
            }
        }

        public void ResetChessPiecesOnBoard() {
            // Initialize everything with null boardSquares
            InitializeAllSquaresNull();

            // Setup Black
            PlacePiece(0, 0, new Rook(false));
            PlacePiece(0, 1, new Knight(false));
            PlacePiece(0, 2, new Bishop(false));
            PlacePiece(0, 3, new Queen(false));
            PlacePiece(0, 4, new King(false));
            PlacePiece(0, 5, new Bishop(false));
            PlacePiece(0, 6, new Knight(false));
            PlacePiece(0, 7, new Rook(false));

            PlacePiece(1,0, new Pawn(false));
            PlacePiece(1,1, new Pawn(false));
            PlacePiece(1,2, new Pawn(false));
            PlacePiece(1,3, new Pawn(false));
            PlacePiece(1,4, new Pawn(false));
            PlacePiece(1,5, new Pawn(false));
            PlacePiece(1,6, new Pawn(false));
            PlacePiece(1,7, new Pawn(false));


            // Setup White
            PlacePiece(6, 0, new Pawn(true));
            PlacePiece(6, 1, new Pawn(true));
            PlacePiece(6, 2, new Pawn(true));
            PlacePiece(6, 3, new Pawn(true));
            PlacePiece(6, 4, new Pawn(true));
            PlacePiece(6, 5, new Pawn(true));
            PlacePiece(6, 6, new Pawn(true));
            PlacePiece(6, 7, new Pawn(true));

            PlacePiece(7, 0, new Rook(true));
            PlacePiece(7, 1, new Knight(true));
            PlacePiece(7, 2, new Bishop(true));
            PlacePiece(7, 3, new Queen(true));
            PlacePiece(7, 4, new King(true));
            PlacePiece(7, 5, new Bishop(true));
            PlacePiece(7, 6, new Knight(true));
            PlacePiece(7, 7, new Rook(true));
        }
    }
}

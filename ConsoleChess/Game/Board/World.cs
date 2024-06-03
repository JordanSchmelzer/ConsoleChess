using ConsoleChess.Pieces;
using System;

namespace ConsoleChess
{
    public class World
    {
        public const int Size = 64;
        public const int PixelsPerSquare = 8;
        public Tile[] tiles = new Tile[Size * Size];
        public BoardSquare[,] boxes;

        public World() 
        {
            this.resetBoard();
            this.ChessScene();
        }

        public BoardSquare getBox(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7) 
            {
                throw new Exception("Chess board index out of bound!");
            }
            return boxes[x,y];
        }

        public void resetBoard()
        {
            // initialize white pieces
            this.boxes = new BoardSquare[8,8];

            // Setup Black
            this.boxes[0, 0] = new BoardSquare(0, 0, new Rook(false));
            this.boxes[0, 1] = new BoardSquare(0, 1, new Knight(false));
            this.boxes[0, 2] = new BoardSquare(0, 2, new Bishop(false));
            this.boxes[0, 3] = new BoardSquare(0, 3, new Queen(false));
            this.boxes[0, 4] = new BoardSquare(0, 4, new King(false));
            this.boxes[0, 5] = new BoardSquare(0, 5, new Bishop(false));
            this.boxes[0, 6] = new BoardSquare(0, 6, new Knight(false));
            this.boxes[0, 7] = new BoardSquare(0, 7, new Rook(false));

            this.boxes[1, 0] = new BoardSquare(1, 0, new Pawn(false));
            this.boxes[1, 1] = new BoardSquare(1, 1, new Pawn(false));
            this.boxes[1, 2] = new BoardSquare(1, 2, new Pawn(false));
            this.boxes[1, 3] = new BoardSquare(1, 3, new Pawn(false));
            this.boxes[1, 4] = new BoardSquare(1, 4, new Pawn(false));
            this.boxes[1, 5] = new BoardSquare(1, 5, new Pawn(false));
            this.boxes[1, 6] = new BoardSquare(1, 6, new Pawn(false));
            this.boxes[1, 7] = new BoardSquare(1, 7, new Pawn(false));

            // Setup White
            this.boxes[6, 0] = new BoardSquare(6, 0, new Pawn(true));
            this.boxes[6, 1] = new BoardSquare(6, 1, new Pawn(true));
            this.boxes[6, 2] = new BoardSquare(6, 2, new Pawn(true));
            this.boxes[6, 3] = new BoardSquare(6, 3, new Pawn(true));
            this.boxes[6, 4] = new BoardSquare(6, 4, new Pawn(true));
            this.boxes[6, 5] = new BoardSquare(6, 5, new Pawn(true));
            this.boxes[6, 6] = new BoardSquare(6, 6, new Pawn(true));
            this.boxes[6, 7] = new BoardSquare(6, 7, new Pawn(true));

            this.boxes[7, 0] = new BoardSquare(7, 0, new Rook(true));
            this.boxes[7, 1] = new BoardSquare(7, 1, new Knight(true));
            this.boxes[7, 2] = new BoardSquare(7, 2, new Bishop(true));
            this.boxes[7, 3] = new BoardSquare(7, 3, new Queen(true));
            this.boxes[7, 4] = new BoardSquare(7, 4, new King(true));
            this.boxes[7, 5] = new BoardSquare(7, 5, new Bishop(true));
            this.boxes[7, 6] = new BoardSquare(7, 6, new Knight(true));
            this.boxes[7, 7] = new BoardSquare(7, 7, new Rook(true));

            // initialize remaining boxes without any piece 
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.boxes[i,j] = new BoardSquare(i, j, null);
                }
            }
        }

        public Tile GetTile(int row, int col)
        {
            return tiles[col + (Size * row)];
        }

        public void SetTile(int row, int col, Tile tile)
        {
            tiles[col + (Size * row)] = tile;
        }

        public void TitleScene()
        {
            InitializeTilesWithDefaultType();
            SetTitleSceneTiles();
        }

        void SetTitleSceneTiles()
        {
            DrawSquare(0, 0, 64, new Tile(TileTypes.Gold));
        }

        public void ChessScene()
        {
            InitializeTilesWithDefaultType();
            SetChessBoardSquareTiles();
            // Mark Tiles
            DrawBoardSquareCoordinates();
        }

        public void InitializeTilesWithDefaultType()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    SetTile(row, col, new Tile(TileTypes.Debug));
                }
            }
        }
        public void SetChessBoardSquareTiles()
        {
            int boardTiles = 8;
            int boardPixel = 8;

            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    DrawSquare(boardPixel * 0, i * boardPixel, boardTiles, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 1, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 2, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 3, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 4, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 5, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 6, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 7, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                }
                else
                {
                    DrawSquare(boardPixel * 0, i * boardPixel, boardTiles, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 1, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 2, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 3, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 4, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 5, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 6, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 7, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                }
            }
        }

        // Pawns
        public void DrawBlackPawn(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));
        }
        public void DrawWhitePawn(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));

            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 8, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 9, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 10, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 11, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 12, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 13, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 14, new Tile(TileTypes.Gold));
            //SetTile(n, startColumn + 15, new Tile(TileTypes.Gold));
        }
        // Rooks
        public void DrawWhiteRook(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));

        }
        public void DrawBlackRook(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));

        }
        // Knights
        public void DrawBlackKnight(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
        }
        public void DrawWhiteKnight(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));
        }
        // Bishops
        public void DrawBlackBishop(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));

        }
        public void DrawWhiteBishop(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));

        }
        // King
        public void DrawWhiteKing(int startRow, int startColumn, Tile primaryTile, Tile secondaryTile)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            //SetTile(startRow + n, startColumn + 3, primaryTile);
            //SetTile(startRow + n, startColumn + 4, primaryTile);
            //SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            //SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            //SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5, primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, secondaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5, secondaryTile);
            SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, secondaryTile);
            SetTile(startRow + n, startColumn + 3, secondaryTile);
            SetTile(startRow + n, startColumn + 4, secondaryTile);
            SetTile(startRow + n, startColumn + 5, secondaryTile);
            SetTile(startRow + n, startColumn + 6, secondaryTile);
            SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5, primaryTile);
            SetTile(startRow + n, startColumn + 6, primaryTile);
            SetTile(startRow + n, startColumn + 7, primaryTile);
        }
        public void DrawBlackKing(int startRow, int startColumn, Tile primaryTile, Tile secondaryTile)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            //SetTile(startRow + n, startColumn + 3, primaryTile);
            //SetTile(startRow + n, startColumn + 4, primaryTile);
            //SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            //SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            //SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            //SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5, primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, secondaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5, secondaryTile);
            SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, secondaryTile);
            SetTile(startRow + n, startColumn + 3, secondaryTile);
            SetTile(startRow + n, startColumn + 4, secondaryTile);
            SetTile(startRow + n, startColumn + 5, secondaryTile);
            SetTile(startRow + n, startColumn + 6, secondaryTile);
            SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5, primaryTile);
            SetTile(startRow + n, startColumn + 6, primaryTile);
            SetTile(startRow + n, startColumn + 7, primaryTile);
        }
        // Queen
        public void DrawWhiteQueen(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.White));
            SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));
        }
        public void DrawBlackQueen(int startRow, int startColumn)
        {
            // Row 1
            int n = 0;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 2
            n = 1;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 3
            n = 2;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 4
            n = 3;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 5
            n = 4;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            //SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            //SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Gold));


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.DarkGrey));
            SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, new Tile(TileTypes.Gold));
            SetTile(startRow + n, startColumn + 1, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 2, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 3, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 4, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 5, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 6, new Tile(TileTypes.Black));
            SetTile(startRow + n, startColumn + 7, new Tile(TileTypes.Black));
        }

        public void DrawSquare(int startColumn, int startRow, int len, Tile tile)
        {
            for (int row = startRow; row < startRow + len; row++)
            {
                for (int col = startColumn; col < startColumn + len; col++)
                {
                    SetTile(row, col, tile);
                }
            }
        }
        public void DrawBoardSquareCoordinates()
        {
            // Row 1
            int n = 0;
            SetTile(n , 0, new Tile(TileTypes.OneOne));
            SetTile(n , 8, new Tile(TileTypes.OneTwo));
            SetTile(n , 16, new Tile(TileTypes.OneThree));
            SetTile(n , 24, new Tile(TileTypes.OneFour));
            SetTile(n , 32, new Tile(TileTypes.OneFive));
            SetTile(n , 40, new Tile(TileTypes.OneSix));
            SetTile(n , 48, new Tile(TileTypes.OneSeven));
            SetTile(n , 56, new Tile(TileTypes.OneEight));
            // Row 2
            n = 8;
            SetTile(n, 0, new Tile(TileTypes.TwoOne));
            SetTile(n, 8, new Tile(TileTypes.TwoTwo));
            SetTile(n, 16, new Tile(TileTypes.TwoThree));
            SetTile(n, 24, new Tile(TileTypes.TwoFour));
            SetTile(n, 32, new Tile(TileTypes.TwoFive));
            SetTile(n, 40, new Tile(TileTypes.TwoSix));
            SetTile(n, 48, new Tile(TileTypes.TwoSeven));
            SetTile(n, 56, new Tile(TileTypes.TwoEight));
            // Row 3
            n = 16;
            SetTile(n, 0, new Tile(TileTypes.ThreeOne));
            SetTile(n, 8, new Tile(TileTypes.ThreeTwo));
            SetTile(n, 16, new Tile(TileTypes.ThreeThree));
            SetTile(n, 24, new Tile(TileTypes.ThreeFour));
            SetTile(n, 32, new Tile(TileTypes.ThreeFive));
            SetTile(n, 40, new Tile(TileTypes.ThreeSix));
            SetTile(n, 48, new Tile(TileTypes.ThreeSeven));
            SetTile(n, 56, new Tile(TileTypes.ThreeEight));
            // Row 4
            n = 24;
            SetTile(n, 0, new Tile(TileTypes.FourOne));
            SetTile(n, 8, new Tile(TileTypes.FourTwo));
            SetTile(n, 16, new Tile(TileTypes.FourThree));
            SetTile(n, 24, new Tile(TileTypes.FourFour));
            SetTile(n, 32, new Tile(TileTypes.FourFive));
            SetTile(n, 40, new Tile(TileTypes.FourSix));
            SetTile(n, 48, new Tile(TileTypes.FourSeven));
            SetTile(n, 56, new Tile(TileTypes.FourEight));
            // Row 5
            n = 32;
            SetTile(n, 0, new Tile(TileTypes.FiveOne));
            SetTile(n, 8, new Tile(TileTypes.FiveTwo));
            SetTile(n, 16, new Tile(TileTypes.FiveThree));
            SetTile(n, 24, new Tile(TileTypes.FiveFour));
            SetTile(n, 32, new Tile(TileTypes.FiveFive));
            SetTile(n, 40, new Tile(TileTypes.FiveSix));
            SetTile(n, 48, new Tile(TileTypes.FiveSeven));
            SetTile(n, 56, new Tile(TileTypes.FiveEight));
            // Row 6
            n = 40;
            SetTile(n, 0, new Tile(TileTypes.SixOne));
            SetTile(n, 8, new Tile(TileTypes.SixTwo));
            SetTile(n, 16, new Tile(TileTypes.SixThree));
            SetTile(n, 24, new Tile(TileTypes.SixFour));
            SetTile(n, 32, new Tile(TileTypes.SixFive));
            SetTile(n, 40, new Tile(TileTypes.SixSix));
            SetTile(n, 48, new Tile(TileTypes.SixSeven));
            SetTile(n, 56, new Tile(TileTypes.SixEight));
            // Row 7
            n = 48;
            SetTile(n, 0, new Tile(TileTypes.SevenOne));
            SetTile(n, 8, new Tile(TileTypes.SevenTwo));
            SetTile(n, 16, new Tile(TileTypes.SevenThree));
            SetTile(n, 24, new Tile(TileTypes.SevenFour));
            SetTile(n, 32, new Tile(TileTypes.SevenFive));
            SetTile(n, 40, new Tile(TileTypes.SevenSix));
            SetTile(n, 48, new Tile(TileTypes.SevenSeven));
            SetTile(n, 56, new Tile(TileTypes.SevenEight));
            // Row 8
            n = 56;
            SetTile(n, 0, new Tile(TileTypes.EightOne));
            SetTile(n, 8, new Tile(TileTypes.EightTwo));
            SetTile(n, 16, new Tile(TileTypes.EightThree));
            SetTile(n, 24, new Tile(TileTypes.EightFour));
            SetTile(n, 32, new Tile(TileTypes.EightFive));
            SetTile(n, 40, new Tile(TileTypes.EightSix));
            SetTile(n, 48, new Tile(TileTypes.EightSeven));
            SetTile(n, 56, new Tile(TileTypes.EightEight));
        }

        //public void CenterIslandScene()
        //{
        //    for (int x = 0; x < Size; x++)
        //    {
        //        for (int y = 0; y < Size; y++)
        //        {
        //            int c = Size / 2;

        //            int d = ((x - c) * (x - c)) + ((y - c) * (y - c));

        //            if (d < 64)
        //                SetTile(x, y, new Tile(TileTypes.Wood));
        //            else
        //                SetTile(x, y, new Tile(TileTypes.Water));
        //        }
        //    }
        //}
    }
}

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
        public Frame frame;


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
        public void UpdateFrame()
        {
            DrawChessBoardSquares();
            DrawBoardSquareCoordinates();
            DrawGamePieces();
        }


        // Frame Rendering
        public void DrawChessBoardSquares()
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
        public void DrawBoardSquareCoordinates()
        {
            // Row 1
            int n = 0;
            frame.SetTileMap(n, 0, new Tile(TileTypes.OneOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.OneTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.OneThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.OneFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.OneFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.OneSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.OneSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.OneEight));
            // Row 2
            n = 8;
            frame.SetTileMap(n, 0, new Tile(TileTypes.TwoOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.TwoTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.TwoThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.TwoFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.TwoFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.TwoSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.TwoSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.TwoEight));
            // Row 3
            n = 16;
            frame.SetTileMap(n, 0, new Tile(TileTypes.ThreeOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.ThreeTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.ThreeThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.ThreeFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.ThreeFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.ThreeSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.ThreeSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.ThreeEight));
            // Row 4
            n = 24;
            frame.SetTileMap(n, 0, new Tile(TileTypes.FourOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.FourTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.FourThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.FourFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.FourFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.FourSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.FourSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.FourEight));
            // Row 5
            n = 32;
            frame.SetTileMap(n, 0, new Tile(TileTypes.FiveOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.FiveTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.FiveThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.FiveFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.FiveFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.FiveSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.FiveSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.FiveEight));
            // Row 6
            n = 40;
            frame.SetTileMap(n, 0, new Tile(TileTypes.SixOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.SixTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.SixThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.SixFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.SixFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.SixSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.SixSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.SixEight));
            // Row 7
            n = 48;
            frame.SetTileMap(n, 0, new Tile(TileTypes.SevenOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.SevenTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.SevenThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.SevenFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.SevenFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.SevenSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.SevenSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.SevenEight));
            // Row 8
            n = 56;
            frame.SetTileMap(n, 0, new Tile(TileTypes.EightOne));
            frame.SetTileMap(n, 8, new Tile(TileTypes.EightTwo));
            frame.SetTileMap(n, 16, new Tile(TileTypes.EightThree));
            frame.SetTileMap(n, 24, new Tile(TileTypes.EightFour));
            frame.SetTileMap(n, 32, new Tile(TileTypes.EightFive));
            frame.SetTileMap(n, 40, new Tile(TileTypes.EightSix));
            frame.SetTileMap(n, 48, new Tile(TileTypes.EightSeven));
            frame.SetTileMap(n, 56, new Tile(TileTypes.EightEight));
        }
        public void DrawGamePieces()
        {
            for (int i = 0; i < BoardSquaresPerRowCol; i++)
            {
                for (int j = 0; j < BoardSquaresPerRowCol; j++)
                {
                    BoardSquare boardSquare = GetBoardSquare(i, j);
                    if (boardSquare.getPiece() is Queen)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            DrawQueen(i * PixelsPerBoardSquare,
                                      j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.White),
                                     new Tile(TileTypes.Black));
                        }
                        else
                        {
                            DrawQueen(i * PixelsPerBoardSquare,
                                      j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.DarkGrey),
                                     new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is King)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            DrawKing(i * PixelsPerBoardSquare,
                                     j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.White),
                                     new Tile(TileTypes.Black));
                        }
                        else
                        {
                            DrawKing(i * PixelsPerBoardSquare,
                                     j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.DarkGrey),
                                     new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Pawn)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            DrawPawn(i * PixelsPerBoardSquare,
                                     j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.White),
                                     new Tile(TileTypes.Black));
                        }
                        else
                        {
                            DrawPawn(i * PixelsPerBoardSquare,
                                     j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.DarkGrey),
                                     new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Rook)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            DrawRook(i * PixelsPerBoardSquare,
                                     j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.White),
                                     new Tile(TileTypes.Black));
                        }
                        else
                        {
                            DrawRook(i * PixelsPerBoardSquare,
                                     j * PixelsPerBoardSquare,
                                     new Tile(TileTypes.DarkGrey),
                                     new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Bishop)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            DrawBishop(i * PixelsPerBoardSquare,
                                       j * PixelsPerBoardSquare,
                                       new Tile(TileTypes.White),
                                       new Tile(TileTypes.Black));
                        }
                        else
                        {
                            DrawBishop(i * PixelsPerBoardSquare,
                                       j * PixelsPerBoardSquare,
                                       new Tile(TileTypes.DarkGrey),
                                       new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Knight)
                    {
                        if (boardSquare.getPiece().isWhite())
                        {
                            DrawKnight(i * PixelsPerBoardSquare,
                                       j * PixelsPerBoardSquare,
                                       new Tile(TileTypes.White),
                                       new Tile(TileTypes.Black));
                        }
                        else
                        {
                            DrawKnight(i * PixelsPerBoardSquare,
                                       j * PixelsPerBoardSquare,
                                       new Tile(TileTypes.DarkGrey),
                                       new Tile(TileTypes.Black));
                        }
                    }
                }
            }
        }


        // Drawing Tools
        public void DrawSquare(int startColumn, int startRow, int len, Tile tile)
        {
            for (int row = startRow; row < startRow + len; row++)
            {
                for (int col = startColumn; col < startColumn + len; col++)
                {
                    frame.SetTileMap(row, col, tile);
                }
            }
        }


        // Pieces
        public void DrawKnight(int startRow,
                               int startColumn,
                               Tile pieceColor,
                               Tile borderColor)
        {
            // Row 1
            int n = 0;
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 2
            n = 1;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 3
            n = 2;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 4
            n = 3;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 5
            n = 4;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);

            // Row 6
            n = 5;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
        }
        public void DrawPawn(int startRow,
                             int startColumn,
                             Tile pieceColor,
                             Tile borderColor)
        {
            // Row 1
            // Row 2
            int n = 1;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 3
            n = 2;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 4
            n = 3;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 5
            n = 4;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 6
            n = 5;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
        }
        public void DrawBishop(int startRow,
                               int startColumn,
                               Tile pieceColor,
                               Tile borderColor)
        {
            // Row 1
            int n = 0;
            // Row 2
            n = 1;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 3
            n = 2;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 4
            n = 3;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 5
            n = 4;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
        }
        public void DrawKing(int startRow,
                             int startColumn,
                             Tile pieceColor,
                             Tile borderColor)
        {
            // Row 1
            int n = 0;
            // Row 2
            n = 1;
            frame.SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            // Row 3
            n = 2;
            frame.SetTileMap(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            frame.SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            frame.SetTileMap(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            // Row 4
            n = 3;
            frame.SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            // Row 5
            n = 4;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 7
            n = 6;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 7, borderColor);
            // Row 8
            n = 7;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 7, borderColor);
        }
        public void DrawQueen(int startRow,
                              int startColumn,
                              Tile pieceColor,
                              Tile borderColor)
        {
            // Row 1
            int n = 0;
            frame.SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            // Row 2
            n = 1;
            frame.SetTileMap(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            frame.SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            frame.SetTileMap(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            // Row 3
            n = 2;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 4
            n = 3;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 5
            n = 4;
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 7
            n = 6;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 7, borderColor);
            // Row 8
            n = 7;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 7, borderColor);
        }
        public void DrawRook(int startRow,
                             int startColumn,
                             Tile pieceColor,
                             Tile borderColor)
        {
            // Row 1
            int n = 0;
            // Row 2
            n = 1;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 3
            n = 2;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 4
            n = 3;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 5
            n = 4;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 3, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 4, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 5, pieceColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            frame.SetTileMap(startRow + n, startColumn + 1, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 2, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 3, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 4, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 5, borderColor);
            frame.SetTileMap(startRow + n, startColumn + 6, borderColor);
        }
    }
}

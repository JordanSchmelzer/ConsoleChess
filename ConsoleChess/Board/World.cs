using ConsoleChess.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class World
    {
        public const int Size = 64;
        public Tile[] tiles = new Tile[Size * Size];
        BoardSquare[][] boxes = new BoardSquare[8][];

        public World() 
        {
            this.resetBoard();
            ChessScene();
        }

        public BoardSquare getBox(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7) 
            {
                throw new Exception("Chess board index out of bound!");
            }
            //return boxes[x][y];
            return boxes[x];
        }

        public void resetBoard()
        {
            // initialize white pieces
            this.boxes[0] = new BoardSquare(0, 0, new Rook(true);
            Console.WriteLine("ItWorked");

            //boxes[0][1] = new BoardSquare(0, 1, new Knight(true));
            //boxes[0][2] = new BoardSquare(0, 2, new Bishop(true));
            ////... 
            //boxes[1][0] = new BoardSquare(1, 0, new Pawn(true));
            //boxes[1][1] = new BoardSquare(1, 1, new Pawn(true));
            ////... 

            //// initialize black pieces 
            //boxes[7][0] = new BoardSquare(7, 0, new Rook(false));
            //boxes[7][1] = new BoardSquare(7, 1, new Knight(false));
            //boxes[7][2] = new BoardSquare(7, 2, new Bishop(false));
            ////... 
            //boxes[6][0] = new BoardSquare(6, 0, new Pawn(false));
            //boxes[6][1] = new BoardSquare(6, 1, new Pawn(false));
            //... 

            // initialize remaining boxes without any piece 
            //for (int i = 2; i < 6; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        boxes[i][j] = new BoardSquare(i, j, null);
            //    }
            //}
        }

        public Tile GetTile(int row, int col)
        {
            return tiles[col + (Size * row)];
        }

        public void SetTile(int row, int col, Tile tile)
        {
            tiles[col + (Size * row)] = tile;
        }

        public void ChessScene()
        {
            DebugBackground();
            DrawCoordinates();
            DrawChessBoard();
            SetupPieces();
        }

        public void DebugScene()
        {
            DebugBackground();
            DrawCoordinates();
            DrawChessBoard();
            SetupPieces();
        }

        public void SetupPieces()
        {
            SetupWhitePawns();
            SetupBlackPawns();

            SetupWhiteRooks();
            SetupBlackRooks();

            SetupWhiteBishops();
            SetupBlackBishops();

            SetupWhiteKights();
            SetupBlackKnights();

            SetupBlackKing();
            SetupWhiteKing();

            SetupWhiteQueen();
            SetupBlackQueen();
        }

        public void SetupWhitePawns()
        {
            DrawWhitePawn(8, 0);
            DrawWhitePawn(8, 8);
            DrawWhitePawn(8, 16);
            DrawWhitePawn(8, 24);
            DrawWhitePawn(8, 32);
            DrawWhitePawn(8, 40);
            DrawWhitePawn(8, 48);
            DrawWhitePawn(8, 56);
        }
        public void SetupBlackPawns()
        {
            DrawBlackPawn(48, 0);
            DrawBlackPawn(48, 8);
            DrawBlackPawn(48, 16);
            DrawBlackPawn(48, 24);
            DrawBlackPawn(48, 32);
            DrawBlackPawn(48, 40);
            DrawBlackPawn(48, 48);
            DrawBlackPawn(48, 56);
        }

        public void SetupWhiteRooks()
        {
            DrawWhiteRook(0, 0);
            DrawWhiteRook(0, 56);
        }
        public void SetupBlackRooks()
        {
            DrawBlackRook(56, 0);
            DrawBlackRook(56,56);
        }

        public void SetupBlackKnights()
        {
            DrawBlackKnight(56, 8);
            DrawBlackKnight(56, 48);
        }
        public void SetupWhiteKights()
        {
            DrawWhiteKnight(0, 8);
            DrawWhiteKnight(0, 48);
        }

        public void SetupBlackBishops()
        {
            DrawBlackBishop(56, 16);
            DrawBlackBishop(56, 40);
        }
        public void SetupWhiteBishops()
        {
            DrawWhiteBishop(0, 16);
            DrawWhiteBishop(0, 40);
        }

        public void SetupBlackKing()
        {
            DrawBlackKing(56,32, new Tile(TileTypes.Black), new Tile(TileTypes.DarkGrey));
        }
        public void SetupWhiteKing()
        {
            DrawWhiteKing(0,32, new Tile(TileTypes.Black), new Tile(TileTypes.White));
        }

        public void SetupWhiteQueen()
        {
            DrawWhiteQueen(0,24);
        }
        public void SetupBlackQueen()
        {
            DrawBlackQueen(56,24);
        }


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
            SetTile(startRow + n, startColumn + 5 , new Tile(TileTypes.Gold));
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
            SetTile(startRow + n, startColumn + 5 ,primaryTile);
            //SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 6
            n = 5;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            //SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, secondaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5 ,secondaryTile);
            SetTile(startRow + n, startColumn + 6, primaryTile);
            //SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 7
            n = 6;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, secondaryTile);
            SetTile(startRow + n, startColumn + 3, secondaryTile);
            SetTile(startRow + n, startColumn + 4, secondaryTile);
            SetTile(startRow + n, startColumn + 5 ,secondaryTile);
            SetTile(startRow + n, startColumn + 6, secondaryTile);
            SetTile(startRow + n, startColumn + 7, primaryTile);


            // Row 8
            n = 7;
            //SetTile(startRow + n, startColumn + 0, primaryTile);
            SetTile(startRow + n, startColumn + 1, primaryTile);
            SetTile(startRow + n, startColumn + 2, primaryTile);
            SetTile(startRow + n, startColumn + 3, primaryTile);
            SetTile(startRow + n, startColumn + 4, primaryTile);
            SetTile(startRow + n, startColumn + 5 ,primaryTile);
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


        public void DrawChessBoard()
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
        public void DebugBackground()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    SetTile(row, col, new Tile(TileTypes.Debug));
                }
            }
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
        public void DrawCoordinates()
        {
            // Top Left
            SetTile(0, 0, new Tile(TileTypes.Gold));
            // Top Right
            SetTile(0, Size - 1, new Tile(TileTypes.Gold));
            // Bottom Left
            SetTile(Size - 1, 0, new Tile(TileTypes.Gold));
            // Bottom Right
            SetTile(Size - 1, Size - 1, new Tile(TileTypes.Gold));
        }
        public void CenterIslandScene()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    int c = Size / 2;

                    int d = ((x - c) * (x - c)) + ((y - c) * (y - c));

                    if (d < 64)
                        SetTile(x, y, new Tile(TileTypes.Wood));
                    else
                        SetTile(x, y, new Tile(TileTypes.Water));
                }
            }
        }
        public void ChessBoardScene()
        {
            for (int x = 0;x < Size;x++)
            {
                for (int y = 0;y < Size;y++)
                {
                    if ((Size / 8) % (x +1) == 0)
                    {
                        SetTile(x, y, new Tile(TileTypes.Water));
                    }
                    else
                    {
                        SetTile(x, y, new Tile(TileTypes.Wood));
                    }
                }
            }
        }
    }
}

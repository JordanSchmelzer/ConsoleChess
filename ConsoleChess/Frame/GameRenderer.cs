using ConsoleChess.Pieces;
using System;

namespace ConsoleChess
{
    public class GameRenderer
    {
        public const int Size = 64;
        public const int PixelsPerSquare = 8;
        public Tile[] tiles = new Tile[Size * Size];

        public GameRenderer() {
            
        }

        public void GameOverScreen(EnumGameStatus e) {
            if (e == EnumGameStatus.WHITE_WIN) {
                Console.Clear();
                InitializeTilesWithDefaultType();
                DrawSquare(0,0, 64, new Tile(TileTypes.Gold));
            }

            if (e == EnumGameStatus.BLACK_WIN) {
                Console.Clear();
                InitializeTilesWithDefaultType();
                DrawSquare(0, 0, 64, new Tile(TileTypes.Gold));

            }

            TileType letterFill = TileTypes.Black;
            // G
            SetTileMap(18, 15, new Tile(letterFill));
            SetTileMap(18, 16, new Tile(letterFill));
            SetTileMap(18, 17, new Tile(letterFill));
            SetTileMap(18, 18, new Tile(letterFill));
            SetTileMap(18, 19, new Tile(letterFill));
            
            SetTileMap(19, 15, new Tile(letterFill));
            SetTileMap(20, 15, new Tile(letterFill));
            SetTileMap(21, 15, new Tile(letterFill));
            SetTileMap(22, 15, new Tile(letterFill));
            SetTileMap(23, 15, new Tile(letterFill));
            SetTileMap(24, 15, new Tile(letterFill));
            SetTileMap(25, 15, new Tile(letterFill));
            SetTileMap(26, 15, new Tile(letterFill));
            SetTileMap(27, 15, new Tile(letterFill));



            // A

            // M

            // E

            // O

            // V

            // E

            // R

            // !

            // Draw the tiles to the screen
            for (int row = 0; row < GameBoard.Size; row++) {
                for (int col = 0; col < GameBoard.Size; col++)
                {
                    GetTileMap(row, col).type.Render();
                }
                SetupNextLine();
            }
        }

        public void TypeGameOver()
        {
        }

        public void Render(GameBoard gameBoard) {
            Console.Clear();
            DrawGameBoardSquares();
            DrawGamePieces(gameBoard);
            DrawBoardSquareCoordinates();

            // Draw the tiles to the screen
            for (int row = 0; row < GameBoard.Size; row++) {
                for (int col = 0; col < GameBoard.Size; col++) {
                    GetTileMap(row, col).type.Render();
                }
                SetupNextLine();
            }
        }

        private void SetupNextLine() {
            // Prevents color from leaking to the right of tile
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                                                ");
            Console.Write('\n');
        }

        private Tile GetTileMap(int row, int col) {
            return tiles[col + (Size * row)];
        }


        // Primitive Drawing Tools
        public void DrawSquare(int startColumn, int startRow, int len, Tile tile) {
            for (int row = startRow; row < startRow + len; row++) {
                for (int col = startColumn; col < startColumn + len; col++) {
                    SetTileMap(row, col, tile);
                }
            }
        }

        public void DrawRectangle(int startColumn, int startRow, int width, int height, string text = "placeholder")
        {
            
        }
       
        private void SetTileMap(int row, int col, Tile tile) {
            tiles[col + (Size * row)] = tile;
        }

        public void InitializeTilesWithDefaultType() {
            for (int row = 0; row < Size; row++) {
                for (int col = 0; col < Size; col++) {
                    SetTileMap(row, col, new Tile(TileTypes.Debug));
                }
            }
        }

        // Assets
        public void DrawGameBoardSquares()
        {
            int boardTiles = 8;
            int boardPixel = 8;

            for (int i = 0; i < 8; i++)  {
                if (i % 2 == 0) {
                    DrawSquare(boardPixel * 0, i * boardPixel, boardTiles, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 1, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 2, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 3, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 4, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 5, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                    DrawSquare(boardPixel * 6, i * boardPixel, boardPixel, new Tile(TileTypes.DarkGreen));
                    DrawSquare(boardPixel * 7, i * boardPixel, boardPixel, new Tile(TileTypes.Grey));
                }
                else {
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

        public void DrawPreviewSquare(int startRow, int startColumn) {
            DrawSquare(startColumn, startRow, 8, new Tile(TileTypes.Cyan));
        }

        public void DrawBoardSquareCoordinates(){
            // Row 1
            int n = 0;
            SetTileMap(n, 0, new Tile(TileTypes.OneOne));
            SetTileMap(n, 8, new Tile(TileTypes.OneTwo));
            SetTileMap(n, 16, new Tile(TileTypes.OneThree));
            SetTileMap(n, 24, new Tile(TileTypes.OneFour));
            SetTileMap(n, 32, new Tile(TileTypes.OneFive));
            SetTileMap(n, 40, new Tile(TileTypes.OneSix));
            SetTileMap(n, 48, new Tile(TileTypes.OneSeven));
            SetTileMap(n, 56, new Tile(TileTypes.OneEight));
            // Row 2
            n = 8;
            SetTileMap(n, 0, new Tile(TileTypes.TwoOne));
            SetTileMap(n, 8, new Tile(TileTypes.TwoTwo));
            SetTileMap(n, 16, new Tile(TileTypes.TwoThree));
            SetTileMap(n, 24, new Tile(TileTypes.TwoFour));
            SetTileMap(n, 32, new Tile(TileTypes.TwoFive));
            SetTileMap(n, 40, new Tile(TileTypes.TwoSix));
            SetTileMap(n, 48, new Tile(TileTypes.TwoSeven));
            SetTileMap(n, 56, new Tile(TileTypes.TwoEight));
            // Row 3
            n = 16;
            SetTileMap(n, 0, new Tile(TileTypes.ThreeOne));
            SetTileMap(n, 8, new Tile(TileTypes.ThreeTwo));
            SetTileMap(n, 16, new Tile(TileTypes.ThreeThree));
            SetTileMap(n, 24, new Tile(TileTypes.ThreeFour));
            SetTileMap(n, 32, new Tile(TileTypes.ThreeFive));
            SetTileMap(n, 40, new Tile(TileTypes.ThreeSix));
            SetTileMap(n, 48, new Tile(TileTypes.ThreeSeven));
            SetTileMap(n, 56, new Tile(TileTypes.ThreeEight));
            // Row 4
            n = 24;
            SetTileMap(n, 0, new Tile(TileTypes.FourOne));
            SetTileMap(n, 8, new Tile(TileTypes.FourTwo));
            SetTileMap(n, 16, new Tile(TileTypes.FourThree));
            SetTileMap(n, 24, new Tile(TileTypes.FourFour));
            SetTileMap(n, 32, new Tile(TileTypes.FourFive));
            SetTileMap(n, 40, new Tile(TileTypes.FourSix));
            SetTileMap(n, 48, new Tile(TileTypes.FourSeven));
            SetTileMap(n, 56, new Tile(TileTypes.FourEight));
            // Row 5
            n = 32;
            SetTileMap(n, 0, new Tile(TileTypes.FiveOne));
            SetTileMap(n, 8, new Tile(TileTypes.FiveTwo));
            SetTileMap(n, 16, new Tile(TileTypes.FiveThree));
            SetTileMap(n, 24, new Tile(TileTypes.FiveFour));
            SetTileMap(n, 32, new Tile(TileTypes.FiveFive));
            SetTileMap(n, 40, new Tile(TileTypes.FiveSix));
            SetTileMap(n, 48, new Tile(TileTypes.FiveSeven));
            SetTileMap(n, 56, new Tile(TileTypes.FiveEight));
            // Row 6
            n = 40;
            SetTileMap(n, 0, new Tile(TileTypes.SixOne));
            SetTileMap(n, 8, new Tile(TileTypes.SixTwo));
            SetTileMap(n, 16, new Tile(TileTypes.SixThree));
            SetTileMap(n, 24, new Tile(TileTypes.SixFour));
            SetTileMap(n, 32, new Tile(TileTypes.SixFive));
            SetTileMap(n, 40, new Tile(TileTypes.SixSix));
            SetTileMap(n, 48, new Tile(TileTypes.SixSeven));
            SetTileMap(n, 56, new Tile(TileTypes.SixEight));
            // Row 7
            n = 48;
            SetTileMap(n, 0, new Tile(TileTypes.SevenOne));
            SetTileMap(n, 8, new Tile(TileTypes.SevenTwo));
            SetTileMap(n, 16, new Tile(TileTypes.SevenThree));
            SetTileMap(n, 24, new Tile(TileTypes.SevenFour));
            SetTileMap(n, 32, new Tile(TileTypes.SevenFive));
            SetTileMap(n, 40, new Tile(TileTypes.SevenSix));
            SetTileMap(n, 48, new Tile(TileTypes.SevenSeven));
            SetTileMap(n, 56, new Tile(TileTypes.SevenEight));
            // Row 8
            n = 56;
            SetTileMap(n, 0, new Tile(TileTypes.EightOne));
            SetTileMap(n, 8, new Tile(TileTypes.EightTwo));
            SetTileMap(n, 16, new Tile(TileTypes.EightThree));
            SetTileMap(n, 24, new Tile(TileTypes.EightFour));
            SetTileMap(n, 32, new Tile(TileTypes.EightFive));
            SetTileMap(n, 40, new Tile(TileTypes.EightSix));
            SetTileMap(n, 48, new Tile(TileTypes.EightSeven));
            SetTileMap(n, 56, new Tile(TileTypes.EightEight));
        }
        
        public void DrawGamePieces(GameBoard gameBoard)
        {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    BoardSquare boardSquare = gameBoard.GetBoardSquare(i, j);
                    // Check effects
                    if (boardSquare.getPreview()) {
                        DrawPreviewSquare(i * 8, j * 8);
                    }

                    // Check Pieces
                    if (boardSquare.getPiece() is Queen){
                        if (boardSquare.getPiece().isWhite()) {
                            DrawQueen(i * 8,j * 8, new Tile(TileTypes.White),new Tile(TileTypes.Black));
                        }
                        else {
                            DrawQueen(i * 8, j * 8, new Tile(TileTypes.DarkGrey), new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is King) {
                        if (boardSquare.getPiece().isWhite()) {
                            DrawKing(i * 8,j * 8, new Tile(TileTypes.White), new Tile(TileTypes.Black));
                        }
                        else {
                            DrawKing(i * 8,j * 8, new Tile(TileTypes.DarkGrey), new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Pawn) {
                        if (boardSquare.getPiece().isWhite()) {
                            DrawPawn(i * 8,j * 8, new Tile(TileTypes.White), new Tile(TileTypes.Black));
                        }
                        else {
                            DrawPawn(i * 8,j * 8, new Tile(TileTypes.DarkGrey),  new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Rook) {
                        if (boardSquare.getPiece().isWhite()) {
                            DrawRook(i * 8,j * 8, new Tile(TileTypes.White), new Tile(TileTypes.Black));
                        }
                        else {
                            DrawRook(i * 8, j * 8, new Tile(TileTypes.DarkGrey), new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Bishop) {
                        if (boardSquare.getPiece().isWhite()) {
                            DrawBishop(i * 8, j * 8, new Tile(TileTypes.White), new Tile(TileTypes.Black));
                        }
                        else {
                            DrawBishop(i * 8, j * 8,  new Tile(TileTypes.DarkGrey), new Tile(TileTypes.Black));
                        }
                    }
                    if (boardSquare.getPiece() is Knight) {
                        if (boardSquare.getPiece().isWhite()) {
                            DrawKnight(i * 8, j * 8, new Tile(TileTypes.White), new Tile(TileTypes.Black));
                        }
                        else {
                            DrawKnight(i * 8, j * 8, new Tile(TileTypes.DarkGrey), new Tile(TileTypes.Black));
                        }
                    }
                }
            }
        }

        public void DrawKnight(int startRow,int startColumn, Tile pieceColor,Tile borderColor) {
            // Row 1
            int n = 0;
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 2
            n = 1;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 3
            n = 2;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 4
            n = 3;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 5
            n = 4;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);

            // Row 6
            n = 5;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
        }

        public void DrawPawn(int startRow,int startColumn, Tile pieceColor,Tile borderColor) {
            // Row 1
            // Row 2
            int n = 1;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 3
            n = 2;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 4
            n = 3;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 5
            n = 4;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 6
            n = 5;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
        }

        public void DrawBishop(int startRow,int startColumn, Tile pieceColor,Tile borderColor) {
            // Row 1
            int n = 0;
            // Row 2
            n = 1;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            // Row 3
            n = 2;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 4
            n = 3;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 5
            n = 4;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
        }

        public void DrawKing(int startRow,int startColumn, Tile pieceColor,Tile borderColor) {
            // Row 1
            int n = 0;
            // Row 2
            n = 1;
            SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            // Row 3
            n = 2;
            SetTileMap(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTileMap(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            // Row 4
            n = 3;
            SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            // Row 5
            n = 4;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 7
            n = 6;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, pieceColor);
            SetTileMap(startRow + n, startColumn + 7, borderColor);
            // Row 8
            n = 7;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            SetTileMap(startRow + n, startColumn + 7, borderColor);
        }

        public void DrawQueen(int startRow, int startColumn, Tile pieceColor, Tile borderColor) {
            // Row 1
            int n = 0;
            SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            // Row 2
            n = 1;
            SetTileMap(startRow + n, startColumn + 3, new Tile(TileTypes.Gold));
            SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTileMap(startRow + n, startColumn + 5, new Tile(TileTypes.Gold));
            // Row 3
            n = 2;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 4, new Tile(TileTypes.Gold));
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 4
            n = 3;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 5
            n = 4;
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 7
            n = 6;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, pieceColor);
            SetTileMap(startRow + n, startColumn + 7, borderColor);
            // Row 8
            n = 7;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            SetTileMap(startRow + n, startColumn + 7, borderColor);
        }

        public void DrawRook(int startRow, int startColumn, Tile pieceColor, Tile borderColor) {
            // Row 1
            int n = 0;
            // Row 2
            n = 1;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 3
            n = 2;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 4
            n = 3;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 5
            n = 4;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 6
            n = 5;
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            // Row 7
            n = 6;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, pieceColor);
            SetTileMap(startRow + n, startColumn + 3, pieceColor);
            SetTileMap(startRow + n, startColumn + 4, pieceColor);
            SetTileMap(startRow + n, startColumn + 5, pieceColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
            // Row 8
            n = 7;
            SetTileMap(startRow + n, startColumn + 1, borderColor);
            SetTileMap(startRow + n, startColumn + 2, borderColor);
            SetTileMap(startRow + n, startColumn + 3, borderColor);
            SetTileMap(startRow + n, startColumn + 4, borderColor);
            SetTileMap(startRow + n, startColumn + 5, borderColor);
            SetTileMap(startRow + n, startColumn + 6, borderColor);
        }
    }
}

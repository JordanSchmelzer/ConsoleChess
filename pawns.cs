using System;

namespace ConsoleChess
{
    class WhitePawn
    {
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

    }
}

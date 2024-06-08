using ConsoleChess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Frame
    {
        public const int Size = 64;
        public const int PixelsPerSquare = 8;
        public Tile[] tiles = new Tile[Size * Size];
        public Game game;

        public Frame(Game game)
        {
            this.game = game;
        }

        public void Render()
        {
            Console.Clear();

            for (int row = 0; row < GameBoard.Size; row++)
            {
                for (int col = 0; col < GameBoard.Size; col++)
                {
                    GetTileMap(row, col).type.Render();
                }
                SetupNextLine();
            }
            if (game.currentTurn.whiteSide)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It is white's turn to move");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It is black's turn to move");
            }
        }

        public void SetupNextLine()
        {
            // Prevents color from leaking to the right of tile
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                                                ");
            Console.Write('\n');
        }

        public Tile GetTileMap(int row, int col)
        {
            return tiles[col + (Size * row)];
        }

        public void SetTileMap(int row, int col, Tile tile)
        {
            tiles[col + (Size * row)] = tile;
        }

        public void InitializeTilesWithDefaultType()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    SetTileMap(row, col, new Tile(TileTypes.Debug));
                }
            }
        }
    }
}

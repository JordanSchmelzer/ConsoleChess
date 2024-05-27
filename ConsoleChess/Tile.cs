using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Tile
    {
        public int health;
        public TileType type;

        public Tile(TileType type)
        {
            this.health = type.MaxHealth;
            this.type = type;
        }
    }

    public static class TileTypes
    {
        public static readonly TileType Air;
        public static readonly TileType Grass;
        public static readonly TileType Wood;
        public static readonly TileType Gold;
        public static readonly TileType Debug;
        public static readonly TileType Water;

        public static readonly TileType Grey;
        public static readonly TileType White;
        public static readonly TileType DarkGreen;
        public static readonly TileType Black;
        public static readonly TileType DarkGrey;


        static TileTypes()
        {
            Air = new TileType("Air", ConsoleColor.Cyan, ConsoleColor.White, "  ",0);
            Grass = new TileType("Grass", ConsoleColor.Green, ConsoleColor.DarkGreen, "  ",5);
            Wood = new TileType("Wood", ConsoleColor.Green, ConsoleColor.DarkRed, "  ", 10);
            Gold = new TileType("Gold", ConsoleColor.Yellow, ConsoleColor.DarkYellow, "  ", 15);
            Debug = new TileType("Debug", ConsoleColor.Magenta, ConsoleColor.DarkMagenta,"  ",100);
            Water = new TileType("Water", ConsoleColor.Cyan, ConsoleColor.DarkCyan, "  ", 100);

            Grey = new TileType("Grey", ConsoleColor.Gray, ConsoleColor.White, "  ", 100);
            DarkGrey = new TileType("DarkGrey", ConsoleColor.DarkGray, ConsoleColor.DarkGray, "  ", 100);
            White = new TileType("White", ConsoleColor.White, ConsoleColor.Gray, "  ", 100);
            DarkGreen = new TileType("DarkGreen", ConsoleColor.DarkGreen, ConsoleColor.Green, "  ", 100);
            Black = new TileType("Black", ConsoleColor.Black, ConsoleColor.Black, "  ", 100);
        }
    }

    public class TileType
    {
        public string Name { get; set; }
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor ForeColor { get; set; }
        public string RenderString { get; set; }
        public int MaxHealth { get; set; }

        public TileType(string name,
                        ConsoleColor backColor,
                        ConsoleColor foreColor,
                        string renderString,
                        int maxHealth)
        {
            this.Name = name;
            this.RenderString = renderString;
            this.BackColor = backColor;
            this.ForeColor = foreColor;
            this.MaxHealth = maxHealth;
        }

        public void Render()
        {
            Console.BackgroundColor = this.BackColor;
            Console.ForegroundColor = this.ForeColor;
            Console.Write(this.RenderString);
        }
    }
}

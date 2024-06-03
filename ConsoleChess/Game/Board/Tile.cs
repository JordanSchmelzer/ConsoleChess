using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Tile
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
        // Random stuff
        public static readonly TileType Air;
        public static readonly TileType Grass;
        public static readonly TileType Wood;
        public static readonly TileType Gold;
        public static readonly TileType Debug;
        public static readonly TileType Water;

        // Chess Board and Pieces
        public static readonly TileType Grey;
        public static readonly TileType White;
        public static readonly TileType DarkGreen;
        public static readonly TileType Black;
        public static readonly TileType DarkGrey;

        // Row 1
        public static readonly TileType OneOne;
        public static readonly TileType OneTwo;
        public static readonly TileType OneThree;
        public static readonly TileType OneFour;
        public static readonly TileType OneFive;
        public static readonly TileType OneSix;
        public static readonly TileType OneSeven;
        public static readonly TileType OneEight;
        // Row 2
        public static readonly TileType TwoOne;
        public static readonly TileType TwoTwo;
        public static readonly TileType TwoThree;
        public static readonly TileType TwoFour;
        public static readonly TileType TwoFive;
        public static readonly TileType TwoSix;
        public static readonly TileType TwoSeven;
        public static readonly TileType TwoEight;
        // Row 3
        public static readonly TileType ThreeOne;
        public static readonly TileType ThreeTwo;
        public static readonly TileType ThreeThree;
        public static readonly TileType ThreeFour;
        public static readonly TileType ThreeFive;
        public static readonly TileType ThreeSix;
        public static readonly TileType ThreeSeven;
        public static readonly TileType ThreeEight;
        // Row 4
        public static readonly TileType FourOne;
        public static readonly TileType FourTwo;
        public static readonly TileType FourThree;
        public static readonly TileType FourFour;
        public static readonly TileType FourFive;
        public static readonly TileType FourSix;
        public static readonly TileType FourSeven;
        public static readonly TileType FourEight;
        // Row 5
        public static readonly TileType FiveOne;
        public static readonly TileType FiveTwo;
        public static readonly TileType FiveThree;
        public static readonly TileType FiveFour;
        public static readonly TileType FiveFive;
        public static readonly TileType FiveSix;
        public static readonly TileType FiveSeven;
        public static readonly TileType FiveEight;
        // Row 6
        public static readonly TileType SixOne;
        public static readonly TileType SixTwo;
        public static readonly TileType SixThree;
        public static readonly TileType SixFour;
        public static readonly TileType SixFive;
        public static readonly TileType SixSix;
        public static readonly TileType SixSeven;
        public static readonly TileType SixEight;
        // Row 7
        public static readonly TileType SevenOne;
        public static readonly TileType SevenTwo;
        public static readonly TileType SevenThree;
        public static readonly TileType SevenFour;
        public static readonly TileType SevenFive;
        public static readonly TileType SevenSix;
        public static readonly TileType SevenSeven;
        public static readonly TileType SevenEight;
        // Row 8
        public static readonly TileType EightOne;
        public static readonly TileType EightTwo;
        public static readonly TileType EightThree;
        public static readonly TileType EightFour;
        public static readonly TileType EightFive;
        public static readonly TileType EightSix;
        public static readonly TileType EightSeven;
        public static readonly TileType EightEight;

        static TileTypes()
        {
            Air = new TileType("Air", ConsoleColor.Cyan, ConsoleColor.White, "  ",0);
            Grass = new TileType("Grass", ConsoleColor.Green, ConsoleColor.DarkGreen, "  ",5);
            Wood = new TileType("Wood", ConsoleColor.Green, ConsoleColor.DarkRed, "  ", 10);
            Debug = new TileType("Debug", ConsoleColor.Magenta, ConsoleColor.DarkMagenta,"  ",100);
            Water = new TileType("Water", ConsoleColor.Cyan, ConsoleColor.DarkCyan, "  ", 100);

            // Chess Board and Piece Colors
            Gold = new TileType("Gold", ConsoleColor.Yellow, ConsoleColor.DarkYellow, "  ", 15);
            Grey = new TileType("Grey", ConsoleColor.Gray, ConsoleColor.White, "  ", 100);
            DarkGrey = new TileType("DarkGrey", ConsoleColor.DarkGray, ConsoleColor.DarkGray, "  ", 100);
            White = new TileType("White", ConsoleColor.White, ConsoleColor.Gray, "  ", 100);
            DarkGreen = new TileType("DarkGreen", ConsoleColor.DarkGreen, ConsoleColor.Green, "  ", 100);
            Black = new TileType("Black", ConsoleColor.Black, ConsoleColor.Black, "  ", 100);

            // Coordinate Special Squares
            // Row 1
            OneOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a8", 100);
            OneTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b8", 100);
            OneThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c8", 100);
            OneFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d8", 100);
            OneFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e8", 100);
            OneSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f8", 100);
            OneSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g8", 100);
            OneEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h8", 100);        
            // Row 2
            TwoOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a7", 100);
            TwoTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b7", 100);
            TwoThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c7", 100);
            TwoFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d7", 100);
            TwoFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e7", 100);
            TwoSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f7", 100);
            TwoSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g7", 100);
            TwoEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h8", 100);  
            // Row 3
            ThreeOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a6", 100);
            ThreeTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b6", 100);
            ThreeThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c6", 100);
            ThreeFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d6", 100);
            ThreeFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e6", 100);
            ThreeSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f6", 100);
            ThreeSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g6", 100);
            ThreeEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h6", 100);     
            // Row 4
            FourOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a5", 100);
            FourTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b5", 100);
            FourThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c5", 100);
            FourFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d5", 100);
            FourFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e5", 100);
            FourSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f5", 100);
            FourSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g5", 100);
            FourEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h5", 100);   
            // Row 5
            FiveOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a4", 100);
            FiveTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b4", 100);
            FiveThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c4", 100);
            FiveFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d4", 100);
            FiveFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e4", 100);
            FiveSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f4", 100);
            FiveSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g4", 100);
            FiveEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h4", 100);        
            // Row 6            
            SixOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a3", 100);
            SixTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b3", 100);
            SixThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c3", 100);
            SixFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d3", 100);
            SixFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e3", 100);
            SixSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f3", 100);
            SixSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g3", 100);
            SixEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h3", 100);         
            // Row 7
            SevenOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a2", 100);
            SevenTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b2", 100);
            SevenThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c2", 100);
            SevenFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d2", 100);
            SevenFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e2", 100);
            SevenSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f2", 100);
            SevenSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g2", 100);
            SevenEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h2", 100);        
            // Row 8
            EightOne = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "a1", 100);
            EightTwo = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "b1", 100);
            EightThree = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "c1", 100);
            EightFour = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "d1", 100);
            EightFive = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "e1", 100);
            EightSix = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "f1", 100);
            EightSeven = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "g1", 100);
            EightEight = new TileType("OneOne", ConsoleColor.Cyan, ConsoleColor.Black, "h1", 100);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    class Knight: IGamePiece
    {
        public Knight(bool white) : base(white)
        {
            
        }

        override
        public bool canMove(World world, 
                            BoardSquare start, 
                            BoardSquare end)
        {
            // we can't move the piece to a spot that has 
            //a piece of the same colour 
            if (end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            int x = Math.Abs(start.getGameCol() - end.getGameCol());
            int y = Math.Abs(start.getGameRow() - end.getGameRow());
            return x * y == 2;
        }

        public override void Move()
        {
            Console.Write("");
        }
    }
}

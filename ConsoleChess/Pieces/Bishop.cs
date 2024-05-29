using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    internal class Bishop : IGamePiece
    {

        public Bishop(bool white) : base(white)
        {

        }
        override
        public bool canMove(World world, BoardSquare start, BoardSquare end)
        {
            // we can't move this piece to a spot that has a piece of the same color
            if (end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }
            return false;
        }
    }
}
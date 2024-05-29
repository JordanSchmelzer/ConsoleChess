using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    internal class Queen: IGamePiece
    {
        public Queen(bool white) : base(white)
        {

        }
        override
        public bool canMove(World world, BoardSquare start, BoardSquare end)
        {
            return true;
        }
    }
}

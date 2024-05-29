using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class King : GamePiece
    {
        private Boolean castlingDone =false;

        public King(bool white) : base(white)
        {

        }

        
        public bool canMove(World world, BoardSquare start, BoardSquare end)
        {
            // we can't move this piece to a spot that has a piece of the same color
            if (end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            int x = Math.Abs(start.getGameCol() - end.getGameCol());
            int y = Math.Abs(end.getGameRow() - end.getGameRow());

            if (x + y == 1)
            {
                // check if thi move will not result in the king being attacked, if so return ture
                return true;
            }

            return this.isValidCastling(world, start, end);
        }

        public bool isCastlingDone()
        {
            return this.castlingDone = true;
        }

        private bool isValidCastling(World world,
                                     BoardSquare start,
                                     BoardSquare end)
        {
            if (this.isCastlingDone())
            {
                return this.castlingDone;
            }

            // Logic for returning true or false
            return false;
        }

        public bool isCastlingMove(BoardSquare start, BoardSquare end)
        {
            // check if the starting and ending positin are correct
            return false;
        }
    }
}

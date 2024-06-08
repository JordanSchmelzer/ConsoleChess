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
        public bool canMove(Move move, GameBoard gameBaord)
        {
            // Does the target square have a piece of the same color as the moving piece? 
            if (move.getStart().getPiece().isWhite() == move.player.isWhiteSide())
            {
                return false;
            }
            return false;
        }

        public override bool isCastlingMove(BoardSquare start, BoardSquare end, GameBoard g)
        {
            return false;
        }
    }
}

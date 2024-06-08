using System;

namespace ConsoleChess
{
    public class King : IGamePiece
    {
        private bool castlingDone =false;
        private GameBoard board;

        public King(bool white) : base(white)
        {
            //this.board = board;
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


        public bool isCastlingDone()
        {
            return this.castlingDone = true;
        }

        private bool isValidCastling(GameBoard world,
                                     BoardSquare start,
                                     BoardSquare end)
        {
            if (this.isCastlingDone())
            {
                return false;
            }
            // Logic for returning true or false
            return false;
        }

        public override bool isCastlingMove(BoardSquare start, BoardSquare end, GameBoard g)
        {
            // check if the starting and ending positin are correct
            return this.isValidCastling(this.board, start, end);
        }
    }
}

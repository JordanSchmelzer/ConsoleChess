using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Move
    {
        private Player player;
        private BoardSquare start;
        private BoardSquare end;
        private IGamePiece pieceMoved;
        private IGamePiece pieceKilled;
        private bool castlingMove = false;

        public Move(Player player, BoardSquare start, BoardSquare end)
        {
            this.player = player;
            this.start = start;
            this.end = end;
            this.pieceMoved = start.getPiece();
        }

        public bool isCastlingMove()
        {
            return this.castlingMove;
        }

        public void setCastlingMove(bool castlingMove)
        {
            this.castlingMove = castlingMove;
        }

        public BoardSquare getStart()
        {
            return this.start;
        }

        public BoardSquare getEnd()
        {
            return this.end;
        }


    }
}

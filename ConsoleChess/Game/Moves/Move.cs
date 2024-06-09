using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Move
    {
        public Player player;
        private BoardSquare start;
        private BoardSquare end;
        private IGamePiece pieceMoved;
        private IGamePiece pieceKilled;
        private bool castlingMove = false;
        public EnumMoveDirections direction;

        public Move(Player player, BoardSquare start, BoardSquare end, GameBoard board)
        {
            this.player = player;
            this.start = start;
            this.end = end;
            this.pieceMoved = start.getPiece();
            this.direction = this.SetDirection();
        }
        public EnumMoveDirections SetDirection()
        {
            int startRow = start.GameCol;
            int startCol = start.GameRow;
            int endRow = end.GameCol;
            int endCol = end.GameRow;

            int deltaRow = -(endRow - startRow);
            int deltaCol = (endCol - startCol);

            // N
            if (deltaRow > 0 && deltaCol== 0)
            {
                return EnumMoveDirections.NORTH;
            }
            // NE
            if (deltaRow > 0 && deltaCol > 0)
            {
                return EnumMoveDirections.NORTHEAST;
            }
            // E
            if(deltaRow == 0 && deltaCol > 0)
            {
                return EnumMoveDirections.EAST;
            }
            // SE
            if (deltaRow < 0 && deltaCol > 0) 
            {
                return EnumMoveDirections.SOUTHEAST;
            }
            // S
            if (deltaRow < 0 && deltaCol == 0) 
            { 
                return EnumMoveDirections.SOUTH;
            }
            // SW
            if (deltaRow < 0 && deltaCol < 0) 
            { 
                return EnumMoveDirections.SOUTHWEST;
            }
            // W
            if (deltaRow == 0 && deltaCol < 0) 
            { 
                return EnumMoveDirections.WEST;
            }
            // NW
            if (deltaRow > 0 && deltaCol < 0) 
            {
                return EnumMoveDirections.NORTHWEST;
            }
            return EnumMoveDirections.NONE;
        }

        public int deltaRow()
        {
            int rowStart = start.GameCol;
            int rowEnd = end.GameCol;
            return rowEnd - rowStart;
        }
        public int deltaCol()
        {
            int colStart = start.GameRow;
            int colEnd = end.GameRow;
            return colEnd - colStart;
        }

       // public bool isCastlingMove(BoardSquare start, BoardSquare end)
        public bool isCastlingMove()
        {
            //// Is piece a king? 
            //if (start.getPiece() is King)
            //{
            //    // It is the same color as the player
            //    if (start.piece.isWhite())
            //    {
            //        // Is the king in the starting position?
            //        if(start.GameCol == 1 && start.GameRow == 5)
            //        {
            //            // Is the rook the King moves to in the original position?
            //            if ()
            //            {
            //                this.castlingMove = true;
            //                return this.castlingMove;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if(start.GameCol == 8 && start.GameRow == 5)
            //        {
            //            this.castlingMove = true;
            //            return this.castlingMove;
            //        }
            //    }
            //}
            //else
            //{
            //    return this.castlingMove;
            //}
            return true;
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

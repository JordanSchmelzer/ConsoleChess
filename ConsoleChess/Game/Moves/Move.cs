using System.Runtime.CompilerServices;

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
        public void SetPreviewSquare(bool isPreview)
        {
            this.end.setPreview(isPreview);
        }

        public void Execute()
        {
            this.end.setPiece(this.start.getPiece());
            this.start.setPiece(null);
        }

        public void PreviewMove()
        {
            this.getEnd().setPreview(true);
            this.getStart().setPreview(true);
        }
        public void ResetPreview()
        {
            this.getEnd().setPreview(false);
            this.getStart().setPreview(false);
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

        public bool isCastlingMove()
        {
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

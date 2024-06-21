using ConsoleChess.Pieces;
using System;

namespace ConsoleChess
{
    public class Move
    {
        public Player _player;
        public GameBoard _gameBoard;
        private BoardSquare _start;
        private BoardSquare _end;
        public EnumMoveDirections _direction;
        public bool _isCastle = false;
        public bool _isPawnPromotion = false;

        public Move(Player player, BoardSquare start, BoardSquare end, GameBoard board)
        {
            _player = player;
            _start = start;
            _end = end;
            _direction = this.SetDirection();
            _gameBoard = board;
        }

        public void SetPreviewSquare(bool isPreview)
        {
            _end.setPreview(isPreview);
        }

        public void Execute()
        {
            if (_isCastle)
            {
                PerformCastle();
            }

            _end.setPiece(_start.getPiece());
            _start.setPiece(null);

            if (_isPawnPromotion)
            {
                PromotePawn();
            }
        }

        private void PromotePawn()
        {
            bool isValid = true;
            do
            {
                Console.WriteLine("Promote Pawn. Type Piece type and press enter (pawn, rook, bishop, queen, knight)");
                string userInput = Console.ReadLine().Trim();

                switch (userInput)
                {
                    case "pawn":
                        isValid = true;
                        break;
                    case "rook":
                        _end.setPiece(new Rook(_player.isWhiteSide()));
                        isValid = true;
                        break;
                    case "bishop":
                        _end.setPiece(new Bishop(_player.isWhiteSide()));
                        isValid = true;
                        break;
                    case "queen":
                        _end.setPiece(new Queen(_player.isWhiteSide()));
                        isValid = true;
                        break;
                    case "knight":
                        _end.setPiece(new Knight(_player.isWhiteSide()));
                        isValid = true;
                        break;
                    default:
                        break;
                }

            } while (isValid = false);
            
        }

        private void PerformCastle()
        {
            if (!_player.isWhiteSide() && _direction == EnumMoveDirections.EAST)
            {
                CastleBlackRookEast();
            }
            if (_player.isWhiteSide() && _direction == EnumMoveDirections.EAST)
            {
                CastleWhiteRookEast();
            }
            if (!_player.isWhiteSide() && _direction == EnumMoveDirections.WEST)
            {
                CastleBlackRookWest();
            }
            if (_player.isWhiteSide() && _direction == EnumMoveDirections.WEST)
            {
                CastleWhiteRookWest();
            }
        }
        private void CastleWhiteRookEast()
        {
            _gameBoard.GetBoardSquare(7, 5).setPiece(_gameBoard.GetBoardSquare(7, 7).getPiece());
            _gameBoard.GetBoardSquare(7, 7).setPiece(null);
        }
        private void CastleWhiteRookWest()
        {
            _gameBoard.GetBoardSquare(7, 3).setPiece(_gameBoard.GetBoardSquare(7, 0).getPiece());
            _gameBoard.GetBoardSquare(7, 0).setPiece(null);
        }
        private void CastleBlackRookEast()
        {
            _gameBoard.GetBoardSquare(0, 5).setPiece(_gameBoard.GetBoardSquare(0, 7).getPiece());
            _gameBoard.GetBoardSquare(0, 7).setPiece(null);
        }
        private void CastleBlackRookWest()
        {
            _gameBoard.GetBoardSquare(0, 3).setPiece(_gameBoard.GetBoardSquare(0, 0).getPiece());
            _gameBoard.GetBoardSquare(0, 0).setPiece(null);
        }

        public void Undo()
        {
            _start.setPiece(_end.getPiece());
            _end.setPiece(null);
            ResetPreview();
        }
        public void PreviewMove()
        {

            _end.setPreview(true);
            _start.setPreview(true);
            Execute();
        }
        public void ResetPreview()
        {
            _end.setPreview(false);
            _start.setPreview(false);
        }

        public EnumMoveDirections SetDirection()
        {
            int startRow = _start.GameCol;
            int startCol = _start.GameRow;
            int endRow = _end.GameCol;
            int endCol = _end.GameRow;

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
            int rowStart = _start.GameCol;
            int rowEnd = _end.GameCol;
            return rowEnd - rowStart;
        }
        public int deltaCol()
        {
            int colStart = _start.GameRow;
            int colEnd = _end.GameRow;
            return colEnd - colStart;
        }

        public bool isCastlingMove()
        {
            return true;
        }

        public BoardSquare getStart()
        {
            return _start;
        }
        public BoardSquare getEnd()
        {
            return _end;
        }
    }
}

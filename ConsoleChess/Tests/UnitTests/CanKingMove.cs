using Xunit;
using FluentAssertions;
using ConsoleChess.Pieces;

namespace ConsoleChess.Tests.UnitTests
{
    public class GamePieceMovementTests
    {
        [Fact]
        public void CanBlackKingCastleRight()
        {
            // Arrange
            GameBoard board = new GameBoard();
            board.InitializeAllSquaresNull();
            board.PlacePiece(0,0,new Rook(false));
            board.PlacePiece(0,7,new Rook(false));
            board.PlacePiece(0,4,new King(false));

            BoardSquare startSquare = board.GetBoardSquare(0, 4);
            BoardSquare endSquare = board.GetBoardSquare(0, 6);

            Player whitePlayer = new HumanPlayer(true);

            Move move = new Move(whitePlayer,startSquare, endSquare, board);

            // Act
            bool canCastleRight = board.GetBoardSquare(0, 4)
                               .getPiece()
                               .canMove(move);

            // Assert
            canCastleRight.Should()
                  .BeTrue();
        }

        [Fact]
        public void CanBlackKingCastleLeft()
        {
            // Arrange
            GameBoard board = new GameBoard();
            board.InitializeAllSquaresNull();
            board.PlacePiece(0, 0, new Rook(false));
            board.PlacePiece(0, 7, new Rook(false));
            board.PlacePiece(0, 4, new King(false));

            BoardSquare startSquare = board.GetBoardSquare(0, 4);
            BoardSquare endSquare = board.GetBoardSquare(0, 6);

            Player whitePlayer = new HumanPlayer(true);

            Move move = new Move(whitePlayer, startSquare, endSquare, board);

            // Act
            bool canCastleRight = board.GetBoardSquare(0, 4)
                               .getPiece()
                               .canMove(move);

            // Assert
            canCastleRight.Should()
                  .BeTrue();
        }

        [Fact]
        public void CanWhiteKingCastleRight()
        {
            // Arrange
            GameBoard board = new GameBoard();
            board.InitializeAllSquaresNull();
            board.PlacePiece(0, 0, new Rook(false));
            board.PlacePiece(0, 7, new Rook(false));
            board.PlacePiece(0, 4, new King(false));

            BoardSquare startSquare = board.GetBoardSquare(0, 4);
            BoardSquare endSquare = board.GetBoardSquare(0, 6);

            Player whitePlayer = new HumanPlayer(true);

            Move move = new Move(whitePlayer, startSquare, endSquare, board);

            // Act
            bool canCastleRight = board.GetBoardSquare(0, 4)
                               .getPiece()
                               .canMove(move);

            // Assert
            canCastleRight.Should()
                  .BeTrue();

        }

        [Fact]
        public void CanWhiteKingCastleLeft() 
        {
            // Arrange
            GameBoard board = new GameBoard();
            board.InitializeAllSquaresNull();
            board.PlacePiece(0, 0, new Rook(false));
            board.PlacePiece(0, 7, new Rook(false));
            board.PlacePiece(0, 4, new King(false));

            BoardSquare startSquare = board.GetBoardSquare(0, 4);
            BoardSquare endSquare = board.GetBoardSquare(0, 6);

            Player whitePlayer = new HumanPlayer(true);

            Move move = new Move(whitePlayer, startSquare, endSquare, board);

            // Act
            bool canCastleRight = board.GetBoardSquare(0, 4)
                               .getPiece()
                               .canMove(move);

            // Assert
            canCastleRight.Should()
                  .BeTrue();
        }
    }
}

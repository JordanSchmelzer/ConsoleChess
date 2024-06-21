using System;

namespace ConsoleChess.Pieces
{
    internal class Pawn : IGamePiece
    {
        public Pawn(bool white) : base(white) { }

        override
        public bool canMove(Move move)
        {
            if (IsTargetMyOwnPiece(move) == true) { return false; }
            if (IsPawnMoveForward(move) == false) { return false; }
            
            if (IsValidTwoForwardSquareMove(move)) { return true; }
            if (IsValidDiagonalCapture(move)) { return true; }
            if (IsValidEnPassant(move)) { return true; }
            if (IsOneSquareFormwardMove(move)) { return true; }

            Console.WriteLine("Invalid Move! Reason: Not a recognized valid move.");
            return false;
        }
        private bool IsValidTwoForwardSquareMove(Move move)
        {
            // If making a 2 square move north or south, determine if in starting position
            if ((Math.Abs(move.deltaRow()) == 2) &&
                (move.deltaCol() == 0))
            {
                if (!this.HasMoved() && move.getEnd().getPiece() == null)
                {
                    // if there is no piece in the middle
                    if (move.getStart().getPiece().isWhite())
                    {
                        // check white forward
                        BoardSquare nextSquareForward = move._gameBoard.GetBoardSquare(move.getStart().getGameCol() - 1,
                                                                                 move.getStart().getGameRow());
                        if (nextSquareForward.getPiece() == null)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        // check black forward
                        BoardSquare nextSquareForward = move._gameBoard.GetBoardSquare(move.getStart().getGameCol() + 1,
                                                                                 move.getStart().getGameRow());
                        if (nextSquareForward.getPiece() == null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool IsValidDiagonalCapture(Move move)
        {
            if (Math.Abs(move.deltaCol()) == 1 &&
                Math.Abs(move.deltaRow()) == 1 &&
                (move.getEnd().getPiece() != null))
            {
                Console.WriteLine("Log: Diagonal Capture Accepted");
                return true;
            }
            return false;
        }
        private bool IsOneSquareFormwardMove(Move move)
        {
            // Is this a normal one forward square move?
            if ((Math.Abs(move.deltaRow()) == 1 && move.deltaCol() == 0))
            {
                // is this a pawn promotion move?
                if (move._player.isWhiteSide())
                {
                    if(move.getEnd().getGameRow() == 0)
                    {
                        move._isPawnPromotion = true;
                    }
                }
                else
                {
                    if (move.getEnd().getGameRow() == 7)
                    {
                        move._isPawnPromotion = true;
                    }
                }

                Console.WriteLine("1 square forward move accepted");
                return true;
            }
            return false;
        }
        private bool IsValidEnPassant(Move move)
        {
            // Is en-passant?
            if (!move.getStart().getPiece().HasMoved())
            {
                if (Math.Abs(move.deltaRow()) == 2 &&
                    Math.Abs(move.deltaCol()) == 1)
                {
                    if (move.getEnd().getPiece() != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsPawnMoveForward(Move move)
        {
            // Check forward movement
            if (move._player.isWhiteSide())
            {
                // white forward is negative GameRow
                if (move.deltaRow() > 0)
                {
                    return false;
                }
            }
            else
            {
                // black forward is positive GameRow
                if (move.deltaRow() < 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsTargetMyOwnPiece(Move move)
        {
            IGamePiece endPiece = move.getEnd().getPiece();
            IGamePiece startPiece = move.getStart().getPiece();

            if (endPiece != null)
            {
                if (endPiece.isWhite() == startPiece.isWhite())
                {
                    return true;
                }
            }
            return false;
        }
        public override bool isCastlingMove(Move move)
        {
            return false;
        }
        public bool IsPiecePromotion()
        {
            // TODO: Impliment this 
            return false;
        }
    }
}

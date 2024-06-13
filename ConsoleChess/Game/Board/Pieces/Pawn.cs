using System;

namespace ConsoleChess.Pieces
{
    internal class Pawn : IGamePiece
    {

        public Pawn(bool white) : base(white)
        {

        }

        override
        public bool canMove(Move move)
        {
            // Does the target square have a piece of the same color as the moving piece? 
            if (move.getEnd().getPiece() != null)
            {
                if (move.getStart().getPiece().isWhite() ==
                   (move.getEnd().getPiece().isWhite()))
                {
                    return false;
                }
            }

            // Check if causes check
            // TODO: build this

            // Check forward movement
            //Console.WriteLine($"Log: Check forward movement; move.deltaRow() = {move.deltaRow()}");
            if (move.player.isWhiteSide()) 
            {
                // white forward is negative GameRow
                if(move.deltaRow() > 0)
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
                        BoardSquare nextSquareForward = move.gameBoard.GetBoardSquare(move.getStart().getGameCol() - 1,
                                                                                 move.getStart().getGameRow());
                        if (nextSquareForward.getPiece() == null)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        // check black forward
                        BoardSquare nextSquareForward = move.gameBoard.GetBoardSquare(move.getStart().getGameCol() + 1,
                                                                                 move.getStart().getGameRow());
                        if (nextSquareForward.getPiece() == null)
                        {
                            return true;
                        }
                    }
                }
            }

            // Check diagonal capture
            if (Math.Abs(move.deltaCol()) == 1 && 
                Math.Abs(move.deltaRow()) == 1 &&
                (move.getEnd().getPiece() != null))
            {
                Console.WriteLine("Log: Diagonal Capture Accepted");
                return true;
            }

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

            // Is this a normal one forward square move?
            if ((Math.Abs(move.deltaRow()) == 1 && move.deltaCol() == 0))
            {
                Console.WriteLine("1 square forward move accepted");
                return true;
            }

            Console.WriteLine("Invalid Move! Reason: Not a recognized valid move.");
            return false;
        }

        public override bool isCastlingMove(Move move)
        {
            return false;
        }
    }
}

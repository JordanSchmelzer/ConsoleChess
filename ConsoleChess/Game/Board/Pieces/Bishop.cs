using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Pieces
{
    internal class Bishop : IGamePiece
    {

        public Bishop(bool white) : base(white) { }
    
        override
        public bool canMove(Move move)
        {
            IGamePiece endPiece = move.getEnd().getPiece();
            IGamePiece startPiece = move.getStart().getPiece();
            int deltaRow = move.deltaRow();
            int deltaCol = move.deltaCol();
            int absDeltaRow = Math.Abs(deltaRow);
            int absDeltaCol = Math.Abs(deltaCol);

            // dont let player take their own piece
            if (endPiece != null)
            {
                if (endPiece.isWhite() == startPiece.isWhite()) 
                { 
                    return false;
                }
            }

            //  Diagonal moves are always an equal ratio
            if (absDeltaRow == 0 || absDeltaCol == 0) { return false; }
            if (absDeltaRow / absDeltaCol != 1) { return false; }

            // disallow ordinal moves move
            if (move.direction == EnumMoveDirections.NORTH || move.direction == EnumMoveDirections.EAST ||
                move.direction == EnumMoveDirections.SOUTH || move.direction == EnumMoveDirections.WEST)
            { 
                return false;
            }

            // set the vector of motion
            int rowIterator=0;
            int colIterator=0;

            if (move.direction == EnumMoveDirections.NORTHEAST)
            {
                rowIterator = -1;
                colIterator = 1;
            }
            if (move.direction == EnumMoveDirections.SOUTHEAST)
            {
                rowIterator = 1;
                colIterator = 1;
            }
            if (move.direction == EnumMoveDirections.SOUTHWEST)
            {
                rowIterator = 1;
                colIterator = -1;
            }
            if (move.direction == EnumMoveDirections.NORTHWEST)
            {
                rowIterator = -1;
                colIterator = -1;
            }

            // Gameboard layout example:
            // Top Left Black Rook gameboard[0,0]
            // Bottom Right White Rook gameboard[7,7]

            // Are there any pieces in the way of this move?
            int startRow = move.getStart().GameCol;
            int startCol = move.getStart().GameRow;
            for (int i =  1; i < absDeltaCol ; i++)
            {
                int shiftRow = rowIterator * i;
                int shiftCol = colIterator * i;

                Console.WriteLine($"Move Multiplier: {i}; Shifting row {shiftRow}; shifting column {shiftCol}");

                int nextRow = shiftRow + startRow;
                int nextCol = shiftCol + startCol;

                Console.WriteLine($"Original BoardSquare ({startRow},{startCol}) " +
                    $"-> New BoardSquare ({nextRow},{nextCol})");

                BoardSquare boardSquare = 
                    move.gameBoard.GetBoardSquare(nextRow, nextCol);
                Console.WriteLine($"gameBoard Row {nextRow}; gameBoard Col {nextCol}; Piece {boardSquare.piece}; IsWhite ");
                if (boardSquare.getPiece() != null)
                {
                    return false;
                }
            }

            // This is a capture move
            if (endPiece != null)
            {
                Console.WriteLine("Log: Diagonal Capture Accepted");
                return true;
            }
            // this is a move
            if (endPiece == null)
            {
                Console.WriteLine("Log: Diagonal Move Accepted");
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
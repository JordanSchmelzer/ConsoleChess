using ConsoleChess.Pieces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleChess
{
    public class Game
    {
        private readonly ILogger<Game> _logger;

        private GameRenderer gameRenderer;
        private GameBoard gameBoard;

        private Player[] players = new Player[2];
        public Player currentTurn;
        public EnumGameStatus gameStatus;
        public List<Move> movesPlayed = new List<Move>();
        public static HumanPlayer p1 = new HumanPlayer(true);
        public static HumanPlayer p2 = new HumanPlayer(false);

        public Game() {
            gameRenderer = new GameRenderer();
        }

        private void Initialize(Player p1, Player p2) {
            this.gameStatus = EnumGameStatus.ACTIVE;
            this.gameBoard = new GameBoard();
            this.gameBoard.ResetChessPiecesOnBoard();

            players[0] = p1;
            players[1] = p2;

            if (p1.isWhiteSide()) {
                this.currentTurn = p1;
            }
            else {
                this.currentTurn = p2;
            }
            movesPlayed.Clear();
        }

        public EnumGameStatus Run() {
            Initialize(p1,p2);
            do
            {
                gameRenderer.Render(gameBoard);
                PrintUserInputMenu();

                string userInput = ReadLine();
                switch (ParseUserInputCommand(userInput.Trim()))
                {
                    case EnumUserCommandType.MOVE:
                        if (PlayerMove(userInput)) {
                            // if the move is valid does the enemy king have any moves left?
                            if (isGameOver(gameBoard, currentTurn))
                            {
                                Console.WriteLine("GAME OVER!");
                                return 0;
                            }
                            SwitchActivePlayer();
                        }
                        break;

                    case EnumUserCommandType.INVALID:
                        break;

                    case EnumUserCommandType.FOREFIT:
                        WriteLine($"FF detected");
                        return 0;
                }
            } while (this.gameStatus == EnumGameStatus.ACTIVE);

            return 0;
        }

        private bool isGameOver(GameBoard board, Player player) {
            BoardSquare enemyKingSquare = ReturnEnemyKingBoardSquare();
            if (enemyKingSquare == null) {
                return true; 
            }
            // if enemy king has no possible moves current player wins


            return false;
        }
            
        private void PrintUserInputMenu() {
            // Consider another object to manage this state
            ForegroundColor = ConsoleColor.Cyan;
            if (currentTurn.whiteSide) {
                WriteLine("[Turn] It's White's turn to move!");
            }
            else {
                WriteLine("[Turn] It's Black's turn to move!");
            }
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("[Move Syntax ] <Start Coordinates><SPACE><End Coordinates> [ex: b2 b4]");

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Enter Move:");
        }

        private int DecodeMoveCommand(string inputString)
        {
            if (int.TryParse(inputString, out int parsedValue))
            {
                return parsedValue;
            }
            else
            {
                switch (inputString)
                {
                    case "a": return 1;
                    case "b": return 2;
                    case "c": return 3;
                    case "d": return 4;
                    case "e": return 5;
                    case "f": return 6;
                    case "g": return 7;
                    case "h": return 8;
                    default: return 99;
                }
            }
        }

        public bool PlayerMove(string playerInput)
        {
            int startX = 8 - DecodeMoveCommand(Convert.ToString(playerInput[1]));
            int startY = DecodeMoveCommand(Convert.ToString(playerInput[0])) - 1;
            int endX = 8 - DecodeMoveCommand(Convert.ToString(playerInput[4]));
            int endY = DecodeMoveCommand(Convert.ToString(playerInput[3])) - 1;

            BoardSquare startBox = gameBoard.GetBoardSquare(startX, startY);
            BoardSquare endBox = gameBoard.GetBoardSquare(endX, endY);
            Move move = new Move(currentTurn, startBox, endBox, gameBoard);
            
            if (!IsMyTurn(move)) {
                return false; 
            }

            if (move.getStart().getPiece() == null) {
                return false; 
            }

            // is the players king in check?
            if (IsPlayersKingInCheck(move)) {
                // if its in check, does the move end check?
                move.getEnd().setPiece(move.getStart().getPiece());
                if (IsPlayersKingInCheck(move)) {
                    move.getStart().setPiece(move.getEnd().getPiece());
                    move.getEnd().setPiece(null);
                    Console.WriteLine("King is in check.");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey();
                    return false;
                }
                move.getEnd().setPiece(null);
            }
            // is the piece pinned by an attack?
            else
            {
                move.getEnd().setPiece(move.getStart().getPiece());
                move.getStart().setPiece(null);
                if (IsPlayersKingInCheck(move)) {
                    move.getStart().setPiece(move.getEnd().getPiece());
                    move.getEnd().setPiece(null);
                    Console.WriteLine("Piece is pinned! King would be in check if moved.");
                    Console.WriteLine("Press any key to continue. . .");
                    Console.ReadKey(true);
                    return false;
                }
                move.getStart().setPiece(move.getEnd().getPiece());
                move.getEnd().setPiece(null);
            }

            // is the player taking back or committing?
            if (move.getStart().getPiece().CanMove(move)) {
                move.PreviewMove();
                gameRenderer.Render(gameBoard);
                if (TakeBackMove(move)) { 
                    return false; 
                }
                return true;
            }
            else {
                WriteLine($"Invalid move! {playerInput} \nPress any key to continue. . .");
                ReadKey(true);
                return false;
            }
        }

        private bool IsMyTurn(Move move)
        {
            if ( move.getStart().getPiece() != null)
            {
                if (currentTurn.isWhiteSide() != move.getStart().getPiece().isWhite())
                {
                    return false;
                }
            }
            return true;
        }

        private bool TakeBackMove(Move move)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Keep Move? (Press 'n' to undo or any key to keep)");

            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.N || keyPressed == ConsoleKey.U)
            {
                move.Undo();
                //gameRenderer.Render(gameBoard);
                move.ResetPreview();
                return true;
            }
            move.ResetPreview();
            return false;
        }

        private EnumUserCommandType ParseUserInputCommand(string userInput)
        {
            if (
                (userInput.Length == 5) &&
                (Char.IsLetter(userInput[0])) &&
                (Char.IsNumber(userInput[1])) &&
                (userInput[2] == ' ' ) &&
                (Char.IsLetter(userInput[3])) &&
                (Char.IsNumber(userInput[4]))
                )
            {
                return EnumUserCommandType.MOVE;
            }
            if (userInput == "ff")
            {
                this.SetStatus(EnumGameStatus.FOREFIT);
            }
            return EnumUserCommandType.INVALID;
        }

        private void SetStatus(EnumGameStatus status)
        {
            this.gameStatus = status;
        }

        private void SwitchActivePlayer()
        {
            if (this.currentTurn == players[0])
            {
                this.currentTurn = players[1];
            }
            else
            {
                this.currentTurn = players[0];
            }
        }

        public bool IsPlayersKingInCheck(Move move)
        {
            BoardSquare kingSquare = ReturnPlayersKingBoardSquare(move);
            List<BoardSquare> attackVectors = PottentialAttackersBoardSquares(move, kingSquare);
            List<BoardSquare> activeThreats = AttackingPieces(move, attackVectors, kingSquare);

            // of all the potential attack squares, there are no pieces able to attack the king
            if (activeThreats.Count == 0)
            {
                return false;
            }
            if (activeThreats.Count > 0)
            {
                return true;
            }
            return false;
        }

        private List<BoardSquare> AttackingPieces(Move move,
                                                 List<BoardSquare> potentialAttackers,
                                                 BoardSquare kingSquare) {
            List<BoardSquare> activeThreats = new List<BoardSquare>(potentialAttackers.Count);
            if (potentialAttackers.Count == 0) {
                return activeThreats;
            }

            // check to see if any of these pieces are able to attack the kingsquare
            foreach (BoardSquare potentialAttackerSquare in potentialAttackers) {
                if (potentialAttackerSquare != null) {
                    Move checkMove = new Move(move._player,
                                              potentialAttackerSquare,
                                              kingSquare,
                                              move._gameBoard);

                    if (potentialAttackerSquare.piece.CanMove(checkMove)) {
                        Console.WriteLine($"King is in check from: {potentialAttackerSquare.piece}");
                        activeThreats.Add(potentialAttackerSquare);
                    }
                }
            }
            return activeThreats;
        }

        private List<BoardSquare> PottentialAttackersBoardSquares(Move move, BoardSquare kingSquare) {
            // List all of the squares that can directly see the king with no piece inbetween
            List<BoardSquare> attackVectors = new List<BoardSquare>();
            BoardSquare boardSquare;

            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.SOUTH, move._player);
            if (boardSquare != null) {
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.NORTH, move._player);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.EAST, move._player);
            if (boardSquare != null) {
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.WEST, move._player);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare);
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.NORTHEAST, move._player);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare);
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.NORTHWEST, move._player);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.SOUTHWEST, move._player);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(move._gameBoard, kingSquare, EnumMoveDirections.SOUTHEAST, move._player);
            if (boardSquare != null) {
                attackVectors.Add(boardSquare); 
            }

            BoardSquare potentialKnight;

            // NorthEast       
            potentialKnight = PotentialKnightAttacker(move, kingSquare, -2, 1);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight);
            }
            potentialKnight = PotentialKnightAttacker(move, kingSquare, -1, 2);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight); 
            }
            // SouthEast
            potentialKnight = PotentialKnightAttacker(move, kingSquare, 1, 2);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight);
            }
            potentialKnight = PotentialKnightAttacker(move, kingSquare, 2, 1);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight);
            }
            // SouthWest
            potentialKnight = PotentialKnightAttacker(move, kingSquare, 2, -1);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight); 
            }
            potentialKnight = PotentialKnightAttacker(move, kingSquare, 1, -2);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight);
            }
            // NorthWest
            potentialKnight = PotentialKnightAttacker(move, kingSquare, -1, -2);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight); 
            }
            potentialKnight = PotentialKnightAttacker(move, kingSquare, -2, -11);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight); 
            }

            return attackVectors;
        }

        private BoardSquare PotentialKnightAttacker(Move move, BoardSquare kingSquare, int row, int col) {
            int kingSquareRow = kingSquare.getGameRow();
            int kingSquareCol = kingSquare.getGameCol();
            int deltaRow = kingSquareRow + row;
            int deltaCol = kingSquareCol + col;

            if (deltaCol > 8 && deltaCol <= 0 &&
                deltaRow > 8 && deltaRow <= 0) {
                BoardSquare potentialKnight = move._gameBoard.GetBoardSquare(deltaRow, deltaCol);
                if (potentialKnight.getPiece() is Knight &&
                    potentialKnight.getPiece().isWhite() !=
                    move._player.isWhiteSide()) {
                    return potentialKnight;
                }
            }
            return null;
        }

        private BoardSquare ReturnEnemyKingBoardSquare() {
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if (gameBoard.GetBoardSquare(row, col).getPiece() is King &&
                       gameBoard.GetBoardSquare(row, col).getPiece().isWhite() != 
                       currentTurn.isWhiteSide()) {
                        return gameBoard.GetBoardSquare(row, col);
                    }
                }
            }
            return null;
        }

        private BoardSquare ReturnPlayersKingBoardSquare(Move move) {
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if (move._gameBoard.GetBoardSquare(row, col).getPiece() is King &&
                       move._gameBoard.GetBoardSquare(row, col).getPiece().isWhite() == move._player.isWhiteSide()) {
                        return move._gameBoard.GetBoardSquare(row, col);
                    }
                }
            }
            return null;
        }

        private BoardSquare FirstVisiblePieceInDirection(GameBoard board, BoardSquare pieceSquare,
                                                        EnumMoveDirections direction, Player player) {
            Tuple<int, int> scanVector = ReturnRowAndColScanDirections(direction);
            int rowIterator = scanVector.Item1;
            int colIterator = scanVector.Item2;
            int startRow = pieceSquare.GameCol;
            int startCol = pieceSquare.GameRow;

            for (int i = 1; i < 8; i++) {
                int nextRow = (rowIterator * i) + startRow;
                int nextCol = (colIterator * i) + startCol;

                if (nextRow > 7 || nextCol > 7 || nextRow < 0 || nextCol < 0) { 
                    return null; 
                }

                BoardSquare nextSquare = board.GetBoardSquare(nextRow, nextCol);
                if (nextSquare.piece != null) {
                    if (nextSquare.piece.isWhite() != player.isWhiteSide()) {
                        return nextSquare;
                    }
                    return null;
                }
            }
            return null;
        }

        public Tuple<int, int> ReturnRowAndColScanDirections(EnumMoveDirections direction) {
            int rowIterator = 0;
            int colIterator = 0;

            if (direction == EnumMoveDirections.NORTH) {
                rowIterator = -1;
                colIterator = 0;
            }
            if (direction == EnumMoveDirections.EAST)  {
                rowIterator = 0;
                colIterator = 1;
            }
            if (direction == EnumMoveDirections.SOUTH) {
                rowIterator = 1;
                colIterator = 0;
            }
            if (direction == EnumMoveDirections.WEST) {
                rowIterator = 0;
                colIterator = -1;
            }
            if (direction == EnumMoveDirections.NORTHEAST) {
                rowIterator = -1;
                colIterator = 1;
            }
            if (direction == EnumMoveDirections.SOUTHEAST) {
                rowIterator = 1;
                colIterator = 1;
            }
            if (direction == EnumMoveDirections.SOUTHWEST)  {
                rowIterator = 1;
                colIterator = -1;
            }
            if (direction == EnumMoveDirections.NORTHWEST) {
                rowIterator = -1;
                colIterator = -1;
            }

            return new Tuple<int, int>(rowIterator, colIterator);
        }
    }
}

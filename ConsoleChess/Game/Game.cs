﻿using ConsoleChess.Pieces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleChess
{
    public class Game
    {
        //private readonly ILogger<Game> _logger;

        private GameRenderer gameRenderer;
        private GameBoard gameBoard;

        private Player[] players = new Player[2];
        public Player currentPlayer;
        public Player enemyPlayer;
        public EnumGameStatus gameStatus;
        public List<Move> movesPlayed = new List<Move>();
        public static HumanPlayer p1 = new HumanPlayer(true);
        public static HumanPlayer p2 = new HumanPlayer(false);

        public Game() { 
            gameRenderer = new GameRenderer();
            gameRenderer.InitializeTilesWithDefaultType();
        }

        private void Initialize(Player p1, Player p2) {
            this.gameStatus = EnumGameStatus.ACTIVE;
            this.gameBoard = new GameBoard();
            this.gameBoard.ResetChessPiecesOnBoard();

            players[0] = p1;
            players[1] = p2;

            if (p1.isWhiteSide()) {
                this.currentPlayer = p1;
                this.enemyPlayer = p2;
            }
            else {
                this.currentPlayer = p2;
                this.enemyPlayer = p1;
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
                            if (isGameOver(gameBoard, currentPlayer))
                            {
                                if (currentPlayer.isWhiteSide()){
                                    WriteLine("Checkmate! White Wins!");
                                    WriteLine("Press any key to return to menu. . .");
                                    ReadKey(true);
                                    return EnumGameStatus.WHITE_WIN;
                                }
                                else{
                                    WriteLine("Checkmate! Black Wins!");
                                    WriteLine("Press any key to return to menu. . .");
                                    ReadKey(true);
                                    return EnumGameStatus.BLACK_WIN;
                                }
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
            // did the current players valid move end the game?
            BoardSquare enemyKingSquare = ReturnEnemyKingBoardSquare();
            if (enemyKingSquare == null) {
                return true; 
            }
            // is the enemy king in check?
            List<BoardSquare> attackVectors = PottentialAttackersBoardSquares(enemyKingSquare);
            List<BoardSquare> activeThreats = AttackingPieces(attackVectors, enemyKingSquare);
            if (activeThreats.Count == 0) {
                return false;
            }

            // if yes, return list of moves the enemy can make
            List<BoardSquare> enemyPieceLocations = ListOfPlayerPieceLocations(enemyPlayer);
            List<Move> possibleMoves = ListOfPossiblePlayerMoves(enemyPieceLocations, enemyPlayer);
            // does any of these moves end check?
            int validMovesCounter = 0;
            foreach (Move move in possibleMoves) {
                if (move.getStart().getPiece().CanMove(move)) {
                    // for each active threat, can it still attack the king after this move if it goes through?
                    foreach (BoardSquare threatLocation in activeThreats)
                    {
                        Move threatMove = new Move(currentPlayer, threatLocation, enemyKingSquare, gameBoard);
                        if (!threatLocation.getPiece().CanMove(threatMove))
                        {
                            // if the threat cant move, this is a valid move to get out of check
                            validMovesCounter++;
                        }
                    }
                }
            }
            // if no move exists to exit check state, game over
            if (validMovesCounter == 0) {
                return true;
            }
            else {
                return false;
            }
        }
            
        private void PrintUserInputMenu() {
            // Consider another object to manage this state
            ForegroundColor = ConsoleColor.Cyan;
            if (currentPlayer.whiteSide) {
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
            Move move = new Move(currentPlayer, startBox, endBox, gameBoard);
            
            if (!IsMyTurn(move)) {
                return false; 
            }

            if (move.getStart().getPiece() == null) {
                return false; 
            }

            // is the players king in check?
            if (IsPlayersKingInCheck()) {
                // if its in check, does the move end check?
                IGamePiece targetPiece = move.getEnd().getPiece();
                move.getEnd().setPiece(move.getStart().getPiece());
                if (IsPlayersKingInCheck()) {
                    move.getStart().setPiece(move.getEnd().getPiece());
                    move.getEnd().setPiece(targetPiece);
                    WriteLine("King is in check.");
                    WriteLine("Press any key to continue. . .");
                    ReadKey(true);
                    return false; 
                }
                move.getEnd().setPiece(targetPiece);
            }
            // is the piece pinned by an attack?
            else
            {
                IGamePiece targetPiece = move.getEnd().getPiece();
                move.getEnd().setPiece(move.getStart().getPiece());
                move.getStart().setPiece(null);
                if (IsPlayersKingInCheck()) {
                    move.getStart().setPiece(move.getEnd().getPiece());
                    move.getEnd().setPiece(targetPiece);
                    WriteLine("Piece is pinned! King would be in check if moved.");
                    WriteLine("Press any key to continue. . .");
                    ReadKey(true);
                    return false;
                }
                move.getStart().setPiece(move.getEnd().getPiece());
                move.getEnd().setPiece(targetPiece);
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
                if (currentPlayer.isWhiteSide() != move.getStart().getPiece().isWhite())
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

        private void SwitchActivePlayer() {
            if (this.currentPlayer == players[0]) {
                this.currentPlayer = players[1];
                this.enemyPlayer = players[0];
            }
            else {
                this.currentPlayer = players[0];
                this.enemyPlayer = players[1];
            }
        }

        public bool IsPlayersKingInCheck() {
            BoardSquare kingSquare = ReturnPlayersKingBoardSquare();
            List<BoardSquare> attackVectors = PottentialAttackersBoardSquares(kingSquare);
            List<BoardSquare> activeThreats = AttackingPieces(attackVectors, kingSquare);

            // of all the potential attack squares, there are no pieces able to attack the king
            if (activeThreats.Count == 0) {
                return false;
            }
            if (activeThreats.Count > 0) {
                return true;
            }
            return false;
        }

        private List<BoardSquare> AttackingPieces(List<BoardSquare> potentialAttackers, BoardSquare kingSquare) {
            List<BoardSquare> activeThreats = new List<BoardSquare>(potentialAttackers.Count);
            if (potentialAttackers.Count == 0) {
                return activeThreats;
            }

            // check to see if any of these pieces are able to attack the kingsquare
            foreach (BoardSquare potentialAttackerSquare in potentialAttackers) {
                if (potentialAttackerSquare != null) {
                    Move checkMove = new Move(currentPlayer, potentialAttackerSquare, kingSquare, gameBoard);
                    if (potentialAttackerSquare.piece.CanMove(checkMove)) {
                        activeThreats.Add(potentialAttackerSquare);
                    }
                }
            }
            return activeThreats;
        }

        private List<BoardSquare> PottentialAttackersBoardSquares(BoardSquare kingSquare) {
            // List all of the squares that can directly see the king with no piece inbetween
            List<BoardSquare> attackVectors = new List<BoardSquare>();
            BoardSquare boardSquare;

            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.SOUTH, enemyPlayer);
            if (boardSquare != null) {
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.NORTH, enemyPlayer);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.EAST, enemyPlayer);
            if (boardSquare != null) {
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.WEST, enemyPlayer);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare);
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.NORTHEAST, enemyPlayer);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare);
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.NORTHWEST, enemyPlayer);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.SOUTHWEST, enemyPlayer);
            if (boardSquare != null) { 
                attackVectors.Add(boardSquare); 
            }
            boardSquare = FirstVisiblePieceInDirection(gameBoard, kingSquare, EnumMoveDirections.SOUTHEAST, enemyPlayer);
            if (boardSquare != null) {
                attackVectors.Add(boardSquare); 
            }

            BoardSquare potentialKnight;

            // NorthEast       
            potentialKnight = PotentialKnightAttacker(kingSquare, -2, 1);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight);
            }
            potentialKnight = PotentialKnightAttacker(kingSquare, -1, 2);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight); 
            }
            // SouthEast
            potentialKnight = PotentialKnightAttacker(kingSquare, 1, 2);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight);
            }
            potentialKnight = PotentialKnightAttacker(kingSquare, 2, 1);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight);
            }
            // SouthWest
            potentialKnight = PotentialKnightAttacker(kingSquare, 2, -1);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight); 
            }
            potentialKnight = PotentialKnightAttacker(kingSquare, 1, -2);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight);
            }
            // NorthWest
            potentialKnight = PotentialKnightAttacker(kingSquare, -1, -2);
            if (potentialKnight != null) {
                attackVectors.Add(potentialKnight); 
            }
            potentialKnight = PotentialKnightAttacker(kingSquare, -2, -11);
            if (potentialKnight != null) { 
                attackVectors.Add(potentialKnight); 
            }

            return attackVectors;
        }

        private BoardSquare PotentialKnightAttacker(BoardSquare kingSquare, int row, int col) {
            int kingSquareRow = kingSquare.getGameRow();
            int kingSquareCol = kingSquare.getGameCol();
            int deltaRow = kingSquareRow + row;
            int deltaCol = kingSquareCol + col;

            if (deltaCol > 8 && deltaCol <= 0 &&
                deltaRow > 8 && deltaRow <= 0) {
                BoardSquare potentialKnight = gameBoard.GetBoardSquare(deltaRow, deltaCol);
                if (potentialKnight.getPiece() is Knight &&
                    potentialKnight.getPiece().isWhite() !=
                    kingSquare.piece.isWhite()) {
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
                       currentPlayer.isWhiteSide()) {
                        return gameBoard.GetBoardSquare(row, col);
                    }
                }
            }
            return null;
        }

        private BoardSquare ReturnPlayersKingBoardSquare() {
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if (gameBoard.GetBoardSquare(row, col).getPiece() is King &&
                       gameBoard.GetBoardSquare(row, col).getPiece().isWhite() == currentPlayer.isWhiteSide()) {
                        return gameBoard.GetBoardSquare(row, col);
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

        private List<Move> ListOfPossiblePlayerMoves(List<BoardSquare> playerPieceLocations, Player player) {
            List<Move> possiblePlayerMoves = new List<Move>();
            foreach (BoardSquare square in playerPieceLocations) {
                for (int row = 0; row < 8; row++) {
                    for (int col = 0; col < 8; col++) {
                        Move move = new Move(player, square, gameBoard.GetBoardSquare(row,col), gameBoard);
                        if(square.getPiece().CanMove(move)) { 
                            possiblePlayerMoves.Add(move);
                        }
                    }
                }
            }
            return possiblePlayerMoves;
        }

        private List<BoardSquare> ListOfPlayerPieceLocations(Player player) {
            List<BoardSquare> listOfPlayerPieces = new List<BoardSquare>();
            BoardSquare playerPieceLocation;
            for(int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    playerPieceLocation = gameBoard.GetBoardSquare(row, col);
                    if (playerPieceLocation.getPiece() != null){
                        if (player.isWhiteSide() == playerPieceLocation.getPiece().isWhite()) {
                            listOfPlayerPieces.Add(playerPieceLocation);
                        }
                    }
                }
            }
            return listOfPlayerPieces;
        }
    }
}

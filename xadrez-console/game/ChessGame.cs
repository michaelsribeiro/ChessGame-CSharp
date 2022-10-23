using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard;
using xadrez_console.chessboard.Enums;

namespace xadrez_console.game
{
    public class ChessGame
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndGame { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            InputPieces();
        }

        public void Move(Position origin, Position destiny)
        {
            ChessPiece piece = Board.RemovePiece(origin);
            piece.IncrementMovements();
            ChessPiece capturedPiece = Board.RemovePiece(destiny);
            Board.AddPiece(piece, destiny);
        }

        public void MakeMove(Position origin, Position destiny)
        {
            Move(origin, destiny);
            Shift++;
            ShiftPlayer();
        }

        private void ShiftPlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position pos)
        {
            if(Board.Piece(pos) == null)
            {
                throw new BoardException("There's no piece in this position!");
            }

            if(CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }

            if(!Board.Piece(pos).ValidateOriginMovements())
            {
                throw new BoardException("There's no possible movements to this piece!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if(!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid movement!");
            }
        }

        private void InputPieces()
        {
            // Whites
            Board.AddPiece(new Tower(Color.White, Board), new BoardPosition('a', 1).ToPosition());
            Board.AddPiece(new Bishop(Color.White, Board), new BoardPosition('b', 1).ToPosition());
            Board.AddPiece(new Horse(Color.White, Board), new BoardPosition('c', 1).ToPosition());
            Board.AddPiece(new King(Color.White, Board), new BoardPosition('d', 1).ToPosition());
            Board.AddPiece(new Queen(Color.White, Board), new BoardPosition('e', 1).ToPosition());
            Board.AddPiece(new Horse(Color.White, Board), new BoardPosition('f', 1).ToPosition());
            Board.AddPiece(new Bishop(Color.White, Board), new BoardPosition('g', 1).ToPosition());
            Board.AddPiece(new Tower(Color.White, Board), new BoardPosition('h', 1).ToPosition());

            // Blacks
            Board.AddPiece(new Tower(Color.Black, Board), new BoardPosition('a', 8).ToPosition());
            Board.AddPiece(new Bishop(Color.Black, Board), new BoardPosition('b', 8).ToPosition());
            Board.AddPiece(new Horse(Color.Black, Board), new BoardPosition('c', 8).ToPosition());
            Board.AddPiece(new Queen(Color.Black, Board), new BoardPosition('d', 8).ToPosition());
            Board.AddPiece(new King(Color.Black, Board), new BoardPosition('e', 8).ToPosition());
            Board.AddPiece(new Horse(Color.Black, Board), new BoardPosition('f', 8).ToPosition());
            Board.AddPiece(new Bishop(Color.Black, Board), new BoardPosition('g', 8).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new BoardPosition('h', 8).ToPosition());
        }
    }
}

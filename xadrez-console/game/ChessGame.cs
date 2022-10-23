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
        private int shift;
        private Color currentPlayer;
        public bool EndGame { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            shift = 1;
            currentPlayer = Color.White;
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

        private void InputPieces()
        {
            Board.AddPiece(new King(Color.Black, Board), new BoardPosition('e', 8).ToPosition());
            Board.AddPiece(new Horse(Color.White, Board), new BoardPosition('d', 6).ToPosition());
            Board.AddPiece(new Tower(Color.Black, Board), new BoardPosition('a', 8).ToPosition());
            Board.AddPiece(new Tower(Color.White, Board), new BoardPosition('h', 1).ToPosition());
        }
    }
}

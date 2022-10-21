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

        public ChessGame()
        {
            Board = new Board(8, 8);
            shift = 1;
            currentPlayer = Color.White;
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
            Board.AddPiece(new King(Color.Black, Board), new BoardPosition(8, 'e').toPosition());
            Board.AddPiece(new Horse(Color.White, Board), new BoardPosition(2, 'd').toPosition());
        }
    }
}

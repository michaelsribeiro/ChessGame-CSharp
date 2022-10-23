using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.chessboard
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private ChessPiece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new ChessPiece[Lines, Columns];
        }

        public ChessPiece Piece(int Lines, int Columns)
        {
            return pieces[Lines, Columns];
        }
        public ChessPiece Piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool AlrearyExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void AddPiece(ChessPiece p, Position pos)
        {
            if (AlrearyExistPiece(pos))
            {
                throw new BoardException("There's an piece at this position!");
            }
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public ChessPiece RemovePiece(Position pos)
        {
            if (Piece(pos) == null)
            {
                return null;
            }

            ChessPiece aux = Piece(pos);
            aux.Position = null;
            pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool PositionValid(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!PositionValid(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}

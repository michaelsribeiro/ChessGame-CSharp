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

        private ChessPiece[,] _pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _pieces = new ChessPiece[Lines, Columns];
        }

        public ChessPiece piece(int lines, int columns)
        {
            return _pieces[lines, columns];
        }

        public void AddPiece(ChessPiece p, Position pos)
        {
            _pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }
    }
}

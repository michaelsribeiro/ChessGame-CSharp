using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard.Enums;

namespace xadrez_console.chessboard
{
    public class ChessPiece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public Board Board { get; protected set; }

        public ChessPiece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Movements = 0;
            Board = board;
        }
    }
}

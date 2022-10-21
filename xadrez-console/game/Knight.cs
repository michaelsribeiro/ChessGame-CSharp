using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard;
using xadrez_console.chessboard.Enums;

namespace xadrez_console.game
{
    internal class Knight : ChessPiece
    {
        public Knight(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "H";
        }
    }
}

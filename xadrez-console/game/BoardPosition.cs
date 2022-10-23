using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard;

namespace xadrez_console.game
{
    public class BoardPosition
    {
        public int Line { get; set; }
        public char Column { get; set; }

        public BoardPosition(char column, int line)
        {
            Line = line;
            Column = column;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.chessboard
{
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro.Enums;

namespace xadrez_console.tabuleiro
{
    public class ChessPiece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }


    }
}

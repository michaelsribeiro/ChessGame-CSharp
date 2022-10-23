using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard.Enums;

namespace xadrez_console.chessboard
{
    public abstract class ChessPiece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Movements { get; protected set; }
        public Board Board { get; protected set; }

        public ChessPiece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Movements = 0;
            Board = board;
        }

        public void IncrementMovements()
        {
            Movements++;
        }

        public bool ValidateOriginMovements()
        {
            bool[,] mat = PossibleMovements();

            for(int i = 0; i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}

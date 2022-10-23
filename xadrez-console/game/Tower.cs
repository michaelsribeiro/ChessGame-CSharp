using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard;
using xadrez_console.chessboard.Enums;

namespace xadrez_console.game
{
    public class Tower : ChessPiece
    {
        public Tower(Color color, Board board) : base(color, board)
        {
        }

        private bool ValidateMovements(Position pos)
        {
            ChessPiece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // Move up
            pos.DefineValuesToPosition(Position.Line - 1, Position.Column);
            while(Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }

            // Move Down
            pos.DefineValuesToPosition(Position.Line + 1, Position.Column);
            while (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }

            // Move Right
            pos.DefineValuesToPosition(Position.Line, Position.Column + 1);
            while (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }

            // Move Left
            pos.DefineValuesToPosition(Position.Line, Position.Column - 1);
            while (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            return mat;
        }
        public override string ToString()
        {
            return "T";
        }

    }
}
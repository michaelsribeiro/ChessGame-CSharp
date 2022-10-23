using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard;
using xadrez_console.chessboard.Enums;

namespace xadrez_console.game
{
    public class King : ChessPiece
    {
        public King(Color color, Board board) : base(color, board)
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
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NE
            pos.DefineValuesToPosition(Position.Line - 1, Position.Column + 1);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Move Right
            pos.DefineValuesToPosition(Position.Line, Position.Column + 1);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SE
            pos.DefineValuesToPosition(Position.Line + 1, Position.Column + 1);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Move Down
            pos.DefineValuesToPosition(Position.Line + 1, Position.Column);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // SW
            pos.DefineValuesToPosition(Position.Line + 1, Position.Column - 1);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Move Left
            pos.DefineValuesToPosition(Position.Line, Position.Column - 1);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // NW
            pos.DefineValuesToPosition(Position.Line - 1, Position.Column - 1);
            if (Board.PositionValid(pos) && ValidateMovements(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.chessboard;
using xadrez_console.chessboard.Enums;
using xadrez_console.game;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Board board = new Board(8, 8);

            board.AddPiece(new King(Color.Black, board), new Position(0, 0));
            board.AddPiece(new Queen(Color.Black, board), new Position(3, 5));

            Screen.ShowBoard(board);

            Console.ReadLine();

        }    
    }
}

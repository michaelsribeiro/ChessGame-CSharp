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
            try
            {
                Board board = new Board(8, 8);

                board.AddPiece(new King(Color.Black, board), new Position(0, 0));
                board.AddPiece(new Queen(Color.Black, board), new Position(0, 5));

                board.AddPiece(new King(Color.White, board), new Position(6, 3));
                board.AddPiece(new Horse(Color.White, board), new Position(4, 5));

                Screen.ShowBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }
    }
}

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
    public class Screen
    {
        public static void ShowBoard(Board board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(" " + (8 - i) + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
        }

        public static void ShowBoard(Board board, bool[,] possibleMovements)
        {
            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundCustom   = ConsoleColor.DarkGray;

            Console.WriteLine();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(" " + (8 - i) + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possibleMovements[i, j])
                    {
                        Console.BackgroundColor = backgroundCustom;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOriginal;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = backgroundOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = backgroundOriginal;

        }

        public static void PrintPiece(ChessPiece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }            
        }

        public static BoardPosition ReadKeyboardInput()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new BoardPosition(column, line); 
        }
    }
}

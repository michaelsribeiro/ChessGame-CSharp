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
                ChessGame game = new ChessGame();

                while (!game.EndGame)
                {
                    try
                    {
                        Console.Clear();
                        Screen.ShowBoard(game.Board);
                        Console.WriteLine();

                        Console.WriteLine(" Turn: " + game.Shift);
                        Console.WriteLine(" Waiting player: " + game.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write(" Origin: ");
                        Position origin = Screen.ReadKeyboardInput().ToPosition();
                        game.ValidateOriginPosition(origin);

                        bool[,] possibleMovements = game.Board.Piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.ShowBoard(game.Board, possibleMovements);

                        Console.WriteLine();
                        Console.Write(" Destiny: ");
                        Position destiny = Screen.ReadKeyboardInput().ToPosition();
                        game.ValidateDestinyPosition(origin, destiny);

                        game.MakeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}

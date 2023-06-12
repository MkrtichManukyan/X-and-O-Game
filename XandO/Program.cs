using System;
using System.IO;
using System.Threading;

namespace TicTacToeCsharp
{
    public class Program
    {
        static char[] arr = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static int player = 1;
        static int choice;

        static int checkWon = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");

                Console.WriteLine();
                Console.WriteLine();

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }

                Console.WriteLine();
                Console.WriteLine();

                DrawBoard();

                choice = int.Parse(Console.ReadLine());

                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 1 second board is loading again.....");
                    Thread.Sleep(1000);
                }
                checkWon = CheckWin();
            }
            while (checkWon != 1 && checkWon != -1);

            Console.Clear();
            DrawBoard();
            if (checkWon == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();


        }
        private static void DrawBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion

            if ((arr[1] == arr[2] && arr[2] == arr[3]) && (arr[1] != ' ' && arr[2] != ' ' && arr[3] != ' '))
            {
                return 1;
            }
            else if ((arr[4] == arr[5] && arr[5] == arr[6]) && (arr[4] != ' ' && arr[5] != ' ' && arr[6] != ' '))
            {
                return 1;
            }
            else if ((arr[6] == arr[7] && arr[7] == arr[8]) && (arr[6] != ' ' && arr[7] != ' ' && arr[8] != ' '))
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            else if ((arr[1] == arr[4] && arr[4] == arr[7]) && (arr[1] != ' ' && arr[4] != ' ' && arr[7] != ' '))
            {
                return 1;
            }
            else if ((arr[2] == arr[5] && arr[5] == arr[8]) && (arr[2] != ' ' && arr[5] != ' ' && arr[5] != ' '))
            {
                return 1;
            }
            else if ((arr[3] == arr[6] && arr[6] == arr[9]) && (arr[3] != ' ' && arr[6] != ' ' && arr[9] != ' '))
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if ((arr[1] == arr[5] && arr[5] == arr[9]) && (arr[1] != ' ' && arr[5] != ' ' && arr[9] != ' '))
            {
                return 1;
            }
            else if ((arr[3] == arr[5] && arr[5] == arr[7]) && (arr[3] != ' ' && arr[5] != ' ' && arr[7] != ' '))
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            else if (arr[1] != ' ' && arr[2] != ' ' && arr[3] != ' ' && arr[4] != ' ' && arr[5] != ' ' && arr[6] != ' ' && arr[7] != ' ' && arr[8] != ' ' && arr[9] != ' ')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }

    }
}
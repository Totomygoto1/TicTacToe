using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {

        // Game Board array

        static char[] board = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };

        // Switch between players turn

        static int player = 1;

        // Players current game position, 'X' on position 3 in Board array  

        static int position;

        // The game_state variable checks who has won, if 1 then someone has won the game, if -1 then game tie, if 0 then game is still running  

        static int game_state = 0;

        // Display Game introduction (1 time)

        static int intro = 0;


        static void Main(string[] args)
        {

            do
            {
                // Whenever loop starts again, screen will be cleared  

                Console.Clear();

                if (intro == 0)
                {

                    Console.WriteLine("NOUGHTS and CROSSES ");
                    Console.WriteLine("     |     |      ");

                    Console.WriteLine("  O  |  X  |  O ");

                    Console.WriteLine("_____|_____|_____ ");

                    Console.WriteLine("     |     |      ");

                    Console.WriteLine("  O  |  O  |  X ");

                    Console.WriteLine("_____|_____|_____ ");

                    Console.WriteLine("     |     |      ");

                    Console.WriteLine("  X  |  X  |  O ");

                    Console.WriteLine("     |     |      \n");
                    Console.WriteLine("Declare the position for 'O' or 'X' with numbers: 0 .. 8 \n");

                    Console.WriteLine("Player1 writes: 0, Player2 writes: 1, Player1 writes: 2, ");
                    Console.WriteLine("see the positions on the board below. \n");

                    Console.WriteLine("X O X");
                    Console.WriteLine("- - -");
                    Console.WriteLine("- - -\n");

                    intro = 1;
                }

                Console.WriteLine("Player1:X and Player2:O");

                Console.WriteLine("\n");

                // Switch between players 

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 turn");
                }
                else
                {
                    Console.WriteLine("Player 1 turn");
                }

                Console.WriteLine("\n");

                // Display the Board 

                Board();

                // Read 'O' or 'X' position 

                position = int.Parse(Console.ReadLine());

                // Store the position marked with X or O (if not already marked)

                if (board[position] != 'X' && board[position] != 'O')
                {
                    // If it is player 2's turn then mark 'O' else mark 'X'

                    if (player % 2 == 0)
                    {
                        board[position] = 'O';
                        player++;

                    }
                    else
                    {
                        board[position] = 'X';
                        player++;

                    }

                }
                else
                {
                    // If there is a position where user want to run that is already marked then show error message and load board again

                    Console.WriteLine("Sorry the row {0} is already marked with {1}", position, board[position]);

                    Console.WriteLine("\n");

                    Console.WriteLine("Please wait 2 second board is loading again.....");

                    Thread.Sleep(2000);

                }

                // Check if someone has won or game board is full or waiting for input 

                game_state = CalculateWinner();

            }
            while (game_state != 1 && game_state != -1);

            // This loop will be run until all cell of the grid is marked with X and O or someone has won  

            // Clearing the console 

            Console.Clear();

            // Getting filled Board again  

            Board();

            // If game_state value is 1 then someone has won 

            if (game_state == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                // If game_state value is -1 the game will be tie

                Console.WriteLine("Tie");
            }

            Console.ReadLine();

        }

        // Display the Game Board 

        private static void Board()
        {

            Console.WriteLine("  {0}  {1}  {2}", board[0], board[1], board[2]);

            Console.WriteLine("  {0}  {1}  {2}", board[3], board[4], board[5]);

            Console.WriteLine("  {0}  {1}  {2}", board[6], board[7], board[8]);

        }

        // Check if a player has won or not  

        private static int CalculateWinner()
        {

            int[,] win = new int[,]
            {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6},
            };

            for (int i = 0; i < win.Length / 3; i++)
            {
                int a = win[i, 0];
                int b = win[i, 1];
                int c = win[i, 2];

                if (board[a] == board[b] && board[b] == board[c] && board[a] != '-' && board[b] != '-' && board[c] != '-')
                {

                    return 1;
                }
            }

            // Check if all the cells are filled with 'X' or 'O'   

            if (board[0] != '-' && board[1] != '-' && board[2] != '-' && board[3] != '-' && board[4] != '-' && board[5] != '-' && board[6] != '-' && board[7] != '-' && board[8] != '-')
            {
                return -1;
            }

            return 0;

        }

    }
}

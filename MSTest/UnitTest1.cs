using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {

        // static char[] board = { 'O', 'O', 'O', '-', '-', '-', '-', '-', '-' };

        // static char[] board = { 'X', '-', '-', 'X', '-', '-', 'X', '-', '-' };

        static char[] board = { 'O', '-', '-', '-', 'O', '-', '-', '-', 'O' };


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


        [TestMethod]
        public void TestMethod1()
        {

            int value = CalculateWinner();
            Assert.AreEqual(1, value);

        }

        [TestMethod]
        public void TestMethod2()
        {

            int value = CalculateWinner();
            Assert.AreNotSame('1', value);

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class Battleships
    {
        int getColCount(char[][] board, int k)
        {
            int m = board.Length;
            int n = board[0].Length;
            int i = 0;
            int count = 0;
            while (i < m)
            {
                while (i < m && board[i][k] == '.')
                    i++;

                bool valid = true;
                int c = 0;
                while (i < m && board[i][k] == 'X')
                {
                    if ((k > 0 && board[i][k - 1] == 'X') || (k < n - 1 && board[i][k + 1] == 'X'))
                        valid = false;
                    i++;
                    c++;
                }
                //exclude the single node
                if (valid && c > 1)
                    count++;
            }

            return count;
        }


        int getRowCount(char[][] board, int k)
        {
            int m = board.Length;
            int n = board[0].Length;
            int i = 0;
            int count = 0;
            while (i < n)
            {
                while (i < n && board[k][i] == '.')
                    i++;

                bool valid = true;
                int c = 0;
                while (i < n && board[k][i] == 'X')
                {
                    if ((k > 0 && board[k - 1][i] == 'X') || (k < m - 1 && board[k + 1][i] == 'X'))
                        valid = false;
                    i++;
                    c++;
                }
                if (valid && c > 0)
                    count++;
            }

            return count;
        }

        public int countBattleships(char[][] board)
        {
            int count = 0;
            if (board.Length == 0)
                return 0;

            for (int i = 0; i < board.Length; i++)
                count += getRowCount(board, i);

            for (int i = 0; i < board[0].Length; i++)
                count += getColCount(board, i);

            return count;
        }
    }
}

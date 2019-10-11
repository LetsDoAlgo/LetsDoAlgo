using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //Note the count can also be calculated using the formula (m-1 + n-1)!/(m-1)!(n-1)!.
   // Another Approach:(Using combinatorics) In this approach We have to calculate m+n-2 C n-1 here which will be (m+n-2)! / (n-1)! (m-1)!
   //     or
    //Count all possible paths from top left to bottom right of a mXn matrix
    // The problem is to count all the possible paths from top left to bottom right of a mXn matrix with the constraints that from each cell you can either move only to right or down
    class UniquePaths
    {
        public int CalcUniquePaths(int m , int n)
        {
            int[,] dp = new int[m, n];
            // // Count of paths to reach any cell in 
            // first column is 1 
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            //// Count of paths to reach any cell in 
            // first column is 1 
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 1; i <m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}

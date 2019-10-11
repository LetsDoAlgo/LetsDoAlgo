using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class CoinChangeDenomination
    {
        static long countWays(int[] S, int m, int n)
        {
            //Time complexity of this function: O(mn) 
            //Space Complexity of this function: O(n) 

            // table[i] will be storing the number of solutions 
            // for value i. We need n+1 rows as the table is 
            // constructed in bottom up manner using the base 
            // case (n = 0) 
            int[] table = new int[n + 1];

            // Initialize all table values as 0 
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = 0;
            }

            // Base case (If given value is 0) 
            table[0] = 1;

            // Pick all coins one by one and update the table[] 
            // values after the index greater than or equal to 
            // the value of the picked coin 
            for (int i = 0; i < m; i++)
                for (int j = S[i]; j <= n; j++)
                    table[j] += table[j - S[i]];

            return table[n];
        }
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="x"></param>
/// <param name="arr"></param>
/// <param name="n"></param>
/// <returns></returns>
        // int []arr = { 3, 3, 4 }; 
        //int n = arr.Length;
        //int x = 7;

        //Console.WriteLine(minNumbers(x, arr, n)); 
        //bfs 
        // Function to find the minimum number 
        // of integers required 
       public static int minNumbers(int x, int[] arr, int n)
        {
            // Queue for BFS 
            Queue<int> q = new Queue<int>();

            // Base value in queue 
            q.Enqueue(x);

            // Boolean array to check if  
            // a number has been visited before 
            HashSet<int> v = new HashSet<int>();

            // Variable to store depth of BFS 
            int d = 0;

            // BFS algorithm 
            while (q.Count > 0)
            {

                // Size of queue 
                int s = q.Count;
                while (s-- > 0)
                {

                    // Front most element of the queue 
                    int c = q.Peek();

                    // Base case 
                    if (c == 0)
                        return d;
                    q.Dequeue();
                    if (v.Contains(c) || c < 0)
                        continue;

                    // Setting current state as visited 
                    v.Add(c);

                    // Pushing the required states in queue 
                    for (int i = 0; i < n; i++)
                        q.Enqueue(c - arr[i]);
                }
                d++;
            }

            // If no possible solution 
            return -1;
        }

        /////////////////////////////////////////////////////////////////////////\//https://leetcode.com/articles/coin-change/
        public static int CoinChange(int[] coins , int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
           // Arrays.fill(dp, max);
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        //we would love to  have the best way to have it . 
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                    //we can add else loop and break in case we do the sorting as if it is not gettin the change now , it will not get later as well .  
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}

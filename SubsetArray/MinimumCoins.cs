using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class MinimumCoins
    {

        //min jumps from start to array to end array 
        //if given that we can jump from one point of the array to other 
        //depending on the 
        //value in the array .
        //from 0 jump to 2 because value is 2 .
        //use dp 
        //2 array s of same length as original 
        //1. no of jummps 
        //2. actual jump 
        // i=1, j=0: 
        //rerach i , min jumps : form position 0 

        //SIMPLE 
        public int minJump(int[] arr, int[] result)
        {

            int[] jump = new int[arr.Length];
            jump[0] = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                jump[i] = int.MaxValue - 1;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] + j >= i)
                    {
                        if (jump[i] > jump[j] + 1)
                        {
                            result[i] = j;
                            jump[i] = jump[j] + 1;
                        }
                    }
                }
            }

            return jump[jump.Length - 1];
        }

        public int jump(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }
            int count = 0;
            int i = 0;
            while (i + nums[i] < nums.Length - 1)
            {
                int maxVal = 0;
                int maxValIndex = 0;
                for (int j = 1; j <= nums[i]; j++)
                {
                    if (nums[j + i] + j > maxVal)
                    {
                        maxVal = nums[j + i] + j;
                        maxValIndex = i + j;
                    }
                }
                i = maxValIndex;
                count++;
            }
            return count + 1;
        }

        //m is array length
        //v is the sum 
        //COMPLICATED 
        public static int minCoins(int[] coins , int m , int v)
        {
            //STORE MIN COINS FOR i value
            int[] table = new int[v + 1];
            int[] result = new int[v + 1];
            //if v=0 ; 
            table[0] = 0;

            //initilaize table with max value 
            for (int i=1 ; i<=v; i++)
            {
                table[i] = int.MaxValue;
                result[i] = -1;
            }

            //compute min coins required for all values
            for (int i = 1; i <=coins.Length; i++)
            {
                //gp thru all coins smaller than i 
                for (int j = 0; j <v; j++)
                {
                    if (coins[j]<=i)
                    {
                        if (table[i]>table[i-coins[j]]+1)
                        {
                            table[i] = 1 + table[i - coins[j]];
                            result[i] = j;
                        }
                    }
                }
            }

            return table[v];

        }

        private void printCoinCombination(int[] R, int[] coins)
        {
            if (R[R.Length - 1] == -1)
            {
                Console.WriteLine("No solution is possible");
                return;
            }
            int start = R.Length - 1;
            Console.WriteLine("Coins used to form total ");
            while (start != 0)
            {
                int j = R[start];
                Console.WriteLine(coins[j] + " ");
                start = start - coins[j];
            }
            Console.WriteLine("\n");
        }
    }
}

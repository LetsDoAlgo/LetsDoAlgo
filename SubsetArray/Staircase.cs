using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class Staircase
    {

        //recusrive solution will take exponenetial time to calculate 
        //Therefore , go for DP : take O(n*k)-->where N represent the Nth stair and k is the number of possible steps i.e. three in this case.

         //climb nth stair when person can climb 1, 2 3...m stairs at a time 
        public static int countWaysDP(int n , int m)
        {
            int[] numWays = new int[n];
            numWays[0] = 1;
            numWays[1] = 1;
            for (int i = 2; i <=n; i++)
            {
                numWays[i] = 0;
                //condition is imp 
                //1. j<=i   
                for (int j = 0; j <=m && j<=i; j++)
                {
                    numWays[i] = numWays[i] + numWays[i - j];
                }
            }

           return numWays[n - 1];
        }
    }
}

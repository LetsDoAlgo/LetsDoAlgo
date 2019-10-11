using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class DecodeWays
    {
//        //This problem is recursive and can be broken in sub-problems. We start from end of the given digit sequence. We initialize the total count of decodings as 0. We recur for two subproblems.
//1) If the last digit is non-zero, recur for remaining(n-1) digits and add the result to total count.
//2) If the last two digits form a valid character(or smaller than 27), recur for remaining(n-2) digits and add the result to total count.
        // A Dynamic Programming based  
        // function to count decodings 
        static int countDecodingDP(char[] digits,
                                   int n)
        {
            // A table to store results of subproblems 
            int[] count = new int[n + 1];
            count[0] = 1;
            count[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                count[i] = 0;

                // If the last digit is not 0,  
                // then last digit must add to 
                // the number of words 
                if (digits[i - 1] > '0')
                    count[i] = count[i - 1];

                // If second last digit is smaller 
                // than 2 and last digit is smaller 
                // than 7, then last two digits  
                // form a valid character 
                if (digits[i - 2] == '1' ||
                   (digits[i - 2] == '2' &&
                    digits[i - 1] < '7'))
                    count[i] += count[i - 2];
            }
            return count[n];
        }
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            var dp = new int[s.Length + 1];
            dp[0] = 1;

            for (int i = 1; i < s.Length + 1; i++)
            {
                if (i > 1 && s[i - 2] != '0' && int.Parse(s.Substring(i - 2, 2)) <= 26)
                {
                    dp[i] += dp[i - 2];
                }

                if (s[i - 1] != '0')
                {
                    dp[i] += dp[i - 1];
                }
            }

            return dp[s.Length];
        }
    }
}

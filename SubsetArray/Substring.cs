using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class Substring
    {
        // Function to find Minimum number
// of times 'A' has to be repeated  
// such that 'B' is a substring of it 
        public static int Min_repetation(String A, String B)
        {
            // To store minimum number of repetations 
            int ans = 1;

            // To store repeated string 
            String S = A;

            // Untill size of S is less than B 
            while (S.Length < B.Length)
            {
                S += A;
                ans++;
            }

            // ans times repetation makes required answer 
            if (issubstring(B, S)) return ans;

            // Add one more string of A  
            if (issubstring(B, S + A))
                return ans + 1;

            // If no such solution exits  
            return -1;
        }
        public static bool issubstring(String str2, String rep1)
        {
            int M = str2.Length;
            int N = rep1.Length;

            // Check for substring from starting  
            // from i'th index of main string 
            for (int i = 0; i <= N - M; i++)
            {
                int j;
                // For current index i,  
                // check for pattern match 
                for (j = 0; j < M; j++)
                    if (rep1[i + j] != str2[j])
                        break;

                if (j == M) // pattern matched 
                    return true;
            }

            return false; // not a substring 
        }
    }
}

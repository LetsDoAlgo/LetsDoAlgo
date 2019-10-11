using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class LCS
    {
        public static void lcs(string x , string y , int m , int n )
        {
            int[,] L = new int[m + 1, n + 1];

            //m : length of first array 
            //n : lengthof second array 
            int i = 0,j=0;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i, j] = 0;

                    }
                    else if (x[i - 1] == y[j - 1])
                    {
                        L[i, j] = L[i - 1, j - 1] + 1;

                    }
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }

            //print LCS
            // Following code is used to print LCS 
            int index = L[m,n];

            // Create a character array to store the lcs string 
            char[] lcs = new char[index + 1] ;
            lcs[index] = '\0'; // Set the terminating character 

            // Start from the right-most-bottom-most corner and 
            // one by one store characters in lcs[] 
            int k = m, l = n;
            while (k > 0 && l > 0)
            {
                // If current character in X[] and Y  
                // are same, then current character  
                // is part of LCS 
                if (x[k - 1] == y[l - 1])
                {
                    // Put current character in result 
                    lcs[index - 1] = x[k - 1];

                    // reduce values of i, j and index 
                    k--;
                    l--;
                    index--;
                }

                // If not same, then find the larger of two and 
                // go in the direction of larger value 
                else if (L[k - 1, l] > L[k, l - 1])
                    k--;
                else
                    l--;
            }

            // Print the lcs 
            Console.WriteLine(lcs);

        }
    }
}

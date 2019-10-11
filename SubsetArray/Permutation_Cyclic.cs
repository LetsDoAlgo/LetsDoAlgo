using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class Permutation_Cyclic
    {
       public static void cyclic(int N)
        {
            int num = N;
            int n = countdigits(N);

            while (true)
            {
                Console.WriteLine(num);

                // Following three lines generates a 
                // circular permutation of a number. 
                int rem = num % 10;
                int dev = num / 10;
                num = (int)((Math.Pow(10, n - 1)) *
                                        rem + dev);

                // If all the permutations are  
                // checked and we obtain original 
                // number exit from loop. 
                if (num == N)
                    break;
            }
        }
       public static int countdigits(int N)
        {
            int count = 0;
            while (N > 0)
            {
                count++;
                N = N / 10;
            }
            return count;
        }

    }
}

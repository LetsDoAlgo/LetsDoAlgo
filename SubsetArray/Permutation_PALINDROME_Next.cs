using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class Permutation_PALINDROME_Next
    {
        public static void reverse(char[] num,
                               int i, int j)
        {
            while (i < j)
            {
                char temp = num[i];
                num[i] = num[j];
                num[j] = temp;
                i++;
                j--;
            }
        }

        public static void nextPalin(char[] num,
                              int n)
        {
            if (n<=3)
            {
                Console.WriteLine("not possible");
            }
            char temp;
            int mid = n / 2 - 1;
            int i, j;
            for (i =mid-1 ; i >=0; i--)
            {
                if (num[i]<num[i+1])
                {
                    break;
                }
            }

            if (i<0)
            {
                Console.WriteLine("not possible");
            }
            int smallest = i + 1;
            for (j = i + 2; j <= mid; j++)
                if (num[i]<num[j] && num[j] < num[smallest])
                    smallest = j;

            temp = num[i];
            num[i] = num[smallest];
            num[smallest] = temp;

            temp = num[n - i - 1];
            num[n - i - 1] = num[n - smallest - 1];
            num[n - smallest - 1] = temp;

            // reverse digits in the   
            // range (i+1) to mid 
            reverse(num, i + 1, mid);

            // if n is even, then 
            // reverse digits in the  
            // range mid+1 to n-i-2 
            if (n % 2 == 0)
                reverse(num, mid + 1, n - i - 2);

            // else if n is odd, then  
            // reverse digits in the  
            // range mid+2 to n-i-2 
            else
                reverse(num, mid + 2,n - i - 2);

            // required next higher  
            // palindromic number 
            String result = new String(num);
            Console.WriteLine("Next Palindrome: " +
                                          result);
        }
    }
}

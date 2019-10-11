using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class BinaryStringWildCardPattern
    {
        //char pattern
        //replace ? with 0/1
        //find all binary strings that can be formed form given wildcard pattern 

        public static void printAllCombination(char[] pattern, int i)
        {
            //i=0;
            if (i==pattern.Length)
            {
                Console.WriteLine(pattern);
                return;
            }
            if (pattern[i]=='?')
            {
                for (char ch = '0'; ch <= '1'; ch++)
                {
                    pattern[i] = ch;
                    printAllCombination(pattern, i + 1);//recur for remaining pattern
                    pattern[i] = '?';//backtrack as array is passed by reference to function
                }
                return;
            }

            printAllCombination(pattern, i + 1);
        }

        //easy
        public static void printAllCombination2(char[] str , int index)
        {
            if (index== str.Length)
            {
                Console.WriteLine(str);
                return;
            }

            if (str[index]=='?')
            {
                str[index] = '0';//replace with 0 and continur recursion
                printAllCombination2(str, index + 1);
                str[index] = '1';
                printAllCombination2(str, index + 1);
            }
            else
            {
                printAllCombination2(str, index + 1);
            }
        }

        // Function to print the output 
        static void printTheArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // Function to generate all binary strings 
       public static void generateAllBinaryStrings(int n,
                                    int[] arr, int i)
        {
            if (i == n)
            {
                printTheArray(arr, n);
                return;
            }

            // First assign "0" at ith position 
            // and try for all other permutations 
            // for remaining positions 
            arr[i] = 0;
            generateAllBinaryStrings(n, arr, i + 1);

            // And then assign "1" at ith position 
            // and try for all other permutations 
            // for remaining positions 
            arr[i] = 1;
            generateAllBinaryStrings(n, arr, i + 1);
        }

      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class FindSubsets
    {
        public static void FindSubsets123()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            int r = 3;
            int n = arr.Length;
            /* arr[] ---> Input Array 
               data[] ---> Temporary array to store 
               current combination start & end ---> 
               Staring and Ending indexes in arr[] 
               index ---> Current index in data[] 
               r ---> Size of a combination to be 
               printed */

            // A temporary array to store all 
            // combination one by one 
            int[] data = new int[r];

            // Print all combination using 
            // temprary array 'data[]' 
            combinationUtil(arr, n, r, 0, data, 0);
        }
       public static void combinationUtil(int[] arr,
                 int n, int r, int index,
                         int[] data, int i)
        {

            // Current combination is ready to 
            // be printed, print it 
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                    Console.Write(data[j] + " ");

                Console.WriteLine("");

                return;
            }

            // When no more elements are there 
            // to put in data[] 
            if (i >= n)
                return;

            // current is included, put next 
            // at next location 
            data[index] = arr[i];
            combinationUtil(arr, n, r, index + 1, data, i + 1);

            // current is excluded, replace 
            // it with next (Note that i+1  
            // is passed, but index is not 
            // changed) 
            combinationUtil(arr, n, r, index,data, i + 1);
        }

/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param name="set"></param>
       public static void printSubsets_Rec(char[] set)
        {
            int n = set.Length ;

            // Run a loop for printing all 2^n 
            // subsets one by obe 
            int s = (1 << n);
            for (int i = 0; i < (1 << n); i++)
            {
                Console.WriteLine("{ ");

                // Print current subset 
                for (int j = 0; j < n; j++)
                {
                    // (1<<j) is a number with jth bit 1 
                    // so when we 'and' them with the 
                    // subset number we get which numbers 
                    // are present in the subset and which 
                    // are not 
                    int k = 1 << j;
                    int k1 = i & k;
                    if ((i & (1 << j)) > 0)
                        Console.WriteLine(set[j] + " ");
                }

                  

                Console.WriteLine("}");
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////
       public static void powerSet(string str, int index,
                             string curr)
        {
            int n = str.Length;

            // base case  
            if (index == n)
            {
                return;
            }

            // First print current subset  
            Console.WriteLine(curr);

            // Try appending remaining characters  
            // to current subset  
            for (int i = index + 1; i < n; i++)
            {
                curr += str[i];
                powerSet(str, i, curr);

                // Once all subsets beginning with  
                // initial "curr" are printed, remove  
                // last character to consider a different  
                // prefix of subsets.  
                curr = curr.Substring(0, curr.Length - 1);
            }
        }

    }
}
//we wil simulate as taking the numenr and not taking the number 
//return value 
//recurve funtion 

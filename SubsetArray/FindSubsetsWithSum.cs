using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{


    //int[] arr = { 2, 5, 8, 4, 6, 11 };
    //int sum = 13;
    //int n = arr.Length;
    //    printAllSubsets(arr, n, sum);
   public static class FindSubsetsWithSum
    {
       public static void printAllSubsetsRec(int[] arr, int n,
                                     List<int> v, int sum)
        {
            // If remaining sum is 0, then print all  
            // elements of current subset.  
            if (sum == 0)
            {
                for (int i = 0; i < v.Count; i++)
                    Console.Write(v[i] + " ");
                Console.WriteLine();
                return;
            }

            // If no remaining elements,  
            if (n == 0)
                return;

            // We consider two cases for every element.  
            // a) We do not include last element.  
            // b) We include last element in current subset.  
            printAllSubsetsRec(arr, n - 1, v, sum);
            List<int> v1 = new List<int>(v);
            v1.Add(arr[n - 1]);
            printAllSubsetsRec(arr, n - 1, v1, sum - arr[n - 1]);
        }

        // Wrapper over printAllSubsetsRec()  
       public static void printAllSubsets(int[] arr, int n, int sum)
        {
            List<int> v = new List<int>();
            printAllSubsetsRec(arr, n, v, sum);
        }




        //Subset with given sum as 0 
        // id s==n 
        //

    }
}

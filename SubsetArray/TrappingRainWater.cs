using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class TrappingRainWater
    {
       public static int findWater(int[] arr, int n)
        {
            // initialize output 
            int result = 0;

            // maximum element on left and right 
            int left_max = 0, right_max = 0;

            // indices to traverse the array 
            int lo = 0, hi = n - 1;

            while (lo <= hi)
            {
                if (arr[lo] < arr[hi])
                {
                    if (arr[lo] > left_max)

                        // update max in left 
                        left_max = arr[lo];
                    else

                        // water on curr element =  
                        // max - curr 
                        result += left_max - arr[lo];
                    lo++;
                }
                else
                {
                    if (arr[hi] > right_max)

                        // update right maximum 
                        right_max = arr[hi];

                    else
                        result += right_max - arr[hi];
                    hi--;
                }
            }

            return result;
        }

        //// Driver program  
        //public static void Main()
        //{
        //    int[] arr = {0, 1, 0, 2, 1, 0, 1,
        //            3, 2, 1, 2, 1};
        //    int result = Trap.findWater(arr, arr.length);
        //    System.out.print(" Total trapping water: " + result);
        //}
    }
}
//Time Complexity: O(n)
////Auxiliary Space: O(1)
//Space Optimization in above solution: Instead of maintaing two arrays of size n for storing left and right max of each element, we will just maintain two variables to store the maximum till that point.Since water trapped at any element = min(max_left, max_right) – arr[i] we will calculate water trapped on smaller element out of A[lo] and A[hi] first and move the pointers till lo doesn’t cross hi.
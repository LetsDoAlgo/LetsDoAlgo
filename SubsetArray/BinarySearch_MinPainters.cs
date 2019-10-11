using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //We can see that the highest possible value in this range is the sum of all the elements in the array and this happens when we allot 1 painter all the sections of the board. The lowest possible value of this range is the maximum value of the array max, as in this allocation we can allot max to one painter and divide the other sections such
    //that the cost of them is less than or equal to max and as close as possible to max.Now if we consider we use x painters in the above scenarios, it is obvious that as the value in the range increases, the value of x decreases and vice-versa.From this we can find the target value when x = k and use a helper function to find x, the minimum number of painters required when the maximum length of section a painter can paint is given.
    class BinarySearch_MinPainters
    {

    // return the maximum 
    // element from the array 
    static int getMax(int[] arr, int n)
    {
        int max = int.MinValue;
        for (int i = 0; i < n; i++)
            if (arr[i] > max)
                max = arr[i];
        return max;
    }

    // return the sum of the 
    // elements in the array 
    static int getSum(int[] arr, int n)
    {
        int total = 0;
        for (int i = 0; i < n; i++)
            total += arr[i];
        return total;
    }

    // find minimum required 
    // painters for given 
    // maxlen which is the 
    // maximum length a painter 
    // can paint 
    static int numberOfPainters(int[] arr,
                                int n, int maxLen)
    {
        int total = 0, numPainters = 1;

        for (int i = 0; i < n; i++)
        {
            total += arr[i];

            if (total > maxLen)
            {

                // for next count 
                total = arr[i];
                numPainters++;
            }
        }

        return numPainters;
    }

    static int partition(int[] arr,
                         int n, int k)
    {
        int lo = getMax(arr, n);
        int hi = getSum(arr, n);

        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            int requiredPainters = numberOfPainters(arr, n, mid);

            // find better optimum in lower 
            // half here mid is included 
            // because we may not get 
            // anything better 
            if (requiredPainters <= k)
                hi = mid;

            // find better optimum in upper 
            // half here mid is excluded 
            // because it gives required 
            // Painters > k, which is invalid 
            else
                lo = mid + 1;
        }

        // required 
        return lo;
    }

    // Driver code 
    //static public void Main()
    //{
    //    int[] arr = { 1, 2, 3, 4, 5,
    //                  6, 7, 8, 9 };

    //    // Calculate size of array. 
    //    int n = arr.Length;
    //    int k = 3;
    //    Console.WriteLine(partition(arr, n, k));
    //}
} 
  
// This code is contributed by ajit 
}

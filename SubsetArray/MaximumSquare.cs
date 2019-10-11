using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class MaximumSquare
    {
        // Function to find the area of the largest
        // square that can be formed
        // and the count of such squares
        static void findMaxSquare(int[] arr, int n)
        {

            // Maximum value from the array
            int maxVal = arr.Max();

            // Update the frequencies of
            // the array elements
            int[] freq = new int[maxVal + 1];
            for (int i = 0; i < n; i++)
                freq[arr[i]]++;
            // Starting from the maximum length sticks // in order to maximize the area

            for (int i = maxVal; i > 0; i--)
            {

                // The count of sticks with the current
                // length has to be at least 4
                // in order to form a square
                if (freq[i] >= 4)
                {
                    Console.Write("Area = " + (Math.Pow(i, 2)));
                    Console.Write("\nCount = " + (freq[i] / 4));
                    return;
                }
            }

            // Impossible to form a square
            Console.Write("-1");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class PairsOfGivenSum
    {
        public void PairedElements(int[] arr, int sum)
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low<high)
            {
                if (arr[low]+arr[high]==sum)
                {
                    Console.WriteLine("pair is "+ arr[low]+" " + arr[high]);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class KthSmallest
    {
        public static int partition(int[] arr , int l , int r)
        {
            int pivot = arr[r];
            int i = l;
            int temp = 0;
            for (int j = l; j < r-1; j++)
            {
                if (arr[j]<=pivot)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    i++;

                }
            }

            //swap arr[i]  annd arr[r]
            temp = arr[i];
            arr[i] = pivot;
           pivot = temp;

            return i;
        }
        public static int QuickSort(int[] arr, int low, int high, int k)
        {
            if (k>0&&k<=high-low+1)
            {
                //partition the array around last element 
                //and get position of pivot element in sorted array 
                int pos = partition(arr, low, high);

                if (pos-low==k-1)
                {
                    return arr[pos];
                }

                //if position is more , recur for the left subaray 
                if (pos-low>k-1)
                {
                    return QuickSort(arr, low, pos - 1, k);
                }

                return QuickSort(arr, pos + 1, high, k - pos + low - 1);
            }
            return int.MaxValue;
        }
    }
}

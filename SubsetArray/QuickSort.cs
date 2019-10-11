using System;

namespace SubsetArray
{
    class QuickSortSample
    {

        static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                //stores the position of pivot element
                int piv_pos = partition(arr, start, end);
                QuickSort(arr, start, piv_pos - 1);    //sorts the left side of pivot.
                QuickSort(arr, piv_pos + 1, end); //sorts the right side of pivot.
            }
        }

        //the only difference when we have to find the kth smallest element is that
        //if (pivot==k-1) ==> return a[pivot]
        //if pivot >k-1 ==>qs(a,start,pivot,k)
        //else ==>qs(a,pivot+1,end,k)

        static int partition(int[] arr, int start, int end)
        {
            int i = start - 1;
            int piv = arr[end];            //make the last element as pivot element.
            for (int j = start; j <= end - 1; j++)
            {
                /*rearrange the array by putting elements which are less than pivot
                   on left side and which are greater than pivot on right side. */

                if (arr[j] <= piv)
                {
                    i++;
                    swap(ref arr[i], ref arr[j]);
                }
            }
            swap(ref arr[end], ref arr[i + 1]);  //put the pivot element in its proper place.
            return i + 1;                      //return the position of the pivot
        }
        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}

    ////////////////////////////////////////////////
    /* This function takes last element as pivot, 
   places the pivot element at its correct 
   position in sorted array, and places all 
   smaller (smaller than pivot) to left of 
   pivot and all greater elements to right 
   //of pivot */
   // static int partition(int[] arr, int low,
   //                                int high)
   // {
   //     int pivot = arr[high];

   //     // index of smaller element 
   //     int i = (low - 1);
   //     for (int j = low; j < high; j++)
   //     {
   //         // If current element is smaller  
   //         // than the pivot 
   //         if (arr[j] < pivot)
   //         {
   //             i++;

   //             // swap arr[i] and arr[j] 
   //             int temp = arr[i];
   //             arr[i] = arr[j];
   //             arr[j] = temp;
   //         }
   //     }

   //     // swap arr[i+1] and arr[high] (or pivot) 
   //     int temp1 = arr[i + 1];
   //     arr[i + 1] = arr[high];
   //     arr[high] = temp1;

   //     return i + 1;
   // }


   // /* The main function that implements QuickSort() 
   // arr[] --> Array to be sorted, 
   // low --> Starting index, 
   // high --> Ending index */
   // static void quickSort(int[] arr, int low, int high)
   // {
   //     if (low < high)
   //     {

   //         /* pi is partitioning index, arr[pi] is  
   //         now at right place */
   //         int pi = partition(arr, low, high);

   //         // Recursively sort elements before 
   //         // partition and after partition 
   //         quickSort(arr, low, pi - 1);
   //         quickSort(arr, pi + 1, high);
   //     }
   // }

   // // A utility function to print array of size n 
   // static void printArray(int[] arr, int n)
   // {
   //     for (int i = 0; i < n; ++i)
   //         Console.Write(arr[i] + " ");

   //     Console.WriteLine();
   // }
  
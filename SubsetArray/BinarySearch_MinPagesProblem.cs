using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class BinarySearch_MinPagesProblem
    {
        //https://tutorialspoint.dev/algorithm/divide-and-conquer/allocate-minimum-number-pages#main_container
        //Given number of pages in n different books and m students. The books are arranged in ascending order of number of pages. Every student is assigned to read some consecutive books. The task is to assign books in such a way that the maximum number of pages assigned to a student is minimum.
        //The idea is to use Binary Search. We fix a value for the number of pages as mid of current minimum and maximum. We initialize minimum and maximum as 0 and sum-of-all-pages respectively. If a current mid can be a solution, then we search on the lower half, else we search in higher half.
        ////Number of pages in books 
        //int[] arr = { 12, 34, 67, 90 };
        //int n = arr.Length;
        //int m = 2; // No. of students 

        //Console.WriteLine("Minimum number of pages = " + 
        //                  findPages(arr, n, m)); 

        public int findPages(int[] arr , int n , int m )
        {
            int sum = 0;
            //base case if books <students
            if (n<m)
            {
                return -1;
            }
            //totl pages
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            int low = 0;
            int high = sum;
            int result = int.MaxValue;
            while (low<=high)
            {
                int mid = (low + high) / 2;
                if (isPossible(arr,n,m,mid))
                {
                    high = mid - 1;
                    result = Math.Min(result, mid);
                }
                else
                {
                    low = mid + 1;
                }
            }
            return result;          
        }

        private bool isPossible(int[] arr, int n, int m, int mid)
        {
            //mid is the current min 
            //if current min value is feasible or not 
            int stdReqd = 1;
            int curr_Sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i]>mid)
                {
                    return false;
                }

                if (curr_Sum+arr[i]>mid)
                {
                    stdReqd++;
                    curr_Sum = arr[i];
                    if (stdReqd>m)
                    {
                        return false;
                    }
                }

                curr_Sum += arr[i];
            }

            return true;
        }
    }
}

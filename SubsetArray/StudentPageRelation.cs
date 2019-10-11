using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //class StudentPageRelation
    //{
    //    //n different books and 
    //    //m students 
    //    //assign dt : max no of pages assigned to student is minmum
    //    //the maximum number of pages assigned to a student is minimum.


    //        //count total pages in the sum 
    //        //initialize start and end 
    //        //traverse from start to end 
    //        //check feasible distribute with min  
    //    public static int findPages(int[] arr, int m , int n)
    //    {
    //        long sum = 0;
    //        if (n<m)
    //        {
    //            return -1;
    //        }
    //        //count pages 
    //        for (int i = 0; i < n; i++)
    //        {
    //            sum += arr[i];
    //        }

    //        //inistialize start =0 pages 
    //        //end = sum 
    //        int start = 0;
    //        int end = int.MaxValue;
    //        while (start<=end)
    //        {
    //            //distribut ebooks by mid as current minimum 
    //            int mid = (start + end) / 2;
    //            if (IsPossible(arr, n, m, curr_min))
    //            {
    //                //finding min and books are sorted 
    //                //reduce end
    //            }
    //            else
    //            {
    //                //pages should be increased so update 
    //                //start = mid +1;
    //            }
    //        }

    //    }

    //    //check if value s feasible
    //    static bool IsPossible(int[] arr , int n , int m , int curr_min)
    //    {
    //        //iterate books 
    //        //1.//check if (current pages > curr_min) ==> 
    //        //will get results after mid no of pages 

    //        //2. count how many studnets required to distribute 
    //        //curr_min pages
    //        //2 a )update accordingly .

    //        int stuReqd = 1;
    //        int curr_sum = 0;
    //        for (int i = 0; i < n; i++)
    //        {
    //            if (arr[i]>curr_min)
    //            {
    //                //get result after mid no of pages 
    //                return false;
    //            }

    //            if (curr_sum+arr[i]>curr_min)
    //            {
    //                stuReqd++;
    //                curr_sum = arr[i];
    //                if (stuReqd > m)
    //                {
    //                    return false;
    //                }
    //            }
    //            else
    //            {
    //                curr_sum += arr[i];
    //            }
    //        }
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class Fruits_Baskets
    {
        //subarray with k distinct elements 

       public static void Longest(int[] a , int n , int k)
        {
            int[] freq = new int[7];
            int start = 0;
            int end = 0;
            int now = 0;
            int l = 0;
            for (int i = 0; i < n; i++)
            {
                // mark the element visited 
                freq[a[i]]++;

                // if its visited first time, then increase 
                // the counter of distinct elements by 1 
                if (freq[a[i]] == 1)
                    now++;

                // When the counter of distinct elements 
                // increases from k, then reduce it to k 
                while (now > k)
                {

                    // from the left, reduce the number of 
                    // time of visit 
                    freq[a[l]]--;

                    // if the reduced visited time element 
                    // is not present in further segment 
                    // then decrease the count of distinct 
                    // elements 
                    if (freq[a[l]] == 0)
                        now--;

                    // increase the subsegment mark 
                    l++;
                }

                // check length of longest sub-segment 
                // when greater then previous best 
                // then change it 
                if (i - l + 1 >= end - start + 1)
                {
                    end = i;
                    start = l;
                }
            }
            // print the longest sub-segment 
            for (int i = start; i <= end; i++)
                Console.Write(a[i] + " ");
        }
    }
}

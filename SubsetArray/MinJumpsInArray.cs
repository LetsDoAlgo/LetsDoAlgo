using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class MinJumpsInArray
    {
      public static int minJumps(int[] arr , int l ,  int h)
        {
            //base case when elements are not in array 
            if (h==l)
            {
                return 0;
            }

            //when value is 0 == > no jump 
            if (arr[l]==0)
            {
                return int.MaxValue;
            }

            int min = int.MaxValue;
            for (int i= l+1; i <=h&&i<=l+arr[l]; i++)
            {
                int jumps = minJumps(arr, i, h);
                if (jumps != int.MaxValue && jumps + 1 < min)
                    min = jumps + 1;
            }
            return min;
        }

        //dp approach 
        public static int MinJumps_DP(int[] arr, int n )
        {
            //if value of arr element is 0 : val : maxvalue 
            int[] jumps = new int[n];
            if (n==0 ||arr[0]==0)
            {
                return int.MaxValue;
            }

            jumps[0] = 0;
            //loop through  all the remainig array
            for (int i = 1; i < n; i++)
            {
                jumps[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i<=j+arr[j]&&jumps[j]!=int.MaxValue)
                    {
                        jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                    }
                }
            }
            return jumps[n - 1];
        }


        //o(n)
       public static int minJumps_N(int[] arr)
        {
            if (arr.Length <= 1)
                return 0;

            // Return -1 if not  
            // possible to jump 
            if (arr[0] == 0)
                return -1;

            // initialization 
            int maxReach = arr[0];
            int step = arr[0];
            int jump = 1;


            // Start traversing array 
            for (int i = 1; i < arr.Length; i++)
            {
                // Check if we have reached  
                // the end of the array 
                if (i == arr.Length - 1)
                    return jump;

                // updating maxReach 
                maxReach = Math.Max(maxReach, i + arr[i]);

                // we use a step to get 
                // to the current index 
                step--;

                // If no further steps left 
                if (step == 0)
                {
                    // we must have used a jump 
                    jump++;

                    // Check if the current index/position  
                    // or lesser index is the maximum reach 
                    // point from the previous indexes 
                    if (i >= maxReach)
                        return -1;

                    // re-initialize the steps to 
                    // the amount of steps to reach  
                    // maxReach from position i. 
                    step = maxReach - i;
                }
            }

            return -1;
        }
    }
}

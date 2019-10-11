using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class ChocolateDistributionProblem
    {
       public static int maxNumOfChocolates(int[] arr,int n, int k)
        {
            // Hash table 
            Dictionary<int, int> um =   new Dictionary<int, int>();

            // 'sum[]' to store cumulative  
            // sum, where sum[i] =  
            // sum(arr[0]+..arr[i]) 
            int[] sum = new int[n];
            int curr_rem;

            // To store sum of sub-array 
            // having maximum sum 
            int maxSum = 0;

            // Building up 'sum[]' 
            sum[0] = arr[0];
            for (int i = 1; i < n; i++)
                sum[i] = sum[i - 1] + arr[i];

            // Traversing 'sum[]' 
            for (int i = 0; i < n; i++)
            {

                // Finding current 
                // remainder 
                curr_rem = sum[i] % k;

                // If true then sum(0..i)  
                // is divisible by k 
                if (curr_rem == 0)
                {
                    // update 'maxSum' 
                    if (maxSum < sum[i])
                        maxSum = sum[i];
                }

                // If value 'curr_rem' not 
                // present in 'um' then store 
                // it in 'um' with index of  
                // its first occurrence 
                else if (!um.ContainsKey(curr_rem))
                    um.Add(curr_rem, i);

                else

                    // If true, then 
                    // update 'max' 
                    if (maxSum < (sum[i] - sum[um[curr_rem]]))
                    maxSum = sum[i] - sum[um[curr_rem]];
            }

            // Required maximum number  
            // of chocolates to be  
            // distributed equally 
            // among 'k' students 
            return (maxSum / k);
        }

        //sort array 
        //create subarray of size m with minimum difference 
        public static int findDiff(int[] arr , int m ,int n)
        {
        
            //check base case
            //m is no. of students 
            //n is array length 
            if(m==0||n==0)
            {
                return 0;
            }
            if(m>n)
            {
                return -1;
            }
            Array.Sort(arr);
            int min_diff = int.MaxValue;
            int first = 0;
            int last = 0;
            for (int i = 0; i+m-1 < n; i++)
            {
                //subarray of size m s.t. difference between 
                //last and first 
                //is minimum 
                int diff = arr[i + m - 1] - arr[i];
                if (diff<min_diff)
                {
                    min_diff = diff;
                    first = i;
                    last = i + m - 1;
                } 
            }
            return arr[last] - arr[first];
        }
    }
}


//Maximum number of chocolates to be distributed equally among k students
//Given n boxes containing some chocolates arranged in a row.There are k number of students.The problem is to distribute maximum number of chocolates equally among k students by selecting a consecutive sequence of boxes from the given lot.Consider the boxes are arranged in a row with numbers from 1 to n from left to right. We have to select a group of boxes which are in consecutive order that could provide maximum number of chocolates equally to all the k students.An array arr[] is given representing the row arrangement of the boxes and arr[i] represents number of chocolates in that box at position ‘i’.

//Examples:

//Input : arr[] = { 2, 7, 6, 1, 4, 5}, k = 3
//Output : 6
//The subarray is {7, 6, 1, 4} with sum 18.
//Equal distribution of 18 chocolates among
//3 students is 6.
//Note that the selected boxes are in consecutive order
//with indexes {1, 2, 3, 4}.
//Source: Asked in Amazon.

//Recommended: Please try your approach on {IDE} first, before moving on to the solution.
//The problem is to find maximum sum sub-array divisible by k and then return (sum / k).

//Method 1 (Naive Approach): Consider the sum of all the sub-arrays.Select the maximum sum.Let it be maxSum.Return (maxSum / k). Time Complexity is of O(n2).

//Method 2 (Efficient Approach): Create an array sum[] where sum[i] stores sum(arr[0]+..arr[i]). Create a hash table having tuple as (ele, idx), where ele represents an element of(sum[i] % k) and idx represents the element’s index of first occurrence when array sum[] is being traversed from left to right.Now traverse sum[] from i = 0 to n and follow the steps given below.


//Calculate current remainder as curr_rem = sum[i] % k.
//If curr_rem == 0, then check if maxSum<sum[i], update maxSum = sum[i].
//Else if curr_rem is not present in the hash table, then create tuple (curr_rem, i) in the hash table.
//Else, get the value associated with curr_rem in the hash table.Let this be idx. Now, if maxSum< (sum[i] – sum[idx]) then update maxSum = sum [i] – sum [idx].
//Finally, return (maxSum / k).

//Explanation:
//If (sum [i] % k) == (sum [j] % k), where sum [i] = sum(arr [0]+..+arr [i]) and sum [j] = sum(arr [0]+..+arr [j]) and ‘i’ is less than ‘j’, then sum(arr [i+1]+..+arr [j]) must be divisible by ‘k’.

//filter_none
//edit
//play_arrow

//brightness_4
// C# implementation to find  
// the maximum number of  
// chocolates to be distributed  
//// equally among k students 
//using System; 
//using System.Collections.Generic; 
  
//class GFG
//{
//    // Function to find the  
//    // maximum number of  
//    // chocolates to be distributed  
//    // equally among k students 
//    static int maxNumOfChocolates(int[] arr,
//                                  int n, int k)
//    {
//        // Hash table 
//        Dictionary<int, int> um =
//                    new Dictionary<int, int>();

//        // 'sum[]' to store cumulative  
//        // sum, where sum[i] =  
//        // sum(arr[0]+..arr[i]) 
//        int[] sum = new int[n];
//        int curr_rem;

//        // To store sum of sub-array 
//        // having maximum sum 
//        int maxSum = 0;

//        // Building up 'sum[]' 
//        sum[0] = arr[0];
//        for (int i = 1; i < n; i++)
//            sum[i] = sum[i - 1] + arr[i];

//        // Traversing 'sum[]' 
//        for (int i = 0; i < n; i++)
//        {

//            // Finding current 
//            // remainder 
//            curr_rem = sum[i] % k;

//            // If true then sum(0..i)  
//            // is divisible by k 
//            if (curr_rem == 0)
//            {
//                // update 'maxSum' 
//                if (maxSum < sum[i])
//                    maxSum = sum[i];
//            }

//            // If value 'curr_rem' not 
//            // present in 'um' then store 
//            // it in 'um' with index of  
//            // its first occurrence 
//            else if (!um.ContainsKey(curr_rem))
//                um.Add(curr_rem, i);

//            else

//                // If true, then 
//                // update 'max' 
//                if (maxSum < (sum[i] - sum[um[curr_rem]]))
//                         maxSum = sum[i] - sum[um[curr_rem]];
//        }

//        // Required maximum number  
//        // of chocolates to be  
//        // distributed equally 
//        // among 'k' students 
//        return (maxSum / k);
//    }

//    // Driver Code 
//    static void Main()
//    {
//        int[] arr = new int[] { 2, 7, 6, 1, 4, 5 };
//        int n = arr.Length;
//        int k = 3;
//        Console.Write("Maximum number of chocolates: " +
//                         maxNumOfChocolates(arr, n, k));
//    }
//}

// This code is contributed by 
// Manish Shaw(manishshaw1) 

//Output :
//Maximum number of chocolates: 6
//Time Complexity: O(n).
//Auxiliary Space: O(n).


/////////////////////////////////////

    // A Dynamic Programming based
// C# program to find minimum
// number of jumps to reach
//// Destination
//class GFG
//{

//    // Function that returns the min
//    // number of jump to reach the
//    // destination
//    public static int minJumps(int[] arr, int N)
//    {
//        int MAX = 1000000;

//        // We consider only those Fibonacci
//        // numbers which are less than n,
//        // where we can consider fib[30]
//        // to be the upper bound as this
//        // will cross 10^5
//        int[] fib = new int[30];
//        fib[0] = 0;
//        fib[1] = 1;

//        for (int i = 2; i < 30; i++) fib[i] = fib[i - 1] + fib[i - 2];

    // DP[i] will be storing the minimum 
    // number of jumps required for 
    // the position i. So DP[N+1] will 
    // have the result we consider 0 
    // as source and N+1 as the destination int[] DP = new int[N + 2]; 
    // Base case (Steps to reach source is) DP[0] = 0; 
    // Initialize all table values as Infinite for (int i = 1; i <= N + 1; i++) DP[i] = MAX; 
    // Compute minimum jumps required 
    // considering each Fibonacci 
    // numbers one by one. 
    // Go through each positions 
    // till destination. for (int i = 1; i <= N + 1; i++) { 
    // Calculate the minimum of that 
    // position if all the Fibonacci
    // numbers are considered for (int j = 1; j < 30; j++) { 
    // If the position is safe 
    // or the position is the
    // destination then only we 
    // calculate the minimum 
    // otherwise the cost is
    // MAX as default if ((i == N + 1 || arr[i - 1] == 1) && i - fib[j] >= 0)
//        DP[i] = Math.Min(DP[i], 1 +
//        DP[i – fib[j]]);
//    }
//}

//// -1 denotes if there is
//// no path possible
//if (DP[N + 1] != MAX)
//return DP[N + 1];
//else
//return -1;
//}

//// Driver Code
//public static void Main(String[] args)
//{
//    int[] arr = new int[]{ 0, 0, 0, 1, 1, 0,
//1, 0, 0, 0, 0 };
//    int n = 11;
//    int ans = minJumps(arr, n);
//    Console.WriteLine(ans);
//}
//}
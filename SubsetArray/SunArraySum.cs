using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //Initialize a variable curr_sum as the first element.
    //curr_sum indicates the sum of the current subarray.Start from the second element and add all elements one by one to the curr_sum. If curr_sum becomes equal to the sum, then print the solution. If curr_sum exceeds the sum, then remove trailing elements while curr_sum is greater than the sum.
   public static class SubArraySum
    {
        public static void CalculateSun(int[] arr, int sum )
        {
            var current_sum = arr[0];
            int start = 0;
            
            for (int i = 1; i < arr.Length; i++)
            {
                current_sum += arr[i];
                while (current_sum>sum && start<i-1)
                {

                    current_sum -= arr[start];
                    start++;
                }

                //if sum becomes equal 
                if (current_sum==sum)
                {
                    int p = i - 1;
                    Console.WriteLine("sum found between indexes"+start+"----"+p);
                }

                if (i< arr.Length)
                {
                    current_sum += arr[i];
                }
            }
        }

        //we are crating the dictionary of sum and index 
        //Time complexity of above solution is O(N) if we perform hashing with the help of an array.
        //Time complexity of above solution is O(N) if we perform hashing with the help of an array.In case the elements cannot be hashed in an array we use a hash map as shown in the above code.
        //Auxiliary space used by the program is O(n).
        public static void subArraySum(int[] arr, int n, int sum)
        {
            //cur_sum to keep track of cummulative sum till that point  
            int cur_sum = 0;
            int start = 0;
            int end = -1;
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                cur_sum = cur_sum + arr[i];
                //check whether cur_sum - sum = 0, if 0 it means  
                //the sub array is starting from index 0- so stop  
                if (cur_sum - sum == 0)
                {
                    start = 0;
                    end = i;
                    break;
                }
                //if hashMap already has the value, means we already   
                // have subarray with the sum - so stop  
                if (hashMap.ContainsKey(cur_sum - sum))
                {
                    start = hashMap[cur_sum - sum] + 1;
                    end = i;
                    break;
                }
                //if value is not present then add to hashmap  
                hashMap[cur_sum] = i;

            }
            // if end is -1 : means we have reached end without the sum  
            if (end == -1)
            {
                Console.WriteLine("No subarray with given sum exists");
            }
            else
            {
                Console.WriteLine("Sum found between indexes " + start + " to " + end);
            }

        }
    }


//    The time complexity of method 2 looks more than O(n), but if we take a closer look at the program, then we can figure out the time complexity is O(n). We can prove it by counting the number of operations performed on every element of arr[] in the worst case. There are at most 2 operations performed on every element: (a) the element is added to the curr_sum(b) the element is subtracted from curr_sum.So the upper bound on the number of operations is 2n which is O(n).

//The above solution doesn’t handle negative numbers.We can use hashing to handle negative numbers.
}

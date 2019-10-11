using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class FindSubsetsWithSum_DP
    {
        public static bool subsetSum(int[] arr, int n , int sum )
        {
            bool[,] T1 = new bool[arr.Length + 1, sum + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                T1[i, 0] = true;
            }

            for (int i = 1  ; i <=arr.Length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    //sum>input element 
                    if (j>=arr[i-1])
                    {
                        T1[i, j] = T1[i - 1, j] || T1[i - 1, sum - arr[i - 1]];

                    }
                    else
                    {
                        T1[i, j] = T1[i-1,j];
                    }
                }
            }
            return T1[arr.Length,sum];
        }

       static bool[,] T1;
        public static void Printsubset(int[] arr, int n, int sum)
        {
            T1 = new bool[arr.Length , sum + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                T1[i, 0] = true;
            }
            if (arr[0]<=sum)
            {
                T1[0, arr[0]] = true;
            }
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    //sum>input element 
                    if (j >= arr[i])
                    {
                        T1[i, j] = T1[i-1, j] || T1[i - 1, j - arr[i - 1]];

                    }
                    else
                    {
                        T1[i, j] = T1[i - 1, j];
                    }
                }
            }

            if (T1[n-1,sum]==false)
            {
                return;
            }
            List<int> list = new List<int>();
            PSR(arr, n - 1, sum, list);
        }

        private static void PSR(int[] arr, int i, int sum, List<int> list)
        {
            //vector p[] which stores the current subset 

            //reached the end & sum is non -zero 
            //and dp[0,sum] is true
            if (i==0 && sum!=0&&T1[0,sum])
            {
                list.Add(arr[i]);
                foreach (var item in list)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                list.Clear();
                return;
            }

            //if sum==0 and elements also 0 
            if (i==0  && sum==0)
            {
                foreach (var item in list)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                return;
            }

            //if given sum can be achieved after ignoring current 
            //elemnet
            if(T1[i-1,sum])
            {
                List<int> b = new List<int>(list);
                PSR(arr, i - 1, sum, b);
            }

            if (sum>=arr[i]&& T1[i-1,sum-arr[i]])
            {
                list.Add(arr[i]);
                PSR(arr,i-1,sum-arr[i],list);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class TripletWithSum0
    {
        // Driven source 
    //static public void Main()
    //    {

    //        int[] arr = { 0, -1, 2, -3, 1 };
    //        int n = arr.Length;
    //        findTriplets(arr, n);
    //    }
        static void Triplet(int[] arr ,  int n)
        {
            bool found = false;
            Array.Sort(arr);
            for (int i = 0; i < n-1; i++)
            {
                int l = i + 1;
                int r = n - 1;
                int x = arr[i];
                while (l<r)
                {
                    if (x+arr[l]+arr[r]==0)
                    {
                        //print
                        // print elements if it's sum is zero 
                        Console.Write(x + " ");
                        Console.Write(arr[l] + " ");
                        Console.WriteLine(arr[r] + " ");
                        l++;
                        r--;
                        found = true;
                    }
                    else if(x+arr[l]+arr[r]<0)
                    {
                        // If sum of three elements is less 
                        // than zero then increment in left 
                        l++;
                    }
                    else
                    {
                        // if sum is greater than zero than 
                        // decrement in right side 
                        r--;
                    }

                }
            }

            if (found==false)
            {
                Console.WriteLine("not found");
            }
        }
    }
}

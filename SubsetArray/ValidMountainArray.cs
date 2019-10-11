using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class ValidMountainArray
    {
        public bool IsValidMt(int[] a)
        {
            //take 2 pointers 
            //compare
            //pointer behind is low and after one is more 
            int i = 0;
            //checking for increasig seq
            while (i < a.Length && i+1 < a.Length &&  a[i] < a[i+1])
            {
                i++;
            }

            if (i==0||i+1>=a.Length)
            {
                return false;
            }

            //checking for dec seq 
            while (i<a.Length && i+1<a.Length&& a[i] > a[i + 1])
            {
                i += 1;
            }

            return (i==a.Length-1);
        }
    }
}
////tc ;o(n)
//Time Complexity: O(N)O(N), where NN is the length of A.

//Space Complexity: O(1)O(1).
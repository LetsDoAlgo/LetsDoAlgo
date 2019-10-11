using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    public static class SortPositiveNumbersOnly
    {
        public static void sortArray(int[] a , int n)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (a[i]>=0)
                {
                    list.Add(a[i]);
                }
              
            }

            list.Sort();

            int j = 0;
            for (int i = 0; i < n; i++)
            {

                // If current element is non-negative then 
                // update it such that all the 
                // non-negative values are sorted 
                if (a[i] >= 0)
                {
                    a[i] = list[j];
                    j++;
                }
            }
        }
    }
}

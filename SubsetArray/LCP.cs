using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class LCP
    {
       public static string longestCommonPrefix(String[] a)
        {
            int size = a.Length;

            /* if size is 0, return empty string */
            if (size == 0)
                return "";

            if (size == 1)
                return a[0];

            /* sort the array of strings */
            Array.Sort(a);

            /* find the minimum length from first 
            and last string */
            int end = Math.Min(a[0].Length,
                                a[size - 1].Length);

            /* find the common prefix between the  
            first and last string */
            int i = 0;
            while (i < end && a[0][i] == a[size - 1][i])
                i++;

            string pre = a[0].Substring(0, i);
            return pre;
        }
    }
}

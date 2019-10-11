using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class ReverseString
    {
       public static string reverse(string str)
        {
            int length = str.Length;
            string rev = "";
            var charArr = str.ToCharArray();
            while (length>=0)
            {
                rev = rev + str[length];
                length--;
            }
            return new string(charArr);
            
        }

        public static int reverse(int n)
        {
            int rev = 0;
            //base condition 
            //num>0 ---------IMP
            while (n>0)
            {
                int rem = n % 10;
                rev = (rev * 10) + rem;
                n = n / 10;

            }
            return rev;
        }
    }
}

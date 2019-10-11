using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //there will be power(2,n)---> subsequences 
    //there will be n(n+1)/2 ----> substrings 
   public class SubStr_SubSeq
    {
//        Input :  abcd
//Output :  a
//          b
//          c
//          d
//          ab
//          bc
//          cd
//          abc
//          bcd
//          abcd
        //print all substrings 
        // Function to print all sub strings 
        void subString(string s, int n)
        {
            // Pick starting point in outer loop 
            // and lengths of different strings for 
            // a given starting point 
            for (int i = 0; i < n; i++)
                for (int len = 1; len <= n - i; len++)
                    Console.WriteLine(s.Substring(i, len));
        }

        static void PrintSubStr(string str1, int n)
        {
            //current startig point
            //current endin point 
            //find substrings between them 
            for (int len = 1; len < n; len++)
            {
                for (int i = 0; i <= n-len; i++)
                {
                    int j = i + len - 1;
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(str1[k]);
                    }
                    Console.WriteLine();
                }
            }
        }

    //    string str = "abc";
    //printSubSeq(str, "");
        static void PrintSubeq(string str1 , string empty)
        {
            if (str1.Length==0)
            {
                Console.Write(""+empty+"");
                return;
            }

            //first char of str1
            char ch = str1[0];

            //substring starting from second char of str1
            string ros = str1.Substring(1);
            // Excluding first character
            PrintSubeq(ros, empty);

            // Including first character  
            PrintSubeq(ros, empty + ch);

        }

    }


   public static class GFG_
    {

        static int MAX_CHARS = 26;

        // This function calculates number of unique characters 
        // using a associative array count[]. Returns true if 
        // no. of characters are less than required else returns 
        // false. 
        static bool isValid(int[] count, int k)
        {
            int val = 0;
            for (int i = 0; i < MAX_CHARS; i++)
            {
                if (count[i] > 0)
                {
                    val++;
                }
            }

            // Return true if k is greater than or equal to val 
            return (k >= val);
        }

        // Finds the maximum substring with exactly k unique chars 
       public static void kUniques(string s, int k)
        {
            int u = 0; // number of unique characters 
            int n = s.Length;

            // Associative array to store the count of characters 
            int[] count = new int[MAX_CHARS];
           // Array.Fill(count, 0);
            // Traverse the string, Fills the associative array 
            // count[] and count number of unique characters 
            for (int i = 0; i < n; i++)
            {
                if (count[s[i] - 'a'] == 0)
                {
                    u++;
                }
                count[s[i] - 'a']++;
            }

            // If there are not enough unique characters, show 
            // an error message. 
            if (u < k)
            {
                Console.Write("Not enough unique characters");
                return;
            }

            // Otherwise take a window with first element in it. 
            // start and end variables. 
            int curr_start = 0, curr_end = 0;

            // Also initialize values for result longest window 
            int max_window_size = 1, max_window_start = 0;

            // Initialize associative array count[] with zero 
            //   Array.Fill(count, 0);
            Array.Clear(count, 0, count.Length);
            count[s[0] - 'a']++;  // put the first character 

            // Start from the second character and add 
            // characters in window according to above 
            // explanation 
            for (int i = 1; i < n; i++)
            {
                // Add the character 's[i]' to current window 
                count[s[i] - 'a']++;
                curr_end++;

                // If there are more than k unique characters in 
                // current window, remove from left side 
                while (!isValid(count, k))
                {
                    count[s[curr_start] - 'a']--;
                    curr_start++;
                }

                // Update the max window size if required 
                if (curr_end - curr_start + 1 > max_window_size)
                {
                    max_window_size = curr_end - curr_start + 1;
                    max_window_start = curr_start;
                }
            }

            Console.Write("Max sustring is : "
                    + s.Substring(max_window_start, max_window_size)
                    + " with length " + max_window_size);
        }

        //// Driver function 
        //static public void Main()
        //{
        //    string s = "aabacbebebe";
        //    int k = 3;
        //    kUniques(s, k);
        //}
    }

}

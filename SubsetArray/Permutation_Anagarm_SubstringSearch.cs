using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    
public class Permutation_Anagarm_SubstringSearch
    {
//        A simple idea is to modify Rabin Karp Algorithm.For example we can keep the hash value as sum of ASCII values of all characters under modulo of a big prime number.For every character of text, we can add the current character to hash value and subtract the first character of previous window.This solution looks good, but like standard Rabin Karp, the worst case time complexity of this solution is O(mn). The worst case occurs when all hash values match and we one by one match all characters.

//We can achieve O(n) time complexity under the assumption that alphabet size is fixed which is typically true as we have maximum 256 possible characters in ASCII.The idea is to use two count arrays:
//        1) The first count array store frequencies of characters in pattern.
//2) The second count array stores frequencies of characters in current window of text.

//The important thing to note is, time complexity to compare two count arrays is O(1) as the number of elements in them are fixed (independent of pattern and text sizes). Following are steps of this algorithm.
//1) Store counts of frequencies of pattern in first count array countP[]. Also store counts of frequencies of characters in first window of text in array countTW[].

//2) Now run a loop from i = M to N-1. Do following in loop.
//…..a) If the two count arrays are identical, we found an occurrence.
//…..b) Increment count of current character of text in countTW[]
//…..c) Decrement count of first character in previous window in countWT[]

//3) The last window is not checked by above loop, so explicitly check it.
        //// Driver Code 
        //public static void Main(string[] args)
        //{
        //    string txt = "BACDGABCDA";
        //    string pat = "ABCD";
        //    search(pat, txt);
        //}
        //pattern chota hota hain 
        //data bada hota hai
        public List<int> search(string pattern , string data )
        {
            List<int> retVal = new List<int>();
            char[] countP = new char[256];
            char[] countT = new char[256];

            for (int i = 0; i < pattern.Length; i++)
            {
                (countP[pattern[i]])++;
                (countT[data[i]])++;
            }

            for (int i = pattern.Length; i < data.Length; i++)
            {
                //compare counts 
                //add current char to current window 
                //remove the first char of previosu window 
                if (Compare(countP,countT))
                {
                    retVal.Add(i - pattern.Length);
                }
                countT[data[i]]++;
                countT[data[i - pattern.Length]]--;
            }

            if (Compare(countP,countT))
            {
                retVal.Add(data.Length - pattern.Length);
            }
            return retVal;
        }

        private bool Compare(char[] countP, char[] countT)
        {
            for (int i = 0; i <256; i++)
            {
                if (countP[i]!=countT[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    
}

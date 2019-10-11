using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{

    //    Find largest word in dictionary by deleting some characters of given string
    //Giving a dictionary and a string ‘str’, find the longest string in dictionary which can be formed by deleting some characters of the given ‘str’.

    //Examples:

    //Input : dict = {"ale", "apple", "monkey", "plea"}
    //str = "abpcplea"  
    //Output : apple

    //Input  : dict = {"pintu", "geeksfor", "geeksgeeks", 
    //                                        " forgeek"} 
    //         str = "geeksforgeeks"
    //Output : geeksgeeks

//Time Complexity : O(N* K*n) Here N is the length of dictionary and n is the length of given string ‘str’ and K – maximum length of words in the dictionary.

//Auxiliary Space : O(1)
   public static class LCSModified
    {
        public static string FindLongestString(List<string> dict , string str)
        {
            string result = "";
            int minLength = 0;
            foreach (var item in dict)
            {
                if (minLength<item.Length&& isSubseq(item, str))
                {
                    result = item;
                    minLength = item.Length;

                }

            }
            return result;
         
        }

        private static bool isSubseq(string dictStr, string givenStr)
        {
            int m = dictStr.Length;
            int n = givenStr.Length;
            int j = 0;//for index of str1

            // Traverse str2 and str1, and compare current  
            // character of str2 with first unmatched char  
            // of str1, if matched then move ahead in str1  
            for (int i = 0; i < n && j<m; i++)
            {
                if (dictStr[j]==givenStr[i])
                {
                    j++;
                }
            }

            return (j==m);
        }
    }
}

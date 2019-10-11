using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class WildCardMatching
    {
        //boolean array 
        //time complexity : o(n*m)
        //        / If current characters match, result is same as 
        //// result for lengths minus one. Characters match
        //// in two cases:
        //// a) If pattern character is '?' then it matches  
        ////    with any character of text. 
        //// b) If current characters in both match
        //if ( pattern[j – 1] == ‘?’) || 
        //     (pattern[j – 1] == text[i - 1])
        //    T[i][j] = T[i - 1][j - 1]   
 
        //// If we encounter ‘*’, two choices are possible-
        //// a) We ignore ‘*’ character and move to next 
        ////    character in the pattern, i.e., ‘*’ 
        ////    indicates an empty sequence.
        //// b) '*' character matches with ith character in
        ////     input 
        //else if (pattern[j – 1] == ‘*’)
        //    T[i][j] = T[i][j - 1] || T[i - 1][j]  

        //else // if (pattern[j – 1] != text[i - 1])
        //    T[i][j]  = false 
        public bool IsMatch(string str , string pattern, int n , int m )
        {
            //case1: pattern:empty
            //empty pattern canmatch with empty string 
            if (m==0)
            {
                return (n == 0);
            }

            bool[,] lookup = new bool[n + 1, m + 1];

            //initialize to false
            for (int i = 0; i < n+1; i++)
            {
                for (int j = 0; j < m+1; j++)
                {
                    lookup[i, j] = false;
                }
            }

            //empty pattern can match with empty string 
            lookup[0, 0] = true;

            //only * Can match with empty string
            for (int j = 1; j < m; j++)
            {
                if (pattern[j-1]=='*')
                {
                    lookup[0, j] = lookup[0, j - 1];
                }
            }

            //fill table in botton up fshion 
            for (int i = 1; i <=n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (pattern[j-1]=='*')
                    {
                        lookup[i, j] = lookup[i, j - 1] || lookup[i - 1, j];
                    }
                    else if(pattern[j-1]=='?'||str[i-1]==pattern[j-1])
                    {
                        lookup[i, j] = lookup[i - 1, j - 1];
                        
                    }
                    else
                    {
                        //if chars do not match 
                        lookup[i, j] = false;
                    }
                }
            }
            return lookup[n, m];
          
            
        }

        //how to do in linear time 

    }
}

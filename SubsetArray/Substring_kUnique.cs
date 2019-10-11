using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class Substring_kUnique
    {
        //maintain windiow
        //ad till less that or equal to k 
        //update result whle doing 
        //if elements exceeds required window 
        //then remove elements 

        static int max_Chars = 26;
        static bool IsValid(int[] count , int k )
        {
            int val = 0;
            for (int i = 0; i < max_Chars; i++)
            {
                if (count[i]>0)
                {
                    val++;
                }
            }
            return (k >= val);
        }

        static void KUniques(string s , int k)
        {
            int uniqueChar = 0;
            int n = s.Length;
            int[] count = new int[max_Chars];
            for (int i = 0; i < n; i++)
            {
                if (count[s[i]-'a']==0)
                {
                    uniqueChar++;
                }
                count[s[i] - 'a']++;
            }

            if (uniqueChar<k)
            {
                return;
            }

            int curr_Start = 0;
            int curr_end = 0;
            int max_window_size = 1;
            int max_Window_Start = 0;
            Array.Clear(count, 0, count.Length);

            count[s[0] - 'a']++; //put first char
            for (int i = 0; i < n; i++)
            {
                count[s[i] - 'a']++;
                curr_end++;
                //zero wali value ko nikalo 
                //and end wali ko add karo 
                while (!IsValid(count,k))
                {
                    count[s[curr_Start] - 'a']--;
                    curr_Start++;
                }
                //update the max_window_Size
                if (curr_end-curr_Start+1>max_window_size)
                {
                    max_window_size = curr_end - curr_Start;
                    max_Window_Start = curr_Start;
                }
            }
        }
    }
}

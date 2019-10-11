using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class PhoneNumberCombinations
    {
        // Function to return a vector that contains  
        // all the generated letter combinations 
       public static List<string> letterCombinationsUtil(int[] number, int n,string[] table)
        {
            // To store the generated letter combinations 
            List<string> list = new List<string>();

            Queue<string> q = new Queue<string>();
            q.Enqueue("");

            while (q.Count!=0)
            {
                string s = q.Dequeue();

                // If complete word is generated  
                // push it in the list 
                if (s.Length == n)
                    list.Add(s);
                else
                {
                    string val = table[number[s.Length]];
                    for (int i = 0; i < val.Length; i++)
                    {
                        q.Enqueue(s + val.ToCharArray()[i]);
                    }
                }
            }
            return list;
        }

        // Function that creates the mapping and  
        // calls letterCombinationsUtil  
       public static void letterCombinations(int[] number, int n)
        {
            // table[i] stores all characters that  
            // corresponds to ith digit in phone 
            String[] table = { "", "", "abc", "def", "ghi", "jkl",
            "mno", "pqrs", "tuv", "wxyz" };

            List<String> list =
                        letterCombinationsUtil(number, n, table);

            // Print the contents of the list 
            for (int i = 0; i < list.Count; i++)
            {
               // System.out.print(list.get(i) + " ");
            }
        }

    }
}

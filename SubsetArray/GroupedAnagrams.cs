using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class GroupedAnagrams
    {
        public static List<List<string>> FindGroupedAnagrams(string[] strs)
        {
           List<List<string>> result = new List<List<string>>();
           Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                char[] arr = str.ToCharArray();
                Array.Sort(arr);
                var str1 = string.Join("", arr);
                if (map.ContainsKey(str1))
                {
                    //add to the list of tat key 
                    var val = map[str1];
                    val.Add(str);
                    map[str1] = val;
                }
                else
                {
                    map.Add(str1, new List<string>() { str});
                }
            }
            return null;
        }
    
        public static void PrintAnagrams(string[] arr)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            //traverse all words
            for (int i = 0; i < arr.Length; i++)
            {
                string word = arr[i];
                char[] letters = word.ToCharArray();
                Array.Sort(letters);
                string newword = new string(letters);
                if (map.ContainsKey(newword))
                {
                    map[newword].Add(word);
                }
                else
                {
                    List<string> words = new List<string>();
                    words.Add(word);
                    map.Add(newword, words);

                }
            }

            //print
            List<string> value = new List<string>();
            foreach (KeyValuePair<string,List<string>> item in map)
            {
                value.Add(item.Key);
            }

            int k = 0;
            foreach (KeyValuePair<string,List<string>> item in map)
            {
                List<string> values = map[value[k++]];
                if (values.Count>1)
                {
                    Console.Write("[");
                    int len = 1;
                    foreach (string s in values)
                    {
                        Console.Write(s);
                        if (len++<values.Count)
                        {
                            Console.Write(",");
                        }
                        Console.Write("]");
                    }
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
  public static class Permutation
    {
        public static void swapTwoNumber(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void prnPermut(int[] list, int k, int m)
        {
            int i;
            if (k == m)
            {
                for (i = 0; i <= m; i++)
                    Console.Write("{0}", list[i]);
                Console.Write(" ");
            }
            else
                for (i = k; i <= m; i++)
                {
                    swapTwoNumber(ref list[k], ref list[i]);
                    prnPermut(list, k + 1, m);
                    swapTwoNumber(ref list[k], ref list[i]);
                }
        }

        //   Print all possible strings of length k that can be formed from a set of n characters

        // The method that prints all  
        // possible strings of length k. 
        // It is mainly a wrapper over  
        // recursive function printAllKLengthRec() 
       public static void printAllKLength(char[] set, int k)
        {
            int n = set.Length;
            printAllKLengthRec(set, "", n, k);
        }

        // The main recursive method 
        // to print all possible  
        // strings of length k 
       public static void printAllKLengthRec(char[] set,
                               String prefix,
                               int n, int k)
        {

            // Base case: k is 0, 
            // print prefix 
            if (k == 0)
            {
                Console.WriteLine(prefix);
                return;
            }

            // One by one add all characters  
            // from set and recursively  
            // call for k equals to k-1 
            for (int i = 0; i < n; ++i)
            {

                // Next character of input added 
                String newPrefix = prefix + set[i];

                // k is decreased, because  
                // we have added a new character 
                printAllKLengthRec(set, newPrefix,
                                        n, k - 1);
            }
        }

        //recurisve
        public static IList<IList<T>> Permutations<T>(IList<T> list)
        {
            List<IList<T>> perms = new List<IList<T>>();
            if (list.Count == 0)
                return perms; // Empty list.
            int factorial = 1;
            for (int i = 2; i <= list.Count; i++)
                factorial *= i;
            for (int v = 0; v < factorial; v++)
            {
                List<T> s = new List<T>(list);
                int k = v;
                for (int j = 2; j <= list.Count; j++)
                {
                    int other = (k % j);
                    T temp = s[j - 1];
                    s[j - 1] = s[other];
                    s[other] = temp;
                    k = k / j;
                }
                perms.Add(s);
            }
            return perms;
        }


     
    }


}

//DIFFERENT APPROACH
//private static void Test()
//{
//    List<string> list = new List<string>() { "A", "B", "C" };
//    IList<IList<string>> perms = Permutations(list);
//    foreach (IList<string> perm in perms)
//    {
//        foreach (string s in perm)
//        {
//            Console.Write(s);
//        }
//        Console.WriteLine();
//    }
//}
//private static IList<IList<T>> Permutations<T>(IList<T> list)
//{
//    List<IList<T>> perms = new List<IList<T>>();
//    if (list.Count == 0)
//        return perms; // Empty list.
//    int factorial = 1;
//    for (int i = 2; i <= list.Count; i++)
//        factorial *= i;
//    for (int v = 0; v < factorial; v++)
//    {
//        List<T> s = new List<T>(list);
//        int k = v;
//        for (int j = 2; j <= list.Count; j++)
//        {
//            int other = (k % j);
//            T temp = s[j - 1];
//            s[j - 1] = s[other];
//            s[other] = temp;
//            k = k / j;
//        }
//        perms.Add(s);
//    }
//    return perms;
//}
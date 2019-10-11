using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //The idea is to use two pointers, one from start and one from the end.
    //    Assume the start person is A, and the end person is B.
    //    If A knows B, then A must not be the celebrity.
    //Else, B must not be the celebrity. We will find a celebrity candidate at the end of the loop. Go through each person again and check whether this is the celebrity. Below is C++ implementation.
    class Celebrity
    {


        //// Driver Code 
        //public static void Main()
        //{
        //    int n = 4;
        //    int result = findCelebrity(n);
        //    if (result == -1)
        //    {
        //        Console.WriteLine("No Celebrity");
        //    }
        //    else
        //        Console.WriteLine("Celebrity ID " +
        //                                   result);
        //}
        static int[,] matrix = { {0,0,1,0 },
                                 {0,0,1,0 },
                                 {0,0,0,0 },
                                 { 0,0,1,0} };
        // Returns true if a knows 
        // b, false otherwise 
        static bool knows(int a, int b)
        {
            bool res = (matrix[a, b] == 1) ?
                                      true :
                                      false;
            return res;
        }

        public static int findCelebrity(int n)
        {
            //initiaize 2 pointers 
            int a = 0;
            int b = n - 1;
            while (a<b)
            {
                if (knows(a, b))
                {
                    a++;
                }
                else
                    b--;
            }

            for (int i = 0; i < n; i++)
            {
                if (i!=a && (knows(a,i)||!knows(i,a)))
                {
                    return -1;
                }
            }

            return a;
        }
    }
}

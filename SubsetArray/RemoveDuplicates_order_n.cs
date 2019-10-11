using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
//    Take a Set
//Insert all array element in the Set.Set does not allow duplicates and sets like LinkedHashSet maintains the order of insertion so it will remove duplicates and elements will be printed in the same order in which it is inserted.
//Convert the formed set into array.
//Print elements of Set.
    class RemoveDuplicates_order_n
    {
        // Function to remove duplicate from array 
        public static void removeDuplicates(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();

            // adding elements to LinkedHashSet 
            for (int i = 0; i < arr.Length; i++)
                set.Add(arr[i]);

            // Print the elements of HashSet 
            foreach (int item in set)
                Console.Write(item + ", ");
        }

    }
}

//// Driver code 
//public static void Main(String[] args)
//{
//    int[] arr = { 1, 2, 5, 1, 7, 2, 4, 2 };
//    removeDuplicates(arr);
//}
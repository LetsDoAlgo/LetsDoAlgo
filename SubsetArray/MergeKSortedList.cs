using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class MergeKSortedList
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
            }
        }

        public static Node SortedMerge(Node a , Node b)
        {
            Node result = null;
            if (a==null)
            {
                return b;
            }
            else if(b==null)
            {
                return a;
            }
            if (a.data<=b.data)
            {
                result = a;
                result.next = SortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortedMerge(a, b.next);
            }
            return result;
        }

        //Time Complexity of above algorithm is O(nk logk) as outer while loop in function mergeKLists() runs log k times and every time we are processing nk elements
        public static Node MergeKLists(Node[] arr , int last)
        {
            while (last!=0)
            {
                int i = 0, j = last;
                while (i<j)
                {
                    //merge list i and j and then update or store merged list in 
                    //list i 
                    arr[i] = SortedMerge(arr[i], arr[j]);
                    i++;j--;
                    //if all paires are merged , update the last 
                    if (i>=j)
                    {
                        last = j;
                    }
                }
            }
            return arr[0];
        }
    }
}

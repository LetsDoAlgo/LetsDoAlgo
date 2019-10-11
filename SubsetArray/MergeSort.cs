using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //https://www.geeksforgeeks.org/merge-sort-for-linked-list/
    public class MergeSort
    {
        public class NodeL
        {
            public int val;
            public NodeL next;
            public NodeL(int val)
            {
                this.val = val;

            }
        }

        //pick a and b and recur 
        public class LinkedList
        {
            NodeL head = null;
            NodeL sortedMerge(NodeL a , NodeL b)
            {
                NodeL result = null;
                if (a==null)
                {
                    return b;
                }
                if(b==null)
                {
                    return a;
                }
                if (a.val<b.val)
                {
                    result = a;
                    result.next = sortedMerge(a.next, b);
                }
                else
                {
                    result = b;
                    result.next = sortedMerge(a, b.next);
                }
                return result;
            }

            public NodeL PerformMergeSort(NodeL h)
            {
                if (h==null||h.next==null)
                {
                    return h;
                }
                //get middle of the list 
                NodeL middle = getMiddle(h);
                NodeL nextmiddle = middle.next;
                middle.next = null;

                //mergesort on the left side 
                NodeL left = PerformMergeSort(h);

                NodeL right = PerformMergeSort(nextmiddle);

                NodeL sortedList = sortedMerge(left, right);

                return sortedList;

            }

            private NodeL getMiddle(NodeL h)
            {

                if (h==null)
                {
                    return h;
                }
                NodeL fastptr = h.next;
                NodeL slowptr = h;
                while (fastptr!=null)
                {
                    fastptr = fastptr.next;
                    if (fastptr!=null)
                    {
                        slowptr = slowptr.next;
                        fastptr = fastptr.next;
                    }
                }
                return slowptr;
            }

            void push(int data)
            {
                NodeL new_node = new NodeL(data);
                new_node.next = head;
                head = new_node;
            }
            void PrintList(NodeL headRef)
            {
                while (headRef!=null)
                {
                    Console.WriteLine(headRef.val+"");
                    headRef = headRef.next;
                }
            }
        }


    }
}

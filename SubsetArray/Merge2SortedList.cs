using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class Merge2SortedList
    {

        public class Node
        {
            public int data;
            public Node next;
        };

        // Function to create newNode in a linkedlist 
       public static Node newNode(int key)
        {
            Node temp = new Node();
            temp.data = key;
            temp.next = null;
            return temp;
        }

        // A utility function to print linked list 
       public static void printList(Node node)
        {
            while (node != null)
            {
                Console.Write("{0} ", node.data);
                node = node.next;
            }
        }

        // Merges two given lists in-place. This function 
        // mainly compares head nodes and calls mergeUtil() 
       public static Node merge(Node h1, Node h2)
        {
            if (h1 == null)
                return h2;
            if (h2 == null)
                return h1;

            // start with the linked list 
            // whose head data is the least 
            if (h1.data < h2.data)
            {
                h1.next = merge(h1.next, h2);
                return h1;
            }
            else
            {
                h2.next = merge(h1, h2.next);
                return h2;
            }
        }

    }

    public class Merge2SortedList_ExtraSpace
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }
        public Node head;
        //add to last 
        //print list
        public void addToTheLast(Node node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        public void PrintlIST()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
            Console.WriteLine();
        }

        //we are not told tat list contains negative numbers or not 
        
        public Node sortedMerge(Merge2SortedList_ExtraSpace.Node h1, Merge2SortedList_ExtraSpace.Node h2)
        {
            //add dummy node 
            Node dummy = new Node(0);
            //pointer pointing to the dummy node
            Node tail = dummy;
            while (true)
            {
                if (h1 == null)
                {
                    tail.next = h2;
                    break;
                }
                if (h2 == null)
                {
                    tail.next = h1;
                    break;
                }

                if (h1.data <= h2.data)
                {
                    tail.next = h1;
                    h1 = h1.next;
                }
                else
                {
                    tail.next = h2;
                    h2 = h2.next;

                }
                tail = tail.next;
            }
            return dummy.next;
        }

        public Node sortedMerge_leetcode(Merge2SortedList_ExtraSpace.Node h1, Merge2SortedList_ExtraSpace.Node h2)
        {
            //add dummy node 
            Node dummy = new Node(0);
            //pointer pointing to the dummy node
            Node tail = dummy;
            while (h1!=null&&h2!=null)
            {
                if (h1.data<h2.data)
                {
                    dummy.next = h1;
                    h1= h1.next;
                }
                else
                {
                    dummy.next = h2;
                    h2 = h2.next;
                }
                dummy = dummy.next;

            }
            if (h1!=null)
            {
                dummy.next = h1;
            }
            else
            {
                dummy.next = h2;
            }
            //because head is saving the reference 
            return head.next;
        }
    }

}
//o(n+m), where n is the size of 1 list and m is the size of the other list 
//space compl:o(1)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class SortArray_0_1_2
    {
       
        public class LinkedList
        {
            Node head;
            class Node
            {
                public int data;
                public Node next;
                public Node(int d)
                {
                    data = d; next = null;
                }
            }
          
            public void SortList()
            {
                int[] count = { 0, 0, 0 };
                Node ptr = head;
                while (ptr != null)
                {
                    count[ptr.data]++;
                    ptr = ptr.next;
                }

                int i = 0;
                while (ptr!=null)
                {
                    if (count[i] == 0)
                        i++;
                    else
                    {
                        ptr.data = i;
                        --count[i];
                        ptr = ptr.next;
                    }
                }
            }

            public void push(int new_data)
            {
                Node new_node = new Node(new_data);
                new_node.next = head;
                head = new_node;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class LinkedList
    {
       public Node head;
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

       public bool IsPresent(Node head, int data)
        {
            Node t = head;
            while (t!=null)
            {
                if (t.data==data)
                {
                    return true;

                }
                t = t.next;
            }
            return false;
        }

       public void GetUnion(Node head1, Node head2)
        {
            Node t1 = head1;
            Node t2 = head2;
            while (t1 != null)
            {
                Push(t1.data);
                t1 = t1.next;
            }
            while (t2!=null)
            {
                if (!IsPresent(head,t2.data))
                {
                    Push(t2.data);
                }
                t2 = t2.next;
            }
        }

       public void GetIntersect(Node head1, Node head2)
        {
           // Node result = null;
            Node t1 = head1;
            while (t1!=null)
            {
                if (IsPresent(head2,t1.data))
                {
                    Push(t1.data);
                }
                t1 = t1.next;
            }
        }
       public void Push(int new_data)
        {
            Node new_node = new Node(new_data);
            new_node.next = head;
            head = new_node;
         
        }

        public void PrintList()
        {
            Node temp = head;
            while (temp!=null)
            {
                Console.WriteLine(temp.data+"");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
    class UnionIntersectionLL
    {
    }
}

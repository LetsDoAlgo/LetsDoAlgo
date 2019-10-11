using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class KSmallestBST
    {
        //reverse Iorder travsrsal - to speed up the process 

        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int d)
            {
                data = d;
                left = right = null;
            }
        }


        public class BST
        {
            public Node root;
            public BST()
            {
                root = null;                     
            }

            public void insert(int data)
            {
                root = InsertRec(root, data);
            }

            public Node InsertRec(Node node , int data)
            {
                //1. if tree is empty , return new node 
                if (node==null)
                {
                    this.root = new Node(data);
                    return root;

                }
                if (data<node.data)
                {
                    node.left = InsertRec(node.left, data);
                }
                else
                {
                    node.right = InsertRec(node.right, data);
                }
                return node;
            }

            public class Count
            {
                private readonly BST inst;
                public Count(BST _inst)
                {
                    inst = _inst;
                }
                public int c = 0;

            }

            public void SecondLargestUtil(Node node, Count c)
            {
                if (node == null || c.c >= 2)
                {
                    return;
                }

                //follow reverse inorde traversal 
                SecondLargestUtil(node.right, c);
                c.c++;
                if (c.c == 2)
                {
                    Console.WriteLine(node.data);
                    return;
                }
                SecondLargestUtil(node.left, c);
            }

            public void secondLargest(Node node)
            {
                Count c = new Count(this);
                this.SecondLargestUtil(node, c);
            }
        }

     
    }

}

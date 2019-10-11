using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class Tree_Symmetric
    {

  
public class BinaryTree
    {
        public Node root;
        public class Node
        {
            public int val;
            public Node left, right;
            public Node(int v)
            {
                val = v;
                left = null;
                right = null;
            }
        }

        /* constructor to initialise the root */
        BinaryTree(Node r) { root = r; }

        /* empty constructor */
        BinaryTree() { }


        /* function to check if the tree is Symmetric */
        public bool isSymmetric(Node root)
        {
            /* This allows adding null elements to the queue */
            Queue<Node> q = new Queue<Node>();

            /* Initially, add left and right nodes of root */
            q.Enqueue(root.left);
            q.Enqueue(root.right);

            while (q.Count != 0)
            {
                /* remove the front 2 nodes to 
                check for equality */
                Node tempLeft = q.Dequeue();
                Node tempRight = q.Dequeue();

                /* if both are null, continue and chcek 
                for further elements */
                if (tempLeft == null && tempRight == null)
                    continue;

                /* if only one is null---inequality, retun false */
                if ((tempLeft == null && tempRight != null) ||
                    (tempLeft != null && tempRight == null))
                    return false;

                /* if both left and right nodes exist, but 
                have different values-- inequality, 
                return false*/
                if (tempLeft.val != tempRight.val)
                    return false;

                /* Note the order of insertion of elements 
                to the queue : 
                1) left child of left subtree 
                2) right child of right subtree 
                3) right child of left subtree 
                4) left child of right subtree */
                q.Enqueue(tempLeft.left);
                q.Enqueue(tempRight.right);
                q.Enqueue(tempLeft.right);
                q.Enqueue(tempRight.left);
            }

            /* if the flow reaches here, return true*/
            return true;
        }

        /* driver code */
        //public static void Main(String[] args)
        //{
        //    Node n = new Node(1);
        //    BinaryTree bt = new BinaryTree(n);
        //    bt.root.left = new Node(2);
        //    bt.root.right = new Node(2);
        //    bt.root.left.left = new Node(3);
        //    bt.root.left.right = new Node(4);
        //    bt.root.right.left = new Node(4);
        //    bt.root.right.right = new Node(3);

        //    if (bt.isSymmetric(bt.root))
        //        Console.WriteLine("The given tree is Symmetric");
        //    else
        //        Console.WriteLine("The given tree is not Symmetric");
        //}
    }

    // This code is contributed by PrinciRaj1992 
}
}

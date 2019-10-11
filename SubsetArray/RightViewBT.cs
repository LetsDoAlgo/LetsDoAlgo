using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //f we observe carefully, we will see that our main task is to print the right most node of every level. So, we will do a level order traversal on the tree and print the rightmost node at every level.

//Below is the implementation of above approach:
   public class RightViewBT
    {
        public class Node
        {
            public int data { get; set; }
            public Node left, right;
            public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
                
            }
        }

        private static void printRightView(Node root)
        {
            //maintain queue 
            //
            //base check
            if (root==null)
            {
                return;

            }
            Queue<Node> q1 = new Queue<Node>();
            q1.Enqueue(root);
            while (q1.Count!=0)
            {
                int n = q1.Count;

                //har level pe add honge 
                //in that level , print the rightmost child
                //ex : in case of root node  , the loop will go only once . 
                //0th time .

                for (int i = 0; i < n; i++)
                {
                    Node temp = q1.Dequeue();
                    //to check if this is the last element in the loop , then print it .
                    if (i==n-1)
                    {
                        Console.WriteLine(temp.data+"");
                    }

                    if (temp.left != null)
                    {
                        q1.Enqueue(temp.left);
                    }
                    if (temp.right!=null)
                    {
                        q1.Enqueue(temp.right);
                    }

                }
            }

        }
    }
    //
    //Time Complexity: O( n ), where n is the number of nodes in the binary tree.
}

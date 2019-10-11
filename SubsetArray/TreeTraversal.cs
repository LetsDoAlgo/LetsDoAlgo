using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class TreeTraversal
    {
        //Time Complexity: O(n)
//        Let us see different corner cases.
//        Complexity function T(n) — for all problem where tree traversal is involved — can be defined as:

//T(n) = T(k) + T(n – k – 1) + c

//Where k is the number of nodes on one side of root and n-k-1 on the other side.

//Let’s do an analysis of boundary conditions

//Case 1: Skewed tree (One of the subtrees is empty and other subtree is non-empty )

//k is 0 in this case.
//T(n) = T(0) + T(n-1) + c
//T(n) = 2T(0) + T(n-2) + 2c
//T(n) = 3T(0) + T(n-3) + 3c
//T(n) = 4T(0) + T(n-4) + 4c

//…………………………………………
//………………………………………….
//T(n) = (n-1)T(0) + T(1) + (n-1)c
//T(n) = nT(0) + (n)c

//Value of T(0) will be some constant say d. (traversing a empty tree will take some constants time)

//T(n) = n(c+d)
//T(n) = Θ(n) (Theta of n)

//Case 2: Both left and right subtrees have equal number of nodes.

//T(n) = 2T(|_n/2_|) + c

//This recursive function is in the standard form(T(n) = aT(n/b) + (-)(n) ) for master method
        //multiple ways : pre, post, in --> DFS 
        //Level order traversal ---> BFS
        public class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int d)
            {
                data = d;
                left = right = null;

            }
        }

        //TC :O(n)
        //Space :O(n)  --> Space is proportional to the root 
        //using 2 stacks 
        public void PostOrder_It(TreeNode root)
        {
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2_out = new Stack<TreeNode>();

            s1.Push(root);
            while (s1.Count!=0)
            {
                var curr = s1.Pop();
                s2_out.Push(curr);

                if (curr.left!=null)
                {
                    s1.Push(curr.left);
                }
                if (curr.right != null)
                {
                    s1.Push(curr.right);
                }
            }

            while (s2_out.Count!=0)
            {
                //print 
                Console.WriteLine(s2_out.Pop().data);
            }
        }


        /// <summary>
        /// TO DO 
        /// </summary>
        List<int> l1 = new List<int>();
        public List<int> PostPrder_It_1Stack(TreeNode root)
        {
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            if (s1 == null)
            {
                return l1;
            }
            s1.Push(root);

            TreeNode prev = null;
            while (s1.Count>0)
            {
                TreeNode current = s1.Peek();
                if (prev==null||( prev.left==current && prev.right==current))
                {
                    if (current.left != null)
                    {
                        s1.Push(current.left);
                    }
                    else if (current.right != null)
                    {
                        s1.Push(current.right);
                    }
                    else
                    {
                        s1.Pop();
                        l1.Add(current.data);
                    }
                }
                else if(current.left==prev)
                {
                    if (current.right!=null)
                    {
                        s1.Push(current.right);
                    }
                    else
                    {
                        s1.Pop();
                        l1.Add(current.data);
                    }
                }
                else if(current.right==prev)
                {
                    s1.Pop();
                    l1.Add(current.data);

                }
                prev = current;
            }
            return l1;
        }
        
        public void PostOrder_Rec(TreeNode root)
        {
            if (root !=null)
            {
                PostOrder_Rec(root.left);
                PostOrder_Rec(root.right);
                Console.WriteLine(root.data);
            }
        }

        //using 1 stack 
        //Time Complexity : O(n) If we take a closer look, we can notice that every edge of the tree is traversed at most two times. And in the worst case, the same number of extra edges (as input tree) are created and removed.
        public void InOrder_It(TreeNode root)
        {
            if (root==null)
            {
                return;
            }
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            TreeNode curr = root;
            while (curr!=null||s1.Count>0)
            {
                s1.Push(curr);
                curr = curr.left;
            }

            curr = s1.Pop();
            Console.WriteLine( curr.data);
            curr = curr.right;
        }
      
        
        public void InOrder_it_NoStack(TreeNode root)
        {
            TreeNode current, pre;
            if (root == null)
            {
                return;
            }
            current = root;
            while (current!=null)
            {
                if (current.left==null)
                {
                    Console.WriteLine(current.data+" ");
                    current = current.right;
                }
                else
                {
                    pre = current.left;
                    while (pre.right!=null&&pre.right!=current)
                    {
                        pre.right = current;
                        current = current.left;
                    }

                    if (pre.right == null)
                    {
                        pre.right = current;
                        current = current.left;
                    }
                    else
                    {
                        pre.right = null;
                        Console.WriteLine(current.data+" ");
                        current = current.right;
                    }
                }
            }
        }
          
        //root , lt , right 
        public void PreOrder_It(TreeNode root)
        {
            if (root==null)
            {
                return;
            }
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            s1.Push(root);

            while (s1.Count>0)
            {
                TreeNode curr = s1.Pop();
                Console.WriteLine(curr.data);
                if (curr.right!=null)
                {
                    s1.Push(curr.right);
                }
                if (curr.left != null)
                {
                    s1.Push(curr.left);
                }
            }
        }



        public void LevelOrderTraversal(TreeNode root)
        {

            //Time Complexity: O(n) where n is number of nodes in the binary tree


            Queue<TreeNode> q1 = new Queue<TreeNode>();
            q1.Enqueue(root);
            while (q1.Count!=0)
            {
                TreeNode temp = q1.Dequeue();
                Console.WriteLine(temp.data);
                if (temp.left!=null)
                {
                    q1.Enqueue(temp.left);
                }

                if (temp.right != null)
                {
                    q1.Enqueue(temp.right);
                }
            }
        }
    }

  
}

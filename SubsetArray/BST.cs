using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class BST
    {
        public class Node
        {
            public int data;
            public Node left, right;
            public Node(int data)
            {
                this.data = data;
                this.left = this.right = null;
            }
        }

      public static int SizeBST(Node root)
        {
            if (root==null)
            {
                return 0;
            }
            return (SizeBST(root.left) + SizeBST(root.right) + 1);
        }

        public static bool IsBST(Node node , int min , int max)
        {
            if (node==null)
            {
                return true;
            }
            if (node.data<min||node.data>max)
            {
                return false;
            }
            return IsBST(node.left, min, node.data)
                && IsBST(node.right, node.data, max);
        }
        public static int FindLargestBST(Node root)
        {
            if (IsBST(root,int.MinValue,int.MaxValue))
            {
                return SizeBST(root);
            }
            return Math.Max(FindLargestBST(root.left),FindLargestBST(root.right));
        }
    }
}
//tc: o(n^2)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{

   public class SortedArrayToBST
    {
        public class Node
        {

            public int data;
            public Node left, right;

            public Node(int d)
            {
                data = d;
                left = right = null;
            }
        }
        // Constructing from sorted array in O(n) time is simpler as we can get the middle element in O(1) time.
  //      //Time Complexity: O(n)
  //      Following is the recurrance relation for sortedArrayToBST().

  //T(n) = 2T(n/2) + C
  //T(n) -->  Time taken for an array of size n
  // C   -->  Constant(Finding middle of array and linking root to left
  //                    and right subtrees take constant time)
        public class BinaryTree
        {

            public static Node root;

            /* A function that constructs Balanced Binary Search Tree   
             from a sorted array */
            public virtual Node sortedArrayToBST(int[] arr, int start, int end)
            {

                /* Base Case */
                if (start > end)
                {
                    return null;
                }

                /* Get the middle element and make it root */
                int mid = (start + end) / 2;
                Node node = new Node(arr[mid]);

                /* Recursively construct the left subtree and make it  
                 left child of root */
                node.left = sortedArrayToBST(arr, start, mid - 1);

                /* Recursively construct the right subtree and make it  
                 right child of root */
                node.right = sortedArrayToBST(arr, mid + 1, end);

                return node;
            }

            /* A utility function to print preorder traversal of BST */
            public virtual void preOrder(Node node)
            {
                if (node == null)
                {
                    return;
                }
                Console.Write(node.data + " ");
                preOrder(node.left);
                preOrder(node.right);
            }

            //public static void Main(string[] args)
            //{
            //    BinaryTree tree = new BinaryTree();
            //    int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //    int n = arr.Length;
            //    root = tree.sortedArrayToBST(arr, 0, n - 1);
            //    Console.WriteLine("Preorder traversal of constructed BST");
            //    tree.preOrder(root);
            //}
        }
    }
}

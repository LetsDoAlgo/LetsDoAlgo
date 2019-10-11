using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class LengthRootToLeaf
    {
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

        public class PrintRootToLeafPath
        {
           public Node root;
            public void printPath(Node root)
            {
                int[] paths = new int[1000];
                printPathRec(root,paths,0);
            }

            private void printPathRec(Node root, int[] paths, int index)
            {
                if (root==null)
                {
                    return;
                }
                paths[index] = root.data;
                index++;
                if (root.left==null&&root.right==null)
                {
                    printArray(paths, index);
                }
                else
                {
                    printPathRec(root.left, paths, index);
                    printPathRec(root.right, paths, index);
                }

            }

            public virtual void printArray(int[] ints, int len)
            {
                int i;
                for (i = 0; i < len; i++)
                {
                    Console.Write(ints[i] + " ");
                }
                Console.WriteLine("");
            }
        }

        public static int maxSum;
        public static int maxLen;


        public class PrinMaxSUMtRootToLeafPath
        {
            public Node root;
            public void sumOfLongRootToLeafPath(Node root , int sum , int len )
            {
                if (root==null)
                {
                    if (maxLen<len)
                    {
                        maxLen = len;
                        maxSum = sum;
                    }
                    else if(maxLen==len&& maxSum<sum)
                    {
                        maxSum = sum;
                    }

                    return;
                }
                sumOfLongRootToLeafPath(root.left, sum + root.data, len + 1);
                sumOfLongRootToLeafPath(root.right, sum + root.data, len + 1);
            }

            // utility function to find the sum of nodes on  
            // the longest path from root to leaf node  
            public int sumOfLongRootToLeafPathUtil(Node root)
            {
                // if tree is NULL, then sum is 0  
                if (root == null)
                {
                    return 0;
                }

                maxSum = int.MinValue;
                maxLen = 0;

                // finding the maximum sum 'maxSum' for the  
                // maximum length root to leaf path  
                sumOfLongRootToLeafPath(root, 0, 0);

                // required maximum sum  
                return maxSum;
            }

        }
    }
}

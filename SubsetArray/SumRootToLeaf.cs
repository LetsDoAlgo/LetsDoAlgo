using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
  public class SumRootToLeaf
    {
        public class Node
        {
            public int data;
            public Node left;

            public Node right;
            public Node(int item)
            {
                data = item;
                left = right = null;

            }
        }

        public class SumBST
        {
            public  Node root;
           public int treePathsSumUtil(Node node ,int val)
            {
                // Base case  
                if (node == null)
                {
                    return 0;
                }

                // Update val  
                val = (val * 10 + node.data);

                // if current node is leaf, return  
                // the current value of val  
                if (node.left == null && node.right == null)
                {
                    Console.WriteLine(val);
                    return val;
                }

                // recur sum of values for left and right subtree  
                return treePathsSumUtil(node.left, val) +
                       treePathsSumUtil(node.right, val);
            }
            // A wrapper function over treePathsSumUtil()  
            public int treePathsSum(Node node)
            {
                // Pass the initial value as 0 as  
                // there is nothing above root  
                return treePathsSumUtil(node, 0);
            }

        }

        //        / Function to store counts of different root to leaf
        //// path lengths in hash map m. 
        //void pathCountUtil(Node* node, unordered_map<int, int> &m,
        //                                             int path_len)
        //        {
        //            // Base condition 
        //            if (node == NULL)
        //                return;

        //            // If leaf node reached, increment count of path 
        //            // length of this root to leaf path. 
        //            if (node->left == NULL && node->right == NULL)
        //            {
        //                m[path_len]++;
        //                return;
        //            }

        //            // Recursively call for left and right subtrees with 
        //            // path lengths more than 1. 
        //            pathCountUtil(node->left, m, path_len + 1);
        //            pathCountUtil(node->right, m, path_len + 1);
        //        }

        //        // A wrapper over pathCountUtil() 
        //        void pathCounts(Node* root)
        //        {
        //            // create an empty hash table 
        //            unordered_map<int, int> m;

        //            // Recursively check in left and right subtrees. 
        //            pathCountUtil(root, m, 1);

        //            // Print all path lenghts and their counts. 
        //            for (auto itr = m.begin(); itr != m.end(); itr++)
        //                cout << itr->second << " paths have length "
        //                     << itr->first << endl;
        //        }

// C++ program to find Sum Of All Elements larger 
// than or equal to Kth Largest Element In BST 

    // utility function new Node of BST 
       // A utility function to insert a new Node 
    // with given key in BST  
  
    //// function to return sum of all elements larger than 
    //// and equal to Kth largest element 
    //int klargestElementSumUtil(Node* root, int k, int& c)
    //{
    //    // Base cases 
    //    if (root == NULL)
    //        return 0;
    //    if (c > k)
    //        return 0;

    //    // Compute sum of elements in right subtree 
    //    int ans = klargestElementSumUtil(root->right, k, c);
    //    if (c >= k)
    //        return ans;

    //    // Add root's data 
    //    ans += root->data;

    //    // Add current Node 
    //    c++;
    //    if (c >= k)
    //        return ans;

    //    // If c is less than k, return left subtree Nodes 
    //    return ans + klargestElementSumUtil(root->left, k, c);
    //}

    }
}

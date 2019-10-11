using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class BinaryTreeSun
    {
        List<int> path = new List<int>();
        //get node sum 
        public void PrintKPathUtil(Node root,List<int> path, int k)
        {
            if (root ==null)
            {
                return;
            }

            path.Add(root.data);

            PrintKPathUtil(root.left, path,k);
            PrintKPathUtil(root.right,path, k);

            int f = 0;
            for (int j = path.Count-1; j >=0; j--)
            {
                f += path[j];
                if (f==k)
                {
                    for (int i = j; i < path.Count; i++)
                    {
                        Console.WriteLine(path[i]+" ");
                    }
                    Console.WriteLine();
                }
            }
            path.Remove(path.Count - 1);
        }

        public void PrintKPath(Node root , int k )
        {
            path = new List<int>();
            PrintKPathUtil(root,path, k);
        }
    }

    public class Node
    {
        public int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }

    }

    class Res
    {
        public int val;
    }

    public class BinaryTree
    {
       public Node root;//root of binary tree 
        int findMaxUtil(Node node , Res res)
        {
            //base case
            if (node==null)
            {
                return 0;
            }

            int l = findMaxUtil(node.left, res);
            int r = findMaxUtil(node.right, res);
            int max_single = Math.Max(Math.Max(l, r) + node.data, node.data);
            int max_top = Math.Max(max_single, l + r + node.data);
            res.val = Math.Max(res.val, max_top);
            return max_single;
        }
       
       public int findMaxSum()
        {
            return findMaxSum(root);
        }

        int findMaxSum(Node node)
        {
            Res res = new Res();
            res.val = int.MinValue;
            findMaxUtil(node, res);
            return res.val;
        }
    }

}

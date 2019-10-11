using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //root as null check 
    //count check 

    //// https://www.geeksforgeeks.org/check-if-all-levels-of-two-trees-are-anagrams-or-not/
   public class AnagramsBT
    {
        public class Node
        {
            public Node left, right;
            public int data;
            public Node(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }
        public bool Anagrams(Node root1 , Node root2)
        {
            if (root1==null&&root2==null)
            {
                return true;
            }
            if (root1==null||root2==null)
            {
                return false;
            }
            Queue<Node> q1 = new Queue<Node>();
            Queue<Node> q2 = new Queue<Node>();

            q1.Enqueue(root1);
            q2.Enqueue(root2);
            while (true)
            {
                int n1 = q1.Count;
                int n2 = q2.Count;
                if (n1!=n2)
                {
                    return false;
                }
                if (n1==0)
                {
                    break;
                }
                // Enqueue all Nodes of next level  
                List<int> curr_level1 = new List<int>();
                List<int> curr_level2 = new List<int>();
                while (n1 > 0)
                {
                    Node node1 = q1.Peek();
                    q1.Dequeue();
                    if (node1.left != null)
                        q1.Enqueue(node1.left);
                    if (node1.right != null)
                        q1.Enqueue(node1.right);
                    n1--;

                    Node node2 = q2.Peek();
                    q2.Dequeue();
                    if (node2.left != null)
                        q2.Enqueue(node2.left);
                    if (node2.right != null)
                        q2.Enqueue(node2.right);

                    curr_level1.Add(node1.data);
                    curr_level2.Add(node2.data);
                }

                // Check if nodes of current levels are  
                // anagrams or not.  
                curr_level1.Sort();
                curr_level2.Sort();

                for (int i = 0;
                        i < curr_level1.Count; i++)
                    if (curr_level1[i] != curr_level2[i])
                        return false;
            }
            return true;
        }
    }
}

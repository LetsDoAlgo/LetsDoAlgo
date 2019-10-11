using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class Trie_Dictionary
    {
        public class Node
        {
           public int char_size = 26;
           public bool exist; //true when node is a leaf node 
           public Node[] next;
            public Node()
            {
                next = new Node[char_size];
                exist = false;
            }
        }
        public class Util
                {
                    public void InsertTrie(Node head, string str)
                    {
                        Node node1 =head;
                        var strCharArr = str.ToCharArray();

                        for (int i = 0; i < str.Length; i++)
                        {
                            if (node1.next[strCharArr[i]-'a']==null)
                            {
                                node1.next[strCharArr[i] - 'a'] = new Node();
                            }
                             //go to next node 
                             node1 = node1.next[strCharArr[i] - 'a'];
                        }
                        node1.exist = true;
                    }

                    public bool wordBreak(Node head , string str)
                    {
                        bool[] good = new bool[str.Length+1];
                        good[0] = true;
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (good[i])
                            {
                                Node node = head;
                                for (int j = i; j < str.Length; j++)
                                {
                                    if (node==null)
                                    {
                                         break;
                                    }
                                    node = node.next[str.ToCharArray()[j] - 'a'];

                                    if (node!=null&&node.exist)
                                    {
                                        good[j + 1] = true;
                                    }
                                }
                            }
                        }
                return good[str.Length];
                    }
                }
      
    }
}

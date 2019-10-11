using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    public class LexicographicOrder
    {


        public class Trie
        {

            public Node rootNode;

            /* to make new trie*/
            public Trie()
            {
                rootNode = null;
            }

            // function to insert  
            // a string in trie 
            public void insert(String key, int index)
            {
                // making a new path 
                // if not already 
                if (rootNode == null)
                {
                    rootNode = new Node();
                }

                Node currentNode = rootNode;

                for (int i = 0; i < key.Length; i++)
                {
                    char keyChar = key[i];

                    if (currentNode.getChild(keyChar) == null)
                    {
                        currentNode.addChild(keyChar);
                    }

                    // go to next node 
                    currentNode = currentNode.getChild(keyChar);
                }

                // Mark leaf (end of string) 
                // and store index of 'str'  
                // in index[] 
                currentNode.addIndex(index);
            }

            public void traversePreorder(String[] array)
            {
                traversePreorder(rootNode, array);
            }

            // function for preorder 
            // traversal of trie 
            public void traversePreorder(Node node,
                                    String[] array)
            {
                if (node == null)
                {
                    return;
                }

                if (node.getIndices().Count > 0)
                {
                    foreach (int index in node.getIndices())
                    {
                        Console.Write(array[index] + " ");
                    }
                }

                for (char index = 'a'; index <= 'z'; index++)
                {
                    traversePreorder(node.getChild(index), array);
                }
            }

            public class Node
            {

                public Node[] children;
                public List<int> indices;

                public Node()
                {
                    children = new Node[26];
                    indices = new List<int>(0);
                }

                public Node getChild(char index)
                {
                    if (index < 'a' || index > 'z')
                    {
                        return null;
                    }

                    return children[index - 'a'];
                }

                public void addChild(char index)
                {
                    if (index < 'a' || index > 'z')
                    {
                        return;
                    }

                    Node node = new Node();
                    children[index - 'a'] = node;
                }

                public List<int> getIndices()
                {
                    return indices;
                }

                public void addIndex(int index)
                {
                    indices.Add(index);
                }
            }
        }

        //public class SortStrings
        //{

        //    // Driver code  
        //    public static void Main(String[] args)
        //    {
        //        String[] array = { "abc", "xyz",
        //            "abcd", "bcd", "abc" };
        //        printInSortedOrder(array);
        //    }

        //    // function to sort an array 
        //    // of strings using Trie 
        //    static void printInSortedOrder(String[] array)
        //    {
        //        Trie trie = new Trie();

        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            trie.insert(array[i], i);
        //        }

        //        trie.traversePreorder(array);
     
        //}
    }
}

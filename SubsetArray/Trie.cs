using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class Trie
    {

        public class Node
        {
            public char Value { get; set; }
            public List<Node> Children { get; set; }

            public Node Parent { get; set; }

           public int Depth { get; set; }

            public Node(char value , int depth , Node parent)
            {
                Value = value;
                Children = new List<Node>();
                Depth = depth;
                Parent = parent;
            }
            public bool isleaf()
            {
                return Children.Count == 0;
            }
            public Node FindChildNode(char c)
            {
                foreach (var item in Children)
                {
                    if (item.Value==c)
                    {
                        return item;
                    }
                }
                return null;
            }

            public void DeleteChildNode(char c)
            {
                for (var i = 0; i < Children.Count; i++)
                    if (Children[i].Value == c)
                        Children.RemoveAt(i);
            }
        }

        public class TrieImplement
        {
            private readonly Node _root;
            public TrieImplement()
            {
                _root = new Node('^', 0, null);
            }
            public Node Prefix(string s)
            {
                var currentNode = _root;
                var result = currentNode;
                foreach (var item in s)
                {
                    currentNode = currentNode.FindChildNode(item);
                    if (currentNode ==null)
                    {
                        break;

                    }
                    result = currentNode;
                }
                return result;
            }

            public bool Search(string s)
            {
                var prefix = Prefix(s);
                return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
            }

            public void InsertRange(List<String> items)
            {
               
                for (int i = 0; i < items.Count; i++)
                {
                    var s = items[i];
                    var commonPrefix = Prefix(s);
                    var current = commonPrefix;
                    for (int j = current.Depth; j < s.Length; j++)
                    {
                        var newnode = new Node(s[i], current.Depth + 1, current);
                        current.Children.Add(newnode);
                        current = newnode;
                    }

                    current.Children.Add(new Node('$', current.Depth + 1, current));
                }
            }

            public void Delete(string s)
            {
                if (Search(s))
                {
                    var node = Prefix(s).FindChildNode('$');
                    while (node.isleaf())
                    {
                        var parent = node.Parent;
                        parent.DeleteChildNode(node.Value);
                        node = parent;
                    }
                }
            }
        }

    }
}

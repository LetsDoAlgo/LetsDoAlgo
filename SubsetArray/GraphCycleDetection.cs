using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //strongly components in a graph will have 1 cycle 
    //work on scc
    //stack, blocked set , blocked map --- data structures
    //mark start vertex as 1 : least numbered vertext in scc
    //see cycles start and end at 1 
    //go to stack ....explore neighbours of 1 
    //put 1 in stack ,,,,explorennbd of 1 ...
    //see nbd of 3 ..put ....see nbd of 3 ....it is 2..
    //but 2 is part of blocked set ..
    //anything other than 1 cannot be repeated 
    //explore nbd of 5 
    //nbd is 2 but it is there in blockset ..
    //vertex 2 cannot be repeated in the same cycle
    //recurse from 5 ..so remove from stackbut not from the blocked set 
    //look for nbd of 5 ...
    //add 4 to the blocked map 
    //unblock 4 ...
    //add 6  to both 
    //4!=6
    //if not able tofind the ertex ..we need to unblock it 
    //which is joining the current vertex 

  public class GraphCycleDetection
    {
       // undirected graph
        class Graph
        {

            protected Dictionary<int, HashSet<int>> adjlist;
            public Graph()
            {
                adjlist = new Dictionary<int, HashSet<int>>();

            }
            public void addEdge(int node1, int node2)
            {
                if (!adjlist.ContainsKey(node1))
                {
                    adjlist.Add(node1, new HashSet<int>());
                }
                if (!adjlist.ContainsKey(node2))
                {
                    adjlist.Add(node2, new HashSet<int>());
                }
                adjlist[node1].Add(node2);
                adjlist[node2].Add(node1);
            }

            public bool isCyclic()
            {
                if (adjlist.Count == 0)
                {
                    return false;
                }
                Dictionary<int, bool> visitedDict = new Dictionary<int, bool>();
                foreach (int key in adjlist.Keys)
                {
                    visitedDict.Add(key, false);
                }

                foreach (var item in visitedDict.Keys.ToList())
                {
                    //check whether value of its visited state is true / false 
                    if (!visitedDict[item])
                    {
                        if (cycleHelper(item, visitedDict))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            private bool cycleHelper(int item, Dictionary<int, bool> visitedDict)
            {
                visitedDict[item] = true;
                foreach (var node in adjlist[item])
                {
                    if (!visitedDict[node])
                    {
                        if (cycleHelper(node, visitedDict, item))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            private bool cycleHelper(int current, Dictionary<int, bool> visitedDict, int parent)
            {
                visitedDict[current] = true;
                foreach (var item in adjlist[current])
                {
                    if (!visitedDict[item])
                    {
                        if (cycleHelper(item, visitedDict, current))
                        {
                            return true;
                        }

                    }
                    else if (item != parent)
                        return true;
                }
                return false;
            }

            //finding all the connected components 
            void connectedComponents()
            {
                int v = 5;
                bool[] visited = new bool[v];
            }
        }

        //public class Graph
        // {
        //     private int v;
        //     public LinkedList<int>[] adj;
        //     public Graph(int v)
        //     {
        //         this.v = v;
        //         adj = new LinkedList<int>[v];
        //         for (int i = 0; i < v; ++i)
        //             adj[i] = new LinkedList<int>();
        //     }

        //     internal void addEdge(int v, int w)
        //     {
        //         adj[v].AddFirst(w);
        //     }

        //     internal bool isCyclic()
        //     {
        //         bool[] visited = new bool[v];
        //         bool[] recStack = new bool[v];
        //         for (int i = 0; i < v; i++)
        //             if (isCyclicUtil(i, visited, recStack))
        //                 return true;

        //         return false;
        //     }

        //     private bool isCyclicUtil(int ver, bool[] visited, bool[] recStack)
        //     {
        //         visited[ver] = true;
        //         recStack[ver] = true;

        //         LinkedList<int> lnk = adj[ver];

        //         foreach (var item in lnk)
        //         {
        //             if (visited[item] == false && isCyclicUtil(item, visited, recStack))
        //                 return true;
        //             else if (recStack[item])
        //                 return true;
        //         }

        //         recStack[ver] = false;
        //         return false;
        //     }
        // }
    }
}

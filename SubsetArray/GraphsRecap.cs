using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class GraphsRecap
    {

        public class Graph
        {
            protected Dictionary<int, HashSet<int>> adjlist;

            public Graph()
            {
                adjlist = new Dictionary<int, HashSet<int>>();
            }

            public void addEdge(int node1 , int node2)
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

            private void dfsHelper(int current , Dictionary<int,bool> visisted)
            {
                visisted[current] = true;
                Console.WriteLine(current);
                foreach (var item in adjlist[current])
                {
                    if (visisted[item]==false)
                    {
                        dfsHelper(item, visisted);
                    }
                }
            }

           
            private void DFS(int startNode)
            {
                Dictionary<int, bool> visitDict = new Dictionary<int, bool>();
                foreach (int key in adjlist.Keys)
                {
                    visitDict.Add(key, false);
                }
                dfsHelper(startNode, visitDict);
            }


            /////////////////////////////////////////////////////////////////

            public void BFS(int startNode)
            {

                Dictionary<int, bool> visitDict = new Dictionary<int, bool>();
                foreach (var item in adjlist.Keys)
                {
                    visitDict.Add(item, false);
                }

                Queue<int> nextnodes = new Queue<int>();
                bfshelper(startNode,visitDict,nextnodes);
            }

            private void bfshelper(int current, Dictionary<int, bool> visitDict, Queue<int> nextnodes)
            {
                if (visitDict[current])
                {
                    return;
                }
                visitDict[current] = true;
                Console.WriteLine(current);
                foreach (var node in adjlist[current])
                {
                    if (visitDict[node]==false)
                    {
                        nextnodes.Enqueue(node);
                    }
                }

                if (nextnodes.Count!=0)
                {
                    bfshelper(nextnodes.Dequeue(), visitDict, nextnodes);
                }
            }

            ////////////////////////////////////////////////////////////

            //cycle detection in undrected graph 
            public bool Iscyclic()
            {
                if (adjlist.Count==0)
                {
                    return false;
                }
                Dictionary<int, bool> visitDict = new Dictionary<int, bool>();
                foreach (var item in adjlist.Keys)
                {
                    visitDict.Add(item, false);
                }

                List<int> keylistCopy = new List<int>(visitDict.Keys);

                foreach (int item in keylistCopy)
                {
                    if (!visitDict[item])
                    {
                        if(cyclicHelper(item,visitDict))
                            return true;
                    }
                }

                return false;
            }
            private bool cyclicHelper(int current, Dictionary<int, bool> visited)
            {
                visited[current] = true;

                foreach (int node in adjlist[current])
                {
                    if (!visited[node])
                        if (cyclicHelper(node, visited, current))
                            return true;
                }

                return false;
            }

            private bool cyclicHelper(int current, Dictionary<int, bool> visited, int parent)
            {
                visited[current] = true;

                foreach (int node in adjlist[current])
                {
                    if (!visited[node])
                    {
                        if (cyclicHelper(node, visited, current))
                            return true;
                    }
                    else if (node != parent)
                        return true;
                }

                return false;
            }

            ////////////////////////////////////////////////////////////////
            //cycle detection in directed graph
            ///// <summary>
            ///// Adds an edge from node1 to node2 in the graph
            ///// </summary>
            ///// <param name="node1"></param>
            ///// <param name="node2"></param>
            //public void addEdge(int node1, int node2)
            //{
            //    if (!adjList.ContainsKey(node1))
            //        adjList.Add(node1, new HashSet<int>());

            //    adjList[node1].Add(node2);
            //}
            public bool isCyclicDirected()
            {
                if (adjlist.Count==0)
                {
                    return false;
                }

                Dictionary<int, bool> visitedDict = new Dictionary<int, bool>();
                Dictionary<int, bool> recurDict = new Dictionary<int, bool>();

                foreach (var item in adjlist.Keys)
                {
                    visitedDict.Add(item, false);
                    recurDict.Add(item, false);
                }

                List<int> keyListCopy = new List<int>(adjlist.Keys);
                foreach (int key in keyListCopy)
                {
                    if (!visitedDict[key])
                        if (cyclicHelper(key, visitedDict, recurDict))
                            return true;

                }
                return false;
            }

            private bool cyclicHelper(int current, Dictionary<int, bool> visitedDict, Dictionary<int, bool> recurDict)
            {
                if (!visitedDict.ContainsKey(current))
                {
                    return false;
                }
                if (!visitedDict[current])
                {
                    visitedDict[current] = true;
                    recurDict[current] = true;

                    foreach (var item in adjlist[current])
                    {
                        if (!visitedDict.ContainsKey(item))
                        {
                            continue;
                        }

                        if (!visitedDict[item] &&cyclicHelper(item,visitedDict,recurDict))
                        {
                            return true;
                        }
                        else if(recurDict[item])
                            {
                            return true;
                        }
                    }
                }
                recurDict[current] = false;
                return false;

            }
        }

    }
}

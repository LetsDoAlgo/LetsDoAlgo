using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class DFSPathPrint
    {
        public class Graph
        {
            // A user define class to represent a graph. 
            // A graph is an array of adjacency lists. 
            // Size of array will be V (number of vertices 
            // in graph) 
            int V;
            List<int>[] adjListArray;

            // constructor 
            Graph(int V)
            {
                this.V = V;

                // define the size of array as 
                // number of vertices 
                adjListArray = new List<int>[V];

                // Create a new list for each vertex 
                // such that adjacent nodes can be stored 

                for (int i = 0; i < V; i++)
                {
                    adjListArray[i] = new List<int>();
                }
            }

            // Adds an edge to an undirected graph 
            void addEdge(int src, int dest)
            {
                // Add an edge from src to dest. 
                adjListArray[src].Add(dest);

                // Since graph is undirected, add an edge from dest 
                // to src also 
                adjListArray[dest].Add(src);
            }

            void DFSUtil(int v, bool[] visited)
            {
                // Mark the current node as visited and print it 
                visited[v] = true;
                Console.Write(v + " ");

                // Recur for all the vertices 
                // adjacent to this vertex 
                foreach (int x in adjListArray[v])
                {
                    if (!visited[x]) DFSUtil(x, visited);
                }

            }
            void connectedComponents()
            {
                // Mark all the vertices as not visited 
                bool[] visited = new bool[V];
                for (int v = 0; v < V; ++v)
                {
                    if (!visited[v])
                    {
                        // print all reachable vertices 
                        // from v 
                        DFSUtil(v, visited);
                        Console.WriteLine();
                    }
                }
            }


            // Driver code 
            //public static void Main(String[] args)
            //{
            //    // Create a graph given in the above diagram  
            //    Graph g = new Graph(5); // 5 vertices numbered from 0 to 4  

            //    g.addEdge(1, 0);
            //    g.addEdge(2, 3);
            //    g.addEdge(3, 4);
            //    Console.WriteLine("Following are connected components");
            //    g.connectedComponents();
            //}
        }

    }

    class DFSPathPrint_All
    {
       
        public class Graph
        {
            public class Node
            {
               public int source;
               public int destination;
                public Node(int source, int destination)
                {
                    this.source = source;
                    this.destination = destination;
                }
            }
            // A user define class to represent a graph. 
            // A graph is an array of adjacency lists. 
            // Size of array will be V (number of vertices 
            // in graph) 
            int V;
            LinkedList<Node>[] adjListArray;

            // constructor 
            Graph(int V)
            {
                this.V = V;

                // define the size of array as 
                // number of vertices 
                adjListArray = new LinkedList<Node>[V];

                // Create a new list for each vertex 
                // such that adjacent nodes can be stored 

                for (int i = 0; i < V; i++)
                {
                    adjListArray[i] = new LinkedList<Node>();
                }
            }

            // Adds an edge to an undirected graph 
            void addEdge(int src, int dest)
            {
                Node node = new Node(src, dest);
                //sice graph os directed 
                // Add an edge from src to dest. 
                adjListArray[src].AddLast(node);
               
            }

            public void print(Graph graph , int start , int end , string path , bool[] visited)
            {
                string newPath = path + "->" + start;
                visited[start] = true;
                LinkedList<Node> list = graph.adjListArray[start];
                for (int i = 0; i < list.Count; i++)
                {
                    Node node = (Node)list.ElementAt(i);
                    if (node.destination != end && visited[node.destination] == false)
                    {
                        //                visited[node.destination] = true;
                        print(graph, node.destination, end, newPath, visited);
                    }
                    else if (node.destination == end)
                    {
                        Console.WriteLine(newPath + "->" + node.destination);
                    }
                }
                //remove from path
                visited[start] = false;
            }
       }
  }


            // Driver code 
            //public static void Main(String[] args)
            //{
            //    // Create a graph given in the above diagram  
            //    Graph g = new Graph(5); // 5 vertices numbered from 0 to 4  

            //    g.addEdge(1, 0);
            //    g.addEdge(2, 3);
            //    g.addEdge(3, 4);
            //    Console.WriteLine("Following are connected components");
            //    g.connectedComponents();
            //}
     //   }

    }



    //Time complexity of above solution is O(V + E) as it does simple DFS for given graph.
    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }

    public class Algorithms
    {
        public HashSet<T> DFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }

        //diid myself 
       

        public void ConnectedComponents<T>(Graph<T> graph)
        { int V = graph.AdjacencyList.Keys.Count;
            bool[] visited = new bool[V];
            for (int v = 0; v <V ; v++)
            {
                if (!visited[v])
                {
                    //DFSUtil<T>(v,visited, graph);
                }
            }
        }

        //private void DFSUtil<T>(int v, bool[] visited, Graph<T> graph)
        //{
        //    visited[v] = true;
        //    Console.WriteLine(v+" ");
        //    foreach (var item in graph.AdjacencyList )
        //    {
        //        if (!visited[item.Key])
        //        {
        //            DFSUtil<T>(item, visited,graph);
        //        }
        //    }
        //}
   // }
}

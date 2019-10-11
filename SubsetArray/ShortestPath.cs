using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
//     Create a set sptSet(shortest path tree set) that keeps track of vertices included in shortest path tree, i.e., whose minimum distance from source is calculated and finalized.Initially, this set is empty.
//2) Assign a distance value to all vertices in the input graph. Initialize all distance values as INFINITE. Assign distance value as 0 for the source vertex so that it is picked first.
//3) While sptSet doesn’t include all vertices
//….a) Pick a vertex u which is not there in sptSet and has minimum distance value.
//….b) Include u to sptSet.
//….c) Update distance value of all adjacent vertices of u. To update the distance values, iterate through all adjacent vertices. For every adjacent vertex v, if sum of distance value of u (from source) and weight of edge u-v, is less than the distance value of v, then update the distance value of v.
   public class ShortestPath
    {
        public static int V = 9;

        public int minDistance(int[] dist , bool[] visited)
        {
            int min =int.MaxValue,min_index=-1;
            for (int i = 0; i < V; i++)
            {
                if (visited[i]==false&&dist[i]<=min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }
            return min_index;
        }

        // The output array.dist[i]
        // will hold the shortest 
        // distance from src to i

        // Set[i] will true if vertex 
        // i is included in shortest path 
        // tree or shortest distance from 
        // src to i is finalized 

        //  // Distance of source vertex 
        // from itself is always 0 

        // Update dist value of the adjacent 
        // vertices of the picked vertex. 

        // Update dist[v] only if is not in 
        // sptSet, there is an edge from u 
        // to v, and total weight of path 
        // from src to v through u is smaller 
        // than current value of dist[v] 
       public void djikshtraAlgo(int[,] graph, int src)
        {
            //holds shortest distance from src to i 
            int[] dist = new int[V];
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;            
            }

            dist[src] = 0;

            //parent array to store shortest path tree 
            int[] parents = new int[V];

            //starting vertex does not have a parent 
            parents[src] = -1;
            
            for (int count = 0; count < V-1; count++)
            {
                int u = minDistance(dist, visited);
                visited[u] = true;
                for (int j = 0; j < V; j++)
                {
                    //1. not in the set 
                    if (!visited[j] && graph[u,j]!=0 &&  dist[u]!=int.MaxValue && dist[u]+graph[u,j]<dist[j])
                    {
                        parents[j] = u;
                        dist[j] = dist[u] + graph[u, j];
                    }
                }
            
            }

            //print
            printShortestPath(src, dist, parents);
        }

        private void printShortestPath(int src, int[] dist, int[] parents)
        {
            int nVertices = dist.Length;
            Console.WriteLine("vertex\t distance \t path");
            for (int i = 0; i < nVertices; i++)
            {
                if (i!=src)
                {
                    Console.Write("\n" + src + " -> ");
                    Console.Write(i + " \t\t ");
                    Console.Write(dist[i] + "\t\t");
                    printPath(i, parents);
                }
            }
        }

        private void printPath(int i, int[] parents)
        {
            if (i==-1)
            {
                return;
            }
            printPath(parents[i], parents);
            Console.Write(i+" ");
        }
    }
}

//Time Complexity of the implementation is O(V^2). If the input graph is represented using adjacency list, it can be reduced to O(E log V) with the help of binary heap. 


//path print karte waqt : patents[i] pass karenge ....to hum parent of src tak jaayenge 
//..last mein print kar denge 
//jab parent[src ]==-1  

//Dijkstra's algorithm returns a shortest path tree, containing the shortest path from a starting vertex to each other vertex, but not necessarily the shortest paths between the other vertices, or a shortest route that visits all the vertices.
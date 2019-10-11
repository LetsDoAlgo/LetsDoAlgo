using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class BFSPathPrint
    {
    }

    public class GraphsBFS<T>
    {
        public GraphsBFS()
        {

        }
        public GraphsBFS(IEnumerable<T> vertices , IEnumerable<Tuple<T,T>> edges)
        {
            foreach (var item in vertices)
            {
                AddVertex(item);
            }

            foreach (var item in edges)
            {
                AddEdge(item);
            }
        }

        private void AddEdge(Tuple<T, T> item)
        {
            if (AdjacencyList.ContainsKey(item.Item1)&&AdjacencyList.ContainsKey(item.Item2))
            {
                AdjacencyList[item.Item1].Add(item.Item2);
                AdjacencyList[item.Item2].Add(item.Item1);
            }
        }

        private void AddVertex(T item)
        {
            AdjacencyList[item] = new HashSet<T>();
        }

        public Dictionary<T, HashSet<T>> AdjacencyList = new Dictionary<T, HashSet<T>>(); 
        //vertices 
      
    }

    public class AlgorithmsBFS
    {
        public HashSet<T> BFS<T>(GraphsBFS<T> graph , T start)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }
            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))
                {
                    continue;
                }
                visited.Add(vertex);

                foreach (var nbr in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(nbr))
                    {
                        queue.Enqueue(nbr);
                    }
                }
            }
            return visited;
           
        }


        public HashSet<T> BFSPath<T>(GraphsBFS<T> graph, T start, Action<T> previsit = null)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }
            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))
                {
                    continue;
                }
                //This will help to update path each time the new vertex is visited 
                previsit?.Invoke(vertex);
                visited.Add(vertex);

                foreach (var nbr in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(nbr))
                    {
                        queue.Enqueue(nbr);
                    }
                }
            }
            return visited;

        }

       
       
    }

    //if want to print the path 
    //add extra parameter 

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class AlienLanguage
    {
       

    }

    public class GraphAlien<T>
    {

        private LinkedList<int>[] adjacencyList;
        public GraphAlien(int nvertice)
        {
            adjacencyList = new LinkedList<int>[nvertice];
            for (int i = 0; i < nvertice; i++)
            {
                adjacencyList[i] = new LinkedList<int>();
            }
        }
        public GraphAlien()
        {

        }
        public void AddEdge(int startvertex, int endvertex)
        {
            adjacencyList[startvertex].AddFirst(endvertex);
        }
     
        public int getNoVertices()
        {
            return adjacencyList.Length;
        }

        public void Tsort(int currentVertexx , bool[] visisted , Stack<int> stack)
        {
            visisted[currentVertexx] = true;

            foreach (var item in adjacencyList[currentVertexx])
            {
                if (!visisted[item])
                {
                    Tsort(item, visisted, stack);
                }
            }

            stack.Push(currentVertexx);
        }

       public void PrintTSort()
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[getNoVertices()];
            for (int i = 0; i < getNoVertices(); i++)
            {
                visited[i] = false;
            }

            //call recursive helper function to store TSort
            for (int i = 0; i < getNoVertices(); i++)
            {
                if (!visited[i])
                {
                    Tsort(i, visited, stack);
                }
            }

            while (!(stack.Count==0))
            {
                Console.WriteLine((char)('a'+stack.Pop()));
            }
        }
    }

    public class OrderOfCharacters
    {
        public static void printOrdrer(string[] words  ,int alpha)
        {
            GraphAlien<int> graph = new GraphAlien<int>(alpha);
            for (int i = 0; i < words.Length - 1; i++)
            {
                // Take the current two words and find the first mismatching 
                // character 
                string word1 = words[i];
                string word2 = words[i + 1];
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    
                    // If we find a mismatching character, then add an edge 
                    // from character of word1 to that of word2 
                    if (word1[j] != word2[j])
                    {
                        graph.AddEdge(word1[j] - 'a', word2[j] - 'a');
                        break;
                    }
                }
            }

            // Print topological sort of the above created graph 
            graph.PrintTSort();
        }
    }

}

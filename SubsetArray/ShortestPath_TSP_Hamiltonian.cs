using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class ShortestPath_TSP_Hamiltonian
    {
        // Function to find the minimum weight Hamiltonian Cycle 
       public static int tsp(int[,] graph, bool[] v, int currPos,
                int n, int count, int cost, int ans)
        {

            // If last node is reached and it has a link 
            // to the starting node i.e the source then 
            // keep the minimum value out of the total cost 
            // of traversal and "ans" 
            // Finally return to check for more possible values 
            if (count == n && graph[currPos, 0] > 0)
            {
                ans = Math.Min(ans, cost + graph[currPos, 0]);
                return ans;
            }

            // BACKTRACKING STEP 
            // Loop to traverse the adjacency list 
            // of currPos node and increasing the count 
            // by 1 and cost by graph[currPos,i] value 
            for (int i = 0; i < n; i++)
            {
                if (v[i] == false && graph[currPos, i] > 0)
                {

                    // Mark as visited 
                    v[i] = true;
                    ans = tsp(graph, v, i, n, count + 1,cost + graph[currPos, i], ans);

                    // Mark ith node as unvisited 
                    v[i] = false;
                }
            }
            return ans;
        }
    }
}

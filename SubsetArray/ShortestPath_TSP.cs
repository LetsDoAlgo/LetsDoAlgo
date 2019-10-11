using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class ShortestPath_TSP
    {
        //Travelling Salesman Problem (TSP): Given a set of cities and distance between every pair of cities, the problem is to find the shortest possible route that visits every city exactly once and returns back to the starting point.
        //Approach: In this post, implementation of simple solution is discussed.
       
        //Consider city 1 (let say 0th node) as the starting and ending point. Since route is cyclic, we can consider any point as starting point.
        
        //Start traversing from the source to its adjacent nodes in dfs manner.
        
        //Calculate cost of every traversal and keep track of minimum cost and keep on updating the value of minimum cost stored value.
        
        //Return the permutation with minimum cost.

        static int TSP(int[,] graph, bool[] v, int currPos, int n, int count, int cost, int ans)
        {
            //1. last node is reached 
            //link to the starting node (source)
            //keep min val out of total cost of traversal 
            //return to check 


            return 0;

        }

        //bruteforce method will be to find all the permutations 
        //tc: n!
        //therfore use dp 
        
        
        //example of asymmetric graph is tickets 
        
        //start with vertex 0 
        //excluding 0 : generate all possible subsests 
         
    }
}

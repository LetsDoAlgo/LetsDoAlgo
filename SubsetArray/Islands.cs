using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    public class Pair
    {
       public int x , y;
        public Pair(int y , int x)
        {
            this.x = x;
            this.y = y;
        }
    }

   public class Islands
    {
        public int NumIslands(char[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            var visited = new bool[rows, columns];
            var myqueue = new Queue<Tuple<int, int>>();
            var count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!visited[i, j] && grid[i, j] == '1')
                    {
                        count++;
                        myqueue.Enqueue(new Tuple<int, int>(i, j));

                        while (myqueue.Count > 0)
                        {
                            var top = myqueue.Dequeue();
                            visited[top.Item1, top.Item2] = true;

                             if (top.Item1 - 1 >= 0 && !visited[top.Item1 - 1, top.Item2] && grid[top.Item1 - 1, top.Item2] == '1' && !myqueue.Contains(new Tuple<int, int>(top.Item1 - 1, top.Item2)))
                            {
                                myqueue.Enqueue(new Tuple<int, int>(top.Item1 - 1, top.Item2));
                            }
                            if (top.Item2 - 1 >= 0 && !visited[top.Item1, top.Item2 - 1] && grid[top.Item1, top.Item2 - 1] == '1' && !myqueue.Contains(new Tuple<int, int>(top.Item1, top.Item2 - 1)))
                            {
                                myqueue.Enqueue(new Tuple<int, int>(top.Item1, top.Item2 - 1));
                            }
                            if (top.Item1 + 1 < rows && !visited[top.Item1 + 1, top.Item2] && grid[top.Item1 + 1, top.Item2] == '1' && !myqueue.Contains(new Tuple<int, int>(top.Item1 + 1, top.Item2)))
                            {
                                myqueue.Enqueue(new Tuple<int, int>(top.Item1 + 1, top.Item2));
                            }
                            if (top.Item2 + 1 < columns && !visited[top.Item1, top.Item2 + 1] && grid[top.Item1, top.Item2 + 1] == '1' && !myqueue.Contains(new Tuple<int, int>(top.Item1, top.Item2 + 1)))
                            {
                                myqueue.Enqueue(new Tuple<int, int>(top.Item1, top.Item2 + 1));
                            }
                        }

                    }
                }
            }

            return count;
        }

        private int count = 0;
        private bool[,] visited;
        public int NumIslands_(char[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            visited = new bool[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i, j] == '1' && !visited[i, j])
                    {
                        this.NumIslandsHelper(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }
        private void NumIslandsHelper(char[,] grid, int i, int j)
        {
            if (i < 0 || i >= grid.GetLength(0)) return;
            if (j < 0 || j >= grid.GetLength(1)) return;
            if (visited[i, j]) return;
            if (grid[i, j] != '1') return;

            visited[i, j] = true;

            this.NumIslandsHelper(grid, i - 1, j);
            this.NumIslandsHelper(grid, i + 1, j);
            this.NumIslandsHelper(grid, i, j - 1);
            this.NumIslandsHelper(grid, i, j + 1);
        }

        ///bfs and 8 directions 
        //x-1,y  (-1,0)
        //x-1, y-1  (-1,-1)
        //x-1,y+1  (-1,+1)
        //x, y  ---not considered movement
        //x,y-1  (0,-1)
        //x,y+1 (0,1)
        //x+1,y  (1,0)
        //x+1,y-1  (1,-1)
        //x+1,y+1   (1,1)

        //////////////////////////////////////////////////////////////
        //https://www.techiedelight.com/count-the-number-of-islands/
        private static int[] row = {-1, -1, -1,  0, 0, 1,  1,  1 };
        private static int[] col = { 0, -1, +1, -1, 1, 0, -1, 1 };

        public static bool IsSafe(int[,] mat , int x , int y , bool[,] processed)
         {
            //invalid scenarios 
            //1. not valid matrix coordinate 
            //2. represent water 
            //3.already processed 

            return (x >= 0) && (x < processed.Length) && (y >= 0) && (y < processed.Length) && mat[x, y] == 1 && !processed[x, y];
        }

        public static void BFS(int[,] mat , bool[,] processed, int i , int j)
        {
            Queue<Pair> q = new Queue<Pair>();
            q.Enqueue(new Pair(i, j));
            processed[i, j] = true;
            while (q.Count!=0)
            {
                //get first element values as it is the pair 
                //we need it as we need to iterate over all the adjacent positions
                var x = q.Peek().x;
                var y = q.Peek().y;
                q.Dequeue();
                for (int k = 0; k < 8; k++)
                {
                    //going through all the possible combi
                    if (IsSafe(mat,x+row[k],y+col[k],processed))
                    {
                        processed[x + row[k], y + col[k]] = true;
                        q.Enqueue(new Pair(x+row[k], y+col[k]));
                    }
                }
            }
        }
    }

}

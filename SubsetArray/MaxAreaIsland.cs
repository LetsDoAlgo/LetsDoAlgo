using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class MaxAreaIsland
    {
        static int ROW = 5;
        static int COL = 5;
       static bool IsSafe( int[,] M, int row , int col , bool[,] visited  )
        {
            return row>=0&& row<=ROW&& col>=0&& col<COL &&M[row,col]==1&& !visited[row,col];
        }

        static void DFS(int[,] M, int row , int col , bool[,] visisted)
        {
            int[] rownbr = new int[] {-1,-1,-1,0,0,1,1,1 };
            int[] colnbr = new int[] {-1,0,1,-1,1,-1,0,1 };
            visisted[row, col] = true;
            for (int k = 0; k < 8; k++)
            {
                if (IsSafe(M,row+rownbr[k],col+colnbr[k],visisted))
                {
                    DFS(M, row + rownbr[k], col + colnbr[k], visisted);
                }
            }

        }

        //main function
        static int countIslands(int[,] M)
        {
            bool[,] visisted = new bool[ROW, COL];
            int count = 0;
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (M[i,j]==1&&!visisted[i,j])
                    {
                        DFS(M, i, j, visisted);
                        ++count;
                    }
                }
            }

            return count;
                
         }


        //largest region

        
        static int MaxAreaIslandCalc(int[,] M)
        {
            bool[,] visisted = new bool[ROW, COL];
            int max = 0;
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (M[i,j]==1)
                    {
                        max = Math.Max(max, DFS_2(M, i, j, visisted));
                    }
                }
            }
            return max;
        }
        static int DFS_2(int[,] M, int row, int col, bool[,] visisted)
        {
            int count = 1;
            int[] rownbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colnbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
            visisted[row, col] = true;
            for (int k = 0; k < 8; k++)
            {
                if (IsSafe(M, row + rownbr[k], col + colnbr[k], visisted))
                {
                  count += DFS_2(M, row + rownbr[k], col + colnbr[k], visisted);
                }
            }
            return count;
        }
    }
}

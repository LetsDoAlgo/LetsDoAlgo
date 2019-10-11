using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class Path_2DMatrix
    {
        public static void printMatrix(int[,] mat, int m, int n,
                                      int i, int j, int[] path, int idx)
        {
            path[idx] = mat[i, j];

            // Reached the bottom of the matrix so we are left with 
            // only option to move right 
            if (i == m - 1)
            {
               
                for (int k = j + 1; k < n; k++)
                {
                    var maxrange = idx + k - j;
                    path[idx + k - j] = mat[i, k];
                }
                for (int l = 0; l < idx + n - j; l++)
                {
                    var maxrange = idx + n - j;
                    Console.Write(path[l] + " ");
                }
                Console.WriteLine();
                return;
            }

            // Reached the right corner of the matrix we are left with 
            // only the downward movement. 
            if (j == n - 1)
            {
                for (int k = i + 1; k < m; k++)
                {
                    var maxrange = idx + k - i;
                    path[idx + k - i] = mat[k, j];
                }
                for (int l = 0; l < idx + m - i; l++)
                {
                    var maxrange = idx + m - i;
                    Console.Write(path[l] + " ");
                }
                Console.WriteLine();
                return;
            }

            // Print all the paths that are possible after moving down 
            printMatrix(mat, m, n, i + 1, j, path, idx + 1);

            // Print all the paths that are possible after moving right 
            printMatrix(mat, m, n, i, j + 1, path, idx + 1);
        }
    }
}

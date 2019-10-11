using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class KClosestPointToOrigin
    {
        public class Coordinate
        {
            public int x { get; set; }
            public int y { get; set; }

            public Coordinate(int x , int y )
            {
                this.x = x;
                this.y = y;
            }
        }

        public class KClosest
        {
            public static int cal(Coordinate a)
            {
                return a.x * a.x + a.y * a.y;
            }
            public static List<Coordinate> FindK(List<Coordinate> input , int k)
            {
                Dictionary<Coordinate, int> map = new Dictionary<Coordinate, int>();
                int longest = 0;
                foreach (var item in input)
                {
                    int dist = cal(item);
                    map.Add(item, dist);
                    longest = Math.Max(longest, dist);
                }

                List<Coordinate> res = helper(input, 0, input.Count - 1, k, map);
                return res;
            }

            private static List<Coordinate> helper(List<Coordinate> input, int start, int end, int k, Dictionary<Coordinate, int> map)
            {
                List<Coordinate> res = new List<Coordinate>();

                int l = start;
                int r = end;
                int pivot = r;

                while (l<r)
                {
                    while (l < r && map[input[l]] < map[input[pivot]]) l++;
                    while (l < r && map[input[r]] >= map[input[pivot]]) r--;
                    if (l >= r) break;
                    swap(input, l, r);
                }
                swap(input, l, pivot);
                if (l + 1 == k)
                {
                    for (int i=0; i<=l; i++)
                    {
                        res.Add(input[i]);
                    }
                    return res;
                    
                }
                else if(l+1<k)
                {
                    return helper(input , l+1, end , k , map);
                }
                else
                {
                    return helper(input, start, l - 1, k, map);
                }
            }

            private static void swap(List<Coordinate> input, int l, int r)
            {
                Coordinate temp = input[l];
                input[l] = input[r];
                input[r] = temp; 

            }
        }

    }
}

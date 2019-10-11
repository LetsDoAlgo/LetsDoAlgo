using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    struct Point
    {
        public int x;
        public int y;
        public Point(int x , int y )
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }

   public class KNearestPoint
    {
       Point FindKPoint(Point[] points , int k )
        {
            var ps = from p in points
                     orderby p.x * p.x + p.y * p.y ascending
                     select p;

            return ps.Skip(k - 1).First();
        }
    }
}

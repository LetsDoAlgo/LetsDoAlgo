using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class BoxStacking
    {
       public class Box :IComparable<Box>
        {

            // h --> height, w --> width, 
            // d --> depth 
           public int h, w, d, area;

            // for simplicity of solution, 
            // always keep w <= d 

            /*Constructor to initialise object*/
            public Box(int h, int w, int d)
            {
                this.h = h;
                this.w = w;
                this.d = d;
            }

            public int CompareTo(Box other)
            {
                return other.area - this.area;
            }

            
         }

        public static int maxStackeight(Box[] arr, int n)
        {
            Box[] rot = new Box[n * 3];
            for (int i = 0; i < n; i++)
            {
                Box b1 = arr[i];
                rot[3 * i] = new Box(b1.h, Math.Max(b1.w, b1.d), Math.Min(b1.w, b1.d));
                rot[3 * i + 1] = new Box(b1.w, Math.Max(b1.h, b1.d), Math.Min(b1.h,b1.d));
                rot[3 * i + 2] = new Box(b1.d, Math.Max(b1.w, b1.h), Math.Min(b1.h,b1.w));
            }

            for (int i = 0; i < rot.Length; i++)
            {
                rot[i].area = rot[i].w * rot[i].d;

            }

            Array.Sort(rot);

            int count = 3 * n;

            int[] mh = new int[count];

            for (int i = 0; i < count; i++)
            {
                mh[i] = 0;
                Box box = rot[i];
                int val = 0;

                for (int j = 0; j < i; j++)
                {
                    Box prevBox = rot[j];
                    if (box.w<prevBox.w&&box.d<prevBox.d)
                    {
                        val = Math.Max(val, mh[j]);
                    }
                }
                mh[i] = val + box.h;
            }

            int max = -1;
            for (int i = 0; i < count; i++)
            {
                max = Math.Max(max,mh[i]);
            }
            return max;
        }
     }
}

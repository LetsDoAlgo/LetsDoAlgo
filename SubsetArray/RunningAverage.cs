using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class RunningAverage
    {
        int size;

        Queue<int> q;
        int sum;
        int n;
        public RunningAverage(int size)
        {
            q = new Queue<int>();
            n = size;
            sum = 0;
        }

        public double next(int val)
        {
            q.Enqueue(val);
            double result = 0;
            sum += val;
            if (q.Count<=n)
            {
                result =(double) sum / q.Count;
            }
            else
            {
                int remove = q.Dequeue();
                sum -= remove;
                result = (double) sum / n;
            }

            return result;
        }

    }


//    //class MovingAverage {
//    int[] num;
//    int pos;
//    int sum;
//    int count;

//    /** Initialize your data structure here. */
//    public MovingAverage(int size)
//    {
//        num = new int[size];
//        pos = 0;
//        sum = 0;
//        count = 0;
//    }

//    public double next(int val)
//    {
//        sum -= num[pos];
//        num[pos++] = val;
//        if (pos == num.length)
//        {
//            pos = 0;
//        }
//        sum += val;
//        count = count == num.length ? count : count + 1;
//        return ((double)sum) / count;
//    }
//}
}

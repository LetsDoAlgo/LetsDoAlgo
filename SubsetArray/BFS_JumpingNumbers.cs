using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class BFS_JumpingNumbers
    {
        //print all numbers <=x
        //root node is num 
        public static void BFS(int x , int num)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(num);
            while (queue.Count!=0)
            {
                num = queue.Peek();
                queue.Dequeue();
                if (num<=x)
                {
                    Console.WriteLine(num);
                    int last_digit = num % 10;
                 
                    //this is nothing but pushing all the child nodes on the queue 
                    if (last_digit==0)
                    {
                        var num_ =( num * 10 )+ (last_digit + 1);
                        queue.Enqueue(num_);
                    }
                    if (last_digit==9)
                    {
                        var num_ = (num * 10) + (last_digit - 1);
                        queue.Enqueue(num_);
                    }
                    else
                    {
                        var num_ = (num * 10) + (last_digit - 1);
                        queue.Enqueue(num_);
                         num_ = (num * 10) + (last_digit + 1);
                        queue.Enqueue(num_);
                    }
                }
            }
        }

        public static void printJumping(int x)
        {
            Console.WriteLine("0");
            for (int i = 1; i <=9 && i<=x; i++)
            {
                BFS(40, i);
            }
        }
    }
}

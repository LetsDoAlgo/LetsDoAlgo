using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class FrogJump
    {
        public bool Cancross(int[] stones)
        {
            //if jump into water : remember where he was initially
            //and how much jump he took 
            //check 2 adjacent stoens are 
            for (int i = 3; i < stones.Length; i++)
            {
                if (stones[i]>stones[i-1]*2)
                {
                    return false;
                }

            }
            HashSet<int> stonepos = new HashSet<int>();
            foreach (var item in stones)
            {
                stonepos.Add(item);
            }

            int laststone = stones[stones.Length - 1];
            Stack<int> position = new Stack<int>();
            Stack<int> jumps = new Stack<int>();

            position.Push(0);
            jumps.Push(0);
            while (position.Count()>0)
            {
               int pos = position.Pop();
               int jumpdist = jumps.Pop();
                for (int j = jumpdist-1; j <= jumpdist+1; j++)
                {
                    if (j<=0)
                    {
                        continue;
                    }
                    int nextpos = pos + j;
                    if (nextpos==laststone)
                    {
                        return true;
                    }
                   else if(stonepos.Contains(nextpos))
                    {
                        position.Push(nextpos);
                        jumps.Push(j);
                    }
                }
            }
            return false;
        }
    }

    class FruitsIntoBasket
    {
        //Max 2 baskets 
        //MAX substring with atmost 2 characters
        public int totalFruit(int[] tree)
        {
            if (tree==null||tree.Length==0)
            {
                return 0;
            }
            int max = 1;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int i = 0;
            int j = 0;
            while (j<tree.Length)
            {
                if (map.Count<=2)
                {
                    map.Add(tree[j], j++);
                }

                if (map.Count>2)
                {
                    //move away from the first type 
                    //move i to rightmost ocuurence of the fist fruit
                    int min = tree.Length - 1;
                    foreach (var item in map.Values)
                    {
                        min = Math.Min(min, item);
                    }
                    i = min + 1;
                    map.Remove(tree[min]);
                }
                max = Math.Max(max, j - i);
            }

            return max;
        }
    }

    class RecursiveStair
    {
        public static int countWays(int n)
        {
            int[] res = new int[n + 1];
            res[0] = 1;
            res[1] = 1;
            res[2] = 2;
            for (int i = 3; i <=n; i++)
            {
                res[i] = res[i - 1] + res[i - 2] + res[i - 3];
               
            }
            return res[n];
        }

        public static int countWays_constantSpace(int n)
        {
            //by storing only last 3 values 
            if (n<=1)
            {
                return 1;
            }
            int a = 1;//1 way with no stps
            int b = 1;//1 way to reach 1st stair
            int c = 2;//2 ways to reach 2nd stair
            for (int i = 3; i <=n; i++)
            {
                int result = a + b + c;
                a = b;
                b = c;
                c = result;
            }

            return c;
        }

    }

    class DistributeKCandies
    {
        //distriute n candies among k people 
        //form largest number whose sum upto natural numbers si less than N
        static void Candies(int[] arr , int k)
        {
            //each gets atleast 1 packet 
            //max choc - choc in packets = min
            //max choc - min choc to std = min  

            //base cond - 1
            if (arr==null ||arr.Length ==0||k==0)
            {
                return;
            }
            Array.Sort(arr);

            //base cond - 2 :std are more than packet 
            if (arr.Length<k)
            {
                return;

            }
            //bec we have sorted thst is why 
            int mindif = arr[arr.Length - 1];
            int first = 0;
            int last = 0;
            int diff = 0;
            for (int i = 0; i+k-1 < arr.Length; i++)
            {
                diff = arr[i + k - 1] - arr[i];
                if (diff<mindif)
                {
                    mindif = diff;
                    first = i;
                    last = i + k - 1;
                }
            }

        }

    }

    class stackUsingArray
    {
        static readonly int max = 1000;
        int top;
        int[] stack = new int[max];
        //isempty
        ////ctor
        //push
        //pop

        bool IsEmpty()
        {
            return (top < 0);
        }

        public stackUsingArray()
        {
            top = -1;
        }

        public bool Push(int data )
        {
            //check overflow
            if (top>=max)
            {
                Console.WriteLine("stack overflow");
                return false;
            }
            else
            {
                stack[++top] = data;
                return true;
            }
        }

        public int Pop()
        {
            if (top<0)
            {
                return 0;
            }
            else
            {
                int val = stack[top--];
                return val;
            }
        }

        internal void Peek()
        {
            if (top<0)
            {
                Console.WriteLine("stack underflow");
                return;
            }
            else
            {
                Console.WriteLine(stack[top]);
            }
        }

        internal void PrintStack()
        {
            if (top<0)
            {
                return;

            }
            else
            {
                for (int i = top; i >=0; i--)
                {
                    Console.WriteLine(stack[i]);
                }
            }
        }
      
    }
    class PeakElemet
    {
        // A binary search based  
        // function that returns  
        // index of a peak element 
        static int findPeakUtil(int[] arr, int low,int high, int n)
        {
            // Find index of  
            // middle element 
            int mid = low + (high - low) / 2;

            // Compare middle element with 
            // its neighbours (if neighbours 
            // exist) 
            if ((mid == 0 ||  arr[mid - 1] <= arr[mid]) &&    (mid == n - 1 ||   arr[mid + 1] <= arr[mid]))
                return mid;

            // If middle element is not  
            // peak and its left neighbor 
            // is greater than it,then  
            // left half must have a  
            // peak element 
            else if (mid > 0 &&  arr[mid - 1] > arr[mid])
                return findPeakUtil(arr, low,(mid - 1), n);

            // If middle element is not  
            // peak and its right neighbor 
            // is greater than it, then  
            // right half must have a peak 
            // element 
            else return findPeakUtil(arr, (mid + 1),high, n);
        }

        // A wrapper over recursive  
        // function findPeakUtil() 
        static int findPeak(int[] arr,
                            int n)
        {
            return findPeakUtil(arr, 0,
                                n - 1, n);
        }
    }

    class BanckSpaceChar
    {
        static string calc(string s)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]!='#')
                {
                    st.Push(s[i]);
                }
                else if(st.Count!=0)
                {
                    //for popping check count should  not be 0 
                    //jitne # the , utne pop ho chuke hain 
                    st.Pop();
                }
            }
            string ans = "";
            while (st.Count!=0)
            {
                //pop will give the inverted string 
               ans+= st.Pop();
            }
            //again reverse it 
            //we will traverse from end 
            string answer = "";
            for (int j = ans.Length; j >=0; j--)
            {
                answer += ans[j];
            }


            return answer;
        }
    }

    class RectangularArea
    {
        static int getMaxArea(int[] arr, int n)
        {
            Stack<int> s = new Stack<int>();
            int max_Area = 0;
            int top;
            int area_with_top  ;
            int i = 0;
            while (i<n)
            {
                //remember to increment i only while pushnig 
                //as it will help to give aount od number of arrays
                if (s.Count==0||arr[s.Peek()]<=arr[i])
                {
                    s.Push(i++);
                }
                else
                {
                    top = s.Peek();
                    s.Pop();
                    int x = s.Count == 0 ?i:i-s.Peek()-1;
                    area_with_top = arr[top] * x;
                    if (max_Area<area_with_top)
                    {
                        max_Area = area_with_top;
                    }
                }
            }

            //pop remeainig bars 
            while (s.Count>0)
            {
                top = s.Peek();
                s.Pop();
                int x = s.Count == 0 ? i : i - s.Peek() - 1;
                area_with_top = arr[top] * x;
                if (max_Area < area_with_top)
                {
                    max_Area = area_with_top;
                }
            }
            return max_Area;
        }
    }
}

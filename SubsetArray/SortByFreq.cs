using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class SortByFreq
    {
       public class Data : IComparable<Data>
        {
           public int data;
           public int count;
           public int index;

            public Data(int value , int count , int index)
            {
                this.data = value;
                this.count = count;
                this.index = index;
            }
            public int CompareTo(Data other)
            {
                // throw new NotImplementedException();

                if (this.count!=other.count)
                {
                    return other.count - this.count;

                }

                return this.index - other.index;
            }

        }

       public class CustomSort
        {
           public void customSort2(int[] arr)
            {
                if (arr == null||arr.Length<2)
                {
                    return;
                }
                Dictionary<int, Data> dict = new Dictionary<int, Data>();

                for (int i = 0; i < arr.Length; i++)
                {
                    Data data;
                    if (!dict.ContainsKey(arr[i]))
                    {
                        dict.Add(arr[i], new Data(arr[i], 1, i));
                    }
                    else
                    {
                        data = dict[arr[i]];
                    }
               
                }

                Data[] values = dict.Values.ToArray();
                Array.Sort(values);
               
            }
        }

    }
}

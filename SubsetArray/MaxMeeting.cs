using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class MaxMeeting
    {
       public struct meeting
        {
            public int start;
            public int end;
            public int pos;
        }

        bool comparator( meeting m1,  meeting m2)
        {
            return (m1.end < m2.end);
        }
       public static void MaxMeetingFind(int[] s, int[] f, int n)
        {
             meeting[] meet = new meeting[n];
            for (int i = 0; i < n; i++)
            {
                meet[i].start = s[i];
                meet[i].end = f[i];
                meet[i].pos = i + 1;

            }
            //sort the meeting acco to their finish 
           //check this function ----> sort(meet, meet + n, comparator);

            //vector for sorting selected meeting 
            List<int> m = new List<int>();
            m.Add(meet[0].pos);
            int time_limit = meet[0].end;
            for (int i = 1; i < n; i++)
            {
                if (meet[i].start>=time_limit)
                {
                    m.Add(meet[i].pos);
                    time_limit = meet[i].end;
                }
            }

            for (int i = 0; i < m.Count; i++)
            {
                Console.WriteLine(m[i]);
            }
        }
    }
}

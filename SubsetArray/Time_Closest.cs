using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    public static class Time_Closest
    {
        //input : "19:34"
        public static string NextClosestTime(string time)
        {
            int min = int.Parse(time.Substring(0, 2)) * 60;
            min += int.Parse(time.Substring(3));
            HashSet<int> digits = new HashSet<int>();
            foreach (char item in time.ToCharArray())
            {
                //this will help to tackle whether the number what we are getting after subtracting is there or nor 

                digits.Add(item - '0');
            }

            while (true)
            {
                //check whetehrnew time is valid 
                min = (min + 1) % (24 * 60);
                //convert min to hours 
                //divide by 10 to get rightmost digit 
            //
                int[] nextTime = { min / 60 / 10, min / 60 / 10, min % 60 / 10, min % 60 % 10 };
                bool isValid = true;
                foreach (int item in nextTime)
                {
                    if (!digits.Contains(item))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    var sd = min / 60;
                    var sdf = min % 60;
                    return string.Format("%02d:%02d", min / 60, min % 60);
                }
            }
        }

        public static string NextClosestTimeTwo(string time)
        {
           int hour = int.Parse(time.Substring(0, 2));
           int min = int.Parse(time.Substring(3, 2));
            while (true)
            {
                if (++min==60)
                {
                    min = 0;
                    ++hour;
                    hour %= 24;
                }

                string curr =  hour.ToString()+":"+min.ToString();
                bool valid = true;
                for (int i = 0; i < curr.Length; ++i)
                {
                    if (time.IndexOf(curr.ToCharArray()[i])<0)
                    {
                        valid = false;
                        break;
                    }
                    if (valid)
                    {
                        return curr;
                    }
                }
            }

        }
    }
}

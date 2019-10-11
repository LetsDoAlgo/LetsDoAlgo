using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class MetsStrings
    {
        //no should be of same legth 
        //only 1 different swap must e required 
        public static bool AreMetaStrings(string source , string dest)
        {
            if (source.Length!=dest.Length)
            {
                return false;
            }
            int count = 0;
            int prev = -1;
            int curr = -1;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i]!=dest[i])
                {
                    count++;
                    if(count>2)
                    {
                        return false;
                    }
                    //store both unmatched characters of both strings 
                    prev = curr;
                    curr = i;
                }
            }

            return (count == 2 && source[prev] == dest[curr] && source[curr] == dest[prev]);
        }
    }
}

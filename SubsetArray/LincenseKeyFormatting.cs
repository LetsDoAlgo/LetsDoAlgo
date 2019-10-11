using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //we have to decide tht each partition contains k exact characters except first 
    //which gives us the hint to start from the backward direction.
    //case 1.encounter dash : ignore it 
    //2. found k characters and grouped them - add dash 
    //count next k characters
    //3. just have a number ---> don't have k characters yet   

   public class LincenseKeyFormatting
    {
        public string LicenseKeyFormattingFind(string s , int k )
        {
            StringBuilder result = new StringBuilder();
            s = s.Replace("-", "").ToUpper();
            int n = s.Length - 1;
            for (int i = s.Length-1; i >=0; i--)
            {
                if ((n-i)%k==0&&(n-i)!=0)
                {
                    result.Insert(0, "-");
                }

                result.Insert(0, s[i]);
            }

            return result.ToString();

        }

    }
}

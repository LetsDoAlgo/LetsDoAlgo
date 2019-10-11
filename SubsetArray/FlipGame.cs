using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class FlipGame
    {
        //s = "++++"
        //o/p: --++ , +--+,++--

        public List<string> generatePossibleNextMove(string s)
        {
            List<string> possiblestates = new List<string>();
            int i = 0;
            while (i<s.Length)
            {
                //give the index of first ++ ND THEN NEXT ++ 
                //to avoid the situation of getting the same index of ++ again , we are putting i as apramter . 
                int nextmove = i == 0 ? s.IndexOf("++") : s.IndexOf("++", i);
                //In C#, IndexOf() method is a string method. This method is used to find the zero based index of the first occurrence of a specified character or string within current instance of the string. The method returns -1 if the character or string is not found.
                if (nextmove==-1)
                {
                    return possiblestates;
                }
                //because of the subsrting calls , our runtime will be o(n^2)
                string nextState = s.Substring(0, nextmove) + "--" + s.Substring(nextmove+2);
                possiblestates.Add(nextState);
                i = nextmove + 1;
            }
            return possiblestates;
        }


        //flip game 2 
        public bool CanWin(string s)
        {
            var strArr = s.ToCharArray();
            if (s==null||s.Length<2)
            {
                return false;
            }

            for (int i = 0; i < s.Length-1; i++)
            {
                if (strArr[i]=='+' && strArr[i+1]=='+')
                {
                    string nextState = s.Substring(0, i) + "--" + s.Substring(i + 2);
                    if (!CanWin(nextState))
                    {
                        return true;
                    } 
                }
            }
            return false;
        }
    }
}

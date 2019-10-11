using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class convert_number_to_words
    {
       public static void convert_to_words(char[] num)
        {
            // Get number of digits  
            // in given number  
            int len = num.Length;

            // Base cases  
            if (len == 0)
            {
                Console.WriteLine("empty string");
                return;
            }
            if (len > 4)
            {
                Console.WriteLine("Length more than " +
                                  "4 is not supported");
                return;
            }

            /* The first string is not used,  
               it is to make array indexing simple */
            string[] single_digits = new string[]{ "zero", "one", "two",
                                           "three", "four", "five",
                                           "six", "seven", "eight",
                                           "nine"};

            /* The first string is not used,  
               it is to make array indexing simple */
            string[] two_digits = new string[]{"", "ten", "eleven", "twelve",
                                       "thirteen", "fourteen",
                                       "fifteen", "sixteen", "seventeen",
                                       "eighteen", "nineteen"};

            /* The first two string are not used, 
               they are to make array indexing simple*/
            string[] tens_multiple = new string[]{"", "", "twenty", "thirty",
                                          "forty", "fifty","sixty",
                                          "seventy", "eighty", "ninety"};

            string[] tens_power = new string[] { "hundred", "thousand" };

            /* Used for debugging purpose only */
            Console.Write((new string(num)) + ": ");

            /* For single digit number */
            if (len == 1)
            {
                Console.WriteLine(single_digits[num[0] - '0']);
                return;
            }

            /* Iterate while num  
                is not '\0' */
            int x = 0;
            while (x < num.Length)
            {

                /* Code path for first 2 digits */
                if (len >= 3)
                {
                    if (num[x] - '0' != 0)
                    {
                        Console.Write(single_digits[num[x] - '0'] + " ");
                        Console.Write(tens_power[len - 3] + " ");

                        // here len can be 3 or 4  
                    }
                    --len;
                }

                /* Code path for last 2 digits */
                else
                {
                    /* Need to explicitly handle  
                    10-19. Sum of the two digits  
                    is used as index of "two_digits"  
                    array of strings */
                    if (num[x] - '0' == 1)
                    {
                        int sum = num[x] - '0' +
                                  num[x] - '0';
                        Console.WriteLine(two_digits[sum]);
                        return;
                    }

                    /* Need to explicitely handle 20 */
                    else if (num[x] - '0' == 2 &&
                             num[x + 1] - '0' == 0)
                    {
                        Console.WriteLine("twenty");
                        return;
                    }

                    /* Rest of the two digit  
                    numbers i.e., 21 to 99 */
                    else
                    {
                        int i = (num[x] - '0');
                        if (i > 0)
                            Console.Write(tens_multiple[i] + " ");
                        else
                            Console.Write("");
                        ++x;
                        if (num[x] - '0' != 0)
                            Console.WriteLine(single_digits[num[x] - '0']);
                    }
                }
                ++x;
            }
        }
    }
}

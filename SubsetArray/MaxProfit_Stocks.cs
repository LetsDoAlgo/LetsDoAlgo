using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class MaxProfit_Stocks
    {
        public static int FindMaxProfit(int[] data)
        {
            int[] maxPrices = new int[data.Length];

            int maxPrice = data[data.Length - 1];
            maxPrices[maxPrices.Length - 1] = maxPrice;

            for (int i = data.Length - 2; i > 0; --i)
            {
                maxPrice = Math.Max(maxPrice, data[i]);
                maxPrices[i] = maxPrice;
            }

            int maxProfit = 0;
            int minPrice = data[0];

            for (int i = 0; i < data.Length - 1; ++i)
            {
                minPrice = Math.Min(data[i], minPrice);
                maxProfit = Math.Max(maxProfit, maxPrices[i + 1] - minPrice);
            }

            return maxProfit;
        }
        public static void DoTest(int[] data)
        {
            Console.WriteLine("historical data for the stocks ");
            for (int i = 1; i < data.Length + 1; ++i)
            {
                Console.Write("{0, 4}", i);
            }

            Console.WriteLine();
            for (int i = 0; i < data.Length; ++i)
            {
                Console.Write("{0, 4}", data[i]);
            }

            Console.WriteLine("\nmax profit is {0}", FindMaxProfit(data));
            Console.WriteLine("--------------------------------- ");
        }
    }
}

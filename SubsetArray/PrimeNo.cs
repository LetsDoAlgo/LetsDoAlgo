using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //In fact, we can mark off multiples of 5 starting at 5 × 5 = 25, because 5 × 2 = 10 was already marked off by multiple of 2, similarly 5 × 3 = 15 was already marked off by multiple of 3. Therefore, if the current number is p, we can always mark off multiples of p starting at p2, then in increments of p: p2 + p, p2 + 2p, ... Now what should be the terminating loop condition?

//It is easy to say that the terminating loop condition is p<n, which is certainly correct but not efficient.Do you still remember Hint #3?

//Yes, the terminating loop condition can be p< √n, as all non-primes ≥ √n must have already been marked off.When the loop terminates, all the numbers in the table that are non-marked are prime.

//The Sieve of Eratosthenes uses an extra O(n) memory and its runtime complexity is O(n log log n). For the more mathematically inclined readers, you can read more about its algorithm complexity
   public class PrimeNo
    {
        public int countPrimes(int n )
        {
            bool[] primes = new bool[n];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            for (int i = 2  ; i*i < primes.Length; i++)
            {
                if (primes[i])
                {
                    for (int j = i*i; j < primes.Length; j+=i)
                    {
                        primes[j] = false;
                    }
                }
            }

            int primeCount = 0;
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    primeCount++;
                }
            }

            return primeCount;
        }
    }
}

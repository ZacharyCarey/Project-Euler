using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

        private const int SieveSize = 10000;

        private static HashSet<long> composite = new HashSet<long>();
        private static List<long> foundPrimes = new List<long>();

        private static long currentLimit = 0;


        public static IEnumerable<long> Primes() {
            foreach(long prime in foundPrimes) {
                yield return prime;
			}

            int index = foundPrimes.Count;
			while (true) {
                long newLimit = currentLimit + SieveSize;
                SieveOfErathostenes(currentLimit, newLimit);
                currentLimit = newLimit;
                while(index < foundPrimes.Count) {
                    yield return foundPrimes[index];
                    index++;
				}
            }
            

        }

        //Sieves numbers from the range [lowerLimit, upperLimit) 
        //(i.e. not including the upper limit)
        //Modified SieveOfErathostenes to be able to keep generating more primes infinitely.
        private static void SieveOfErathostenes(long lowerLimit, long upperLimit) {
            //Only need to cross off numbers up to sqrt.
            long sqrt = (long)Math.Sqrt(upperLimit);
            for(long p = 2; p <= sqrt; p++) {
				if (composite.Contains(p)) {
                    continue; //The number is crossed off, skip it.
				}

                //Not crossed off means it's a prime.
                if(p >= lowerLimit) {
                    //But only add the prime if it's within our range
                    foundPrimes.Add(p);
				}

                //Cross off each multiple of this prime
                //Start at the prime squared, because lower numbers will have been crossed off already.
                //But if the square is less than our range, we can just skip to our range.
                for(long i = Math.Max(p * p, lowerLimit - (lowerLimit % p)); i < upperLimit; i += p) {
                    composite.Add(i);
				}
			}

            //The remaining numbers not crossed off are also prime
            //But also remember we have to stay in the current range
            for(long p = Math.Max(sqrt + 1, lowerLimit); p < upperLimit; p++) {
				if (!composite.Contains(p)) {
                    foundPrimes.Add(p);
				}
			}
        }

    }
}

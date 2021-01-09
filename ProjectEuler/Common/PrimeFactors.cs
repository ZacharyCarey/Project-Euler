using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		public static IEnumerable<int> PrimeFactors(this int n) {
            // Print the number of 2s that divide n 
            while (n % 2 == 0) {
                yield return 2;
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2) {
                // While i divides n, print i and divide n 
                while (n % i == 0) {
                    yield return i;
                    n /= i;
                }
            }

            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2)
                yield return n;
        }

        public static IEnumerable<BigInteger> PrimeFactors(this BigInteger n) {
            // Print the number of 2s that divide n 
            while (n % 2 == 0) {
                yield return 2;
                n >>= 1; //Optimized divide by 2
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            BigInteger sqrt = n.Sqrt();
            for (int i = 3; i <= sqrt; i += 2) {
                // While i divides n, print i and divide n 
                while (n % i == 0) {
                    yield return i;
                    n /= i;
                }
            }

            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2)
                yield return n;
        }

        public static IEnumerable<int> UniquePrimeFactors(this int n) {
            // Print the number of 2s that divide n 
            if ((n % 2) == 0) yield return 2;
            while (n % 2 == 0) {
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2) {
                // While i divides n, print i and divide n 
                if ((n % i) == 0) yield return i;
                while (n % i == 0) {
                    n /= i;
                }
            }

            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2)
                yield return n;
        }

        public static IEnumerable<BigInteger> UniquePrimeFactors(this BigInteger n) {
            // Print the number of 2s that divide n 
            if ((n % 2) == 0) yield return 2;
            while (n % 2 == 0) {
                n >>= 1; //Optimized divide by 2
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            BigInteger sqrt = n.Sqrt();
            for (int i = 3; i <= sqrt; i += 2) {
                // While i divides n, print i and divide n 
                if ((n % i) == 0) yield return i;
                while (n % i == 0) {
                    n /= i;
                }
            }

            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2)
                yield return n;
        }

    }
}

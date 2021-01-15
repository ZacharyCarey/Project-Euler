using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		/// <summary>
		/// Returns all possible divisors of a number. Not sorted.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static IEnumerable<long> Divisors(this long n) {
			for (long i = 1; i <= (long)Math.Sqrt(n); i++) {
				if ((n % i) == 0) {
					yield return i;
					yield return n / i;
				}
			}
		}

		/// <summary>
		/// Returns the number of divisors the number has.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static long NumberOfDivisors(this long n) {
			long count = 0;
			for (long i = 1; i <= (long)Math.Sqrt(n); i++) {
				if ((n % i) == 0) {
					count += 2;
				}
			}
			return count;
		}

	}
}

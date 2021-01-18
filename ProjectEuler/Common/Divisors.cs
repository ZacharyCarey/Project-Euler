using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		/// <summary>
		/// Returns all possible divisors of a number. Not sorted.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="skipN">Skip the last divisor that is also the number passes, n</param>
		/// <returns></returns>
		public static IEnumerable<int> Divisors(this int n, bool skipN = false) {
			yield return 1;
			if (!skipN) yield return n;
			for (int i = 2; i <= (int)Math.Sqrt(n); i++) {
				if ((n % i) == 0) {
					yield return i;
					yield return n / i;
				}
			}
		}

		/// <summary>
		/// Returns all possible divisors of a number. Not sorted.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="skipN">Skip the last divisor that is also the number passes, n</param>
		/// <returns></returns>
		public static IEnumerable<long> Divisors(this long n, bool skipN = false) {
			yield return 1;
			if (!skipN) yield return n;
			for (long i = 2; i <= (long)Math.Sqrt(n); i++) {
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
		/// <param name="skipN">Skip the last divisor that is also the number passes, n</param>
		/// <returns></returns>
		public static long NumberOfDivisors(this int n, bool skipN = false) {
			int count = (skipN ? 1 : 2);
			for (int i = 2; i <= (int)Math.Sqrt(n); i++) {
				if ((n % i) == 0) {
					count += 2;
				}
			}
			return count;
		}

		/// <summary>
		/// Returns the number of divisors the number has.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="skipN">Skip the last divisor that is also the number passes, n</param>
		/// <returns></returns>
		public static long NumberOfDivisors(this long n, bool skipN = false) {
			long count = (skipN ? 1 : 2);
			for (long i = 2; i <= (long)Math.Sqrt(n); i++) {
				if ((n % i) == 0) {
					count += 2;
				}
			}
			return count;
		}

	}
}

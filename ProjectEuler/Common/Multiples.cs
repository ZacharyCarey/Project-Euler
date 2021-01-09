using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		/// <summary>
		/// Returns all multiples of the number. !!WARNING!! This method will return infinitely if not stopped externally.
		/// </summary>
		/// <param name="number">The number to return multiples of.</param>
		/// <returns>All multiples of the given number, starting at that number.</returns>
		public static IEnumerable<int> Multiples(this int number) {
			int result = number;
			while (true) {
				yield return result;
				result += number;
			}
		}

		/// <summary>
		/// Returns all multiples of the number up to but not including the given limit.
		/// </summary>
		/// <param name="number">The number to return multiples of.</param>
		/// <param name="limit">The number that the multiples should not go above.</param>
		/// <returns>All multiples of the given number, starting at that number and stopping if the result equals or greater than the limit..</returns>
		public static IEnumerable<int> Multiples(this int number, int limit) {
			int result = number;
			while (result < limit) {
				yield return result;
				result += number;
			}
		}

	}
}

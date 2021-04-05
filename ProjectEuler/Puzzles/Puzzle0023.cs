using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=23</c>.
	/// </summary>
	sealed class Puzzle0023 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.";

		/// <inheritdoc/>
		public override object Solve() {
			int[] abundants = FindAbundantNumbers(28123).ToArray();
			HashSet<int> sums = new HashSet<int>();
			for(int i = 0; i < abundants.Length - 1; i++) {
				for(int j = i; j < abundants.Length; j++) {
					sums.Add(abundants[i] + abundants[j]);
				}
			}
			
			return Utils.Range(1, 28123).Where(x => !sums.Contains(x)).Sum();
		}

		public static IEnumerable<int> FindAbundantNumbers(int limit) {
			for(int n = 1; n <= limit; n++) {
				int divisorSum = n.Divisors(true).Sum();
				if(divisorSum > n) {
					yield return n;
				}
			}
		}
	}
}
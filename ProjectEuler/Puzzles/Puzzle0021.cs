using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=21</c>.
	/// </summary>
	sealed class Puzzle0021 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Evaluate the sum of all the amicable numbers under 10000.";

		/// <inheritdoc/>
		public override object Solve() {
			long sum = 0;
			for(int i = 1; i < 10000; i++) {
				if(isAmicable(i)) {
					sum += i;
				}
			}
			return sum;
		}

		private static bool isAmicable(int n) {
			int divisorSum = n.Divisors(true).Sum();
			return (n != divisorSum) && (divisorSum.Divisors(true).Sum() == n);
		}

	}
}
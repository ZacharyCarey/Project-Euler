using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=12</c>.
	/// </summary>
	sealed class Puzzle0012 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the value of the first triangle number to have over five hundred divisors?";

		/// <inheritdoc/>
		public override object Solve() {
			long triangle = 0;
			foreach(long natural in NaturalNumbers()) {
				triangle += natural;
				long numDivisors = triangle.NumberOfDivisors(); //getNumDivisors(triangle);
				if(numDivisors > 500) {
					return triangle;
				}
			}
			return null;
		}

		private static int getNumDivisors(int n) {
			int count = 0;
			for(int i = 1; i <= (int)Math.Sqrt(n); i++) {
				if((n % i) == 0) {
					count += 2;
				}
			}
			return count;
		}

		private static IEnumerable<long> NaturalNumbers() {
			long n = 1;
			while (true) {
				yield return n++;
			}
		}
	}
}
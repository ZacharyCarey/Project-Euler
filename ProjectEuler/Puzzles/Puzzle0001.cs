using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=1</c>.
	/// </summary>
	sealed class Puzzle0001 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the sum of all the multiples of 3 or 5 below 1000.";

		/// <inheritdoc/>
		public override object Solve() {
			IEnumerable<int> Multiples3 = 3.Multiples(1000);
			IEnumerable<int> Multiples5 = 5.Multiples(1000);
			return Multiples3.SortedUnion(Multiples5).Sum();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=6</c>.
	/// </summary>
	sealed class Puzzle0006 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";

		/// <inheritdoc/>
		public override object Solve() {
			int[] numbers = Enumerable.Range(1, 100).ToArray();
			return numbers.Combinations().Select(x => 2 * x.Item1 * x.Item2).Sum();
		}
	}
}
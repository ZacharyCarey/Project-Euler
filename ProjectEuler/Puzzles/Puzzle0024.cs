using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=24</c>.
	/// </summary>
	sealed class Puzzle0024 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?";

		/// <inheritdoc/>
		public override object Solve() {
			int[] elements = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int index = 1000000 - 1;
			return string.Join("", elements.LexicographicPermutationN(index));
		}
	}
}
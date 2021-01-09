using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=5</c>.
	/// </summary>
	sealed class Puzzle0005 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?";

		/// <inheritdoc/>
		public override object Solve() {
			return Utils.LCM(Enumerable.Range(1, 20).Select(x => (long)x));
		}
	}
}
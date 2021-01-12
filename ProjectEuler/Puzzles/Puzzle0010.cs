using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=10</c>.
	/// </summary>
	sealed class Puzzle0010 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the sum of all the primes below two million.";

		/// <inheritdoc/>
		public override object Solve() {
			return Utils.Primes.TakeWhile(x => x < 2000000).Sum();
		}
	}
}
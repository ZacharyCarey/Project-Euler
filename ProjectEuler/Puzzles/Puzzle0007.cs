using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=7</c>.
	/// </summary>
	sealed class Puzzle0007 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the 10 001st prime number?";

		/// <inheritdoc/>
		public override object Solve() {
			return Utils.Primes().ElementAt(10000);
		}
	}
}
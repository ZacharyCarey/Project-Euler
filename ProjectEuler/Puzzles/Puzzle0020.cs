using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=20</c>.
	/// </summary>
	sealed class Puzzle0020 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the sum of the digits in the number 100!";

		/// <inheritdoc/>
		public override object Solve() {
			BigInteger factorial = Utils.Factorial(100);
			return factorial.Digits().Sum();
		}

	}
}
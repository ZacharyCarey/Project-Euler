using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=13</c>.
	/// </summary>
	sealed class Puzzle0013 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.";

		/// <inheritdoc/>
		public override object Solve() {
			BigInteger result = base.ReadResourceLines().Select(x => BigInteger.Parse(x)).Sum();
			return new string(result.ToString().Take(10).ToArray());
		}
	}
}
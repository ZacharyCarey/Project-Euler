using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=3</c>.
	/// </summary>
	sealed class Puzzle0003 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the largest prime factor of the number 600851475143 ?";

		/// <inheritdoc/>
		public override object Solve() {
			return BigInteger.Parse("600851475143").PrimeFactors().Max();
		}
	}
}
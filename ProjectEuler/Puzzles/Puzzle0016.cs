using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=16</c>.
	/// </summary>
	sealed class Puzzle0016 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the sum of the digits of the number 2^1000?";

		/// <inheritdoc/>
		public override object Solve() {
			BigInteger base2 = new BigInteger(2);
			BigInteger result = BigInteger.One;
			for(int exp = 0; exp < 1000; exp++) {
				result *= base2;
			}
			
			return result.ToString().Select(x => x - '0').Sum();
		}
	}
}
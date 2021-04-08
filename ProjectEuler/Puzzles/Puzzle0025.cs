using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=25</c>.
	/// </summary>
	sealed class Puzzle0025 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the index of the first term in the Fibonacci sequence to contain 1000 digits?";

		/// <inheritdoc/>
		public override object Solve() {
			BigInteger oneThousandDigits = BigInteger.One;
			for(int i = 0; i < 999; i++) {
				//Add 999 zeros to create the first 1000 digit number
				oneThousandDigits *= 10;
			}

			return Utils.BigFibonacci().WithIndex().Where(x => x.Element >= oneThousandDigits).First().Index + 1;
		}
	}
}
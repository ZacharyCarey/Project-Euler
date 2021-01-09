using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=2</c>.
	/// </summary>
	sealed class Puzzle0002 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";

		/// <inheritdoc/>
		public override object Solve() {
			return Utils.Fibonacci().TakeWhile(x => x <= 4000000).Where(x => (x % 2) == 0).Sum();
		}
	}
}
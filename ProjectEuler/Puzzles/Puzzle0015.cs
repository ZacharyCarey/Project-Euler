using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=15</c>.
	/// </summary>
	sealed class Puzzle0015 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "How many such routes are there through a 20×20 grid?";

		/// <inheritdoc/>
		public override object Solve() {
			return Utils.Ck(40, 20);
		}
	}
}
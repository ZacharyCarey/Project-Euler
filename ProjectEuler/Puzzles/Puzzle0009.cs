using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=9</c>.
	/// </summary>
	sealed class Puzzle0009 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.";

		/// <inheritdoc/>
		public override object Solve() {
			for(int a = 1; a <= 999; a++) {
				for(int b = 1; b <= 1000 - a; b++) {
					int c = 1000 - a - b;
					if(a * a + b * b == c * c) {
						return a * b * c;
					}
				}
			}

			return "null";
		}
	}
}
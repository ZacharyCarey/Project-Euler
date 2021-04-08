using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=26</c>.
	/// </summary>
	sealed class Puzzle0026 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.";

		/// <inheritdoc/>
		public override object Solve() {
			//Lots of info was learned from Eli Bendersky's website - see Math Docs

			//"To find the longest cycle it's sufficient to look just at the primes - because other numbers will just have the same cycles after some initial non-repetitive section."
			int maxLen = 0;
			int maxN = 0;
			foreach(int prime in Utils.Primes.TakeWhile(x => x < 1000)) {
				int rest = 1;
				for(int i = 0; i < prime; i++) {
					rest = (rest * 10) % prime;
				}

				int r0 = rest;
				int len = 0;
				do {
					rest = (rest * 10) % prime;
					len++;
				} while (rest != r0);

				if(len > maxLen) {
					maxLen = len;
					maxN = prime;
				}
			}

			return maxN;
		}
	}
}
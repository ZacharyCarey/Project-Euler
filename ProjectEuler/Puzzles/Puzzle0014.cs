using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=14</c>.
	/// </summary>
	sealed class Puzzle0014 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Which starting number, under one million, produces the longest chain?";

		/// <inheritdoc/>
		public override object Solve() {
			int bestStart = 0;
			int longestChain = 0;
			for(int i = 1; i < 1000000; i++) {
				int count = CollatzSequenceCount(i);
				if(count > longestChain) {
					bestStart = i;
					longestChain = count;
				}
			}

			return bestStart;
		}

		//Initialize 1 as a 'base case'
		private Dictionary<long, int> counts = new Dictionary<long, int>() { { 1, 1 } };
	
		private int CollatzSequenceCount(long n) {
			//Speed up calculation by using previously calculated values
			int count;
			if(counts.TryGetValue(n, out count)) {
				return count;
			} else {
				if(n % 2 == 0) {
					count = CollatzSequenceCount(n / 2) + 1;
				} else {
					count = CollatzSequenceCount(n * 3 + 1) + 1;
				}
				counts[n] = count;
				return count;
			}
		}

	}
}
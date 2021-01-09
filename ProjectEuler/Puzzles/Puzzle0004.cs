using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=4</c>.
	/// </summary>
	sealed class Puzzle0004 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the largest palindrome made from the product of two 3-digit numbers.";

		/// <inheritdoc/>
		public override object Solve() {
			int palindrome = 0;
			for(int i = 999; i > 0; i--) {
				for(int j = 999; j > 0; j--) {
					int result = i * j;
					if(result > palindrome) {
						string str = result.ToString();
						int n = str.Length / 2;
						if(str.Take(n).SequenceEqual(str.Reverse().Take(n))) {
							palindrome = result;
						}
					}
				}
			}
			return palindrome;
		}
	}
}
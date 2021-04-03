using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=22</c>.
	/// </summary>
	sealed class Puzzle0022 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the total of all the name scores in the file?";

		/// <inheritdoc/>
		public override object Solve() {
			IEnumerable<string> namesFile = base.ReadResourceLines().GetElements(',').Select(x => x.Trim('\"'));
			string[] names = namesFile.ToArray();
			Array.Sort(names);
			long sum = 0;
			for(int i = 0; i < names.Length; i++) {
				int pos = i + 1;
				sum += pos * NameValue(names[i]);
			}
			return sum;
		}

		private static long NameValue(string name) {
			return name.Select(c => (int)(c - 'A') + 1).Sum();
		} 
	}
}
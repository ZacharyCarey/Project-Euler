using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=19</c>.
	/// </summary>
	sealed class Puzzle0019 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";

		/// <inheritdoc/>
		public override object Solve() {
			int sundays = 0;
			DateTime date = new DateTime(1901, 1, 1);
			while(date.Year <= 2000) {
				for(int i = 0; i < 12; i++) {
					if (date.DayOfWeek == DayOfWeek.Sunday) {
						sundays++;
					}
					date = date.AddMonths(1);
				}
			}

			return sundays;
		}
	}
}
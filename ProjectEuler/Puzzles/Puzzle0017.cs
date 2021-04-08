using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=17</c>.
	/// </summary>
	sealed class Puzzle0017 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?";

		//Letter counts for different words
		static readonly int[] ONES = {
			0, //ZERO
			3, //ONE
			3, //TWO
			5, //THREE
			4, //FOUR
			4, //FIVE
			3, //SIX
			5, //SEVEN
			5, //EIGHT
			4, //NINE
			3, //TEN
			6, //ELEVEN
			6, //TWELVE
			8, //THIRTEEN
			8, //FOURTEEN
			7, //FIFTEEN
			7, //SIXTEEN
			9, //SEVENTEEN
			8, //EIGHTEEN
			8  //NINETEEN
		};

		//Letter counts for tens digits
		static readonly int[] TENS = {
			4, //ZERO
			3, //TEN
			6, //TWENTY
			6, //THIRTY
			5, //FOURTY
			5, //FIFTY
			5, //SIXTY
			7, //SEVENTY
			6, //EIGHTY
			6  //NINETY
		};

		const int HUNDRED = 7;
		const int AND = 3;
		const int THOUSAND = 8;

		/// <inheritdoc/>
		public override object Solve() {
			int count = 0;

			//Handle 1-9
			int ones = 0;
			for(int i = 1; i <= 9; i++) {
				ones += ONES[i];
			}
			count += ones;

			//Handle 10-19
			int teens = 0;
			for(int i = 10; i <= 19; i++) {
				teens += ONES[i];
			}
			count += teens;

			//Handle 20-99
			int tens = 0;
			for(int i = 2; i <= 9; i++) {
				tens += TENS[i] * 10 + ones;
			}
			count += tens;

			//Handle 100-999
			for(int i = 1; i <= 9; i++) {
				count += (ONES[i] + HUNDRED) * 100
					+ AND * 99
					+ ones + teens + tens;
			}

			return count + ONES[1] + THOUSAND;
		}

	}
}
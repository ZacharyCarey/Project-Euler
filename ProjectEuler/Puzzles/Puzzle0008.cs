using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=8</c>.
	/// </summary>
	sealed class Puzzle0008 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?";

		/// <inheritdoc/>
		public override object Solve() {
			IEnumerable<int> Digits = ReadResourceLines().SelectMany(line => line.AsEnumerable()).Select(c => c - '0');
			Queue<int> digitQueue = new Queue<int>();
			long largestProduct = 0;
			long currentProduct = 1;

			//Initialize with the first 13 digits
			foreach(int digit in Digits.Take(13)) {
				digitQueue.Enqueue(digit);
				currentProduct *= digit;
			}
			largestProduct = currentProduct;

			//Check the rest of the data
			foreach(int digit in Digits.Skip(13)) {
				int dropDigit = digitQueue.Dequeue();
				if(dropDigit == 0) {
					currentProduct = digitQueue.Aggregate((x, y) => x * y);
				} else {
					currentProduct /= dropDigit;
				}
				
				currentProduct *= digit;
				digitQueue.Enqueue(digit);
				largestProduct = Math.Max(largestProduct, currentProduct);
			}

			return largestProduct;
		}
	}
}
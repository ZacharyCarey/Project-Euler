using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=11</c>.
	/// </summary>
	sealed class Puzzle0011 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?";

		/// <inheritdoc/>
		public override object Solve() {
			int[,] data = new int[20, 20];
			foreach(var y in ReadResourceLines().WithIndex()) {
				foreach(var x in y.Element.Split().Select(int.Parse).WithIndex()) {
					data[x.Index, y.Index] = x.Element;
				}
			}

			int largest = 0;
			for(int y = 0; y < 20; y++) {
				for(int x = 0; x < 20; x++) {
					//Check right
					bool isRight = (x <= 16);
					if (isRight) {
						largest = Math.Max(largest, getProduct(data, x, y, 1, 0));
					}

					//Check down
					bool isDown = (y <= 16);
					if (isDown) {
						largest = Math.Max(largest, getProduct(data, x, y, 0, 1));
					}

					//Check diagonally right
					if(isRight && isDown) {
						largest = Math.Max(largest, getProduct(data, x, y, 1, 1));
					}

					//Check diagonally left
					bool isLeft = (x >= 3);
					if(isLeft && isDown) {
						largest = Math.Max(largest, getProduct(data, x, y, -1, 1));
					}
				}
			}
			
			return largest;
		}

		private static int getProduct(int[,] data, int x, int y, int dx, int dy) {
			int product = data[x, y];
			for(int i = 0; i < 3; i++) {
				x += dx;
				y += dy;
				product *= data[x, y];
			}
			return product;
		}
	}
}
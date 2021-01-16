using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ProjectEuler.Common;

namespace ProjectEuler.Puzzles {

	/// <summary>
	/// A class representing the solution to <c>https://projecteuler.net/problem=18</c>.
	/// </summary>
	sealed class Puzzle0018 : Puzzle {

		/// <inheritdoc/>
		public override string Question => "Find the maximum total from top to bottom of the triangle below:";

		int[][] triangle;

		/// <inheritdoc/>
		public override object Solve() {
			loadData();
			return findMax(0, 0);
		}

		private int findMax(int x, int y) {
			//Base cases
			if (y >= triangle.Length) return 0;
			if (x >= triangle[y].Length) return 0;

			int left = findMax(x, y + 1);
			int right = findMax(x + 1, y + 1);
			return triangle[y][x] + Math.Max(left, right);
		}

		private void loadData() {
			List<int[]> data = new List<int[]>();

			foreach(string line in ReadResourceLines()) {
				data.Add(line.Trim().Split().Select(int.Parse).ToArray());
			}

			triangle = data.ToArray();
		}
	}
}
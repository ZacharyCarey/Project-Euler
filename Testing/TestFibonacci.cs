using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testing {
	static class TestFibonacci {

		public static void Test() {
			IEnumerable<int> result = Fibonacci.Generate();

			Console.WriteLine("Expected: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89");
			Console.WriteLine("Actual  : {0}", string.Join(", ", result.Take(10)));
		}

	}
}

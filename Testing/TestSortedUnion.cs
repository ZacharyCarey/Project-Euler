using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing {
	static class TestSortedUnion {

		public static void Test() {
			IEnumerable<int> source1 = new int[] { 1, 2, 3, 7, 8, 9 };
			IEnumerable<int> source2 = new int[] { 1, 3, 5, 6, 7};
			IEnumerable<int> result = source1.SortedUnion(source2);

			Console.WriteLine("Source 1: {0}", string.Join(", ", source1));
			Console.WriteLine("Source 2: {0}", string.Join(", ", source2));
			Console.WriteLine("Expected: 1, 2, 3, 5, 6, 7, 8, 9");
			Console.WriteLine("Actual  : {0}", string.Join(", ", result));
		}

	}
}

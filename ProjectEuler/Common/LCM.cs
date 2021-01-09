using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Common {
	public static partial class Utils {

		public static long LCM(IEnumerable<long> numbers) {
			return numbers.Aggregate(LCM);
		}

		public static long LCM(long a, long b) {
			return Math.Abs(a * b) / GCD(a, b);
		}

	}
}

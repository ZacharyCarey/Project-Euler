using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		public static BigInteger Factorial(long n) {
			BigInteger result = BigInteger.One;
			for (long i = 2; i <= n; i++) {
				result *= i;
			}
			return result;
		}

	}
}

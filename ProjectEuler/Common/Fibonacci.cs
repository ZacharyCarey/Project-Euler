using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		/// <summary>
		/// Generates the fibonacci sequence starting with 1 then 2. !!Warning!! generates infinitely unless stopped externally.
		/// </summary>
		/// <returns>Fibonacci 1, 2, 3, 5, 8, 13, 21, etc.</returns>
		public static IEnumerable<int> Fibonacci() {
			yield return 1;

			int num1 = 0;
			int num2 = 1;
			while (true) {
				num1 += num2;
				yield return num1;
				num2 += num1;
				yield return num2;
			}
		}

		/// <summary>
		/// Generates the fibonacci sequence starting with 1 then 2. !!Warning!! generates infinitely unless stopped externally.
		/// </summary>
		/// <returns>Fibonacci 1, 2, 3, 5, 8, 13, 21, etc.</returns>
		public static IEnumerable<BigInteger> BigFibonacci() {
			yield return BigInteger.One;

			BigInteger num1 = BigInteger.Zero;
			BigInteger num2 = BigInteger.One;
			while (true) {
				num1 += num2;
				yield return num1;
				num2 += num1;
				yield return num2;
			}
		}
		
		//TODO create a generator that stores previous values for fast access
	}
}

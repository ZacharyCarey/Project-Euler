using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		/// <summary>
		/// Returns digits from LSD (least significant) to GSD (greatest significant)
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static IEnumerable<int> Digits(this long n) {
			while (n > 0) {
				yield return (int)(n % 10);
				n /= 10;
			}
		}

		/// <summary>
		/// Returns digits from LSD (least significant) to GSD (greatest significant)
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static IEnumerable<int> Digits(this BigInteger n) {
			while (n > 0) {
				yield return (int)(n % 10);
				n /= 10;
			}
		}

		/*
				public static long SumDigits(this long n) {
					int sum = 0;
					while (n > 0) {
						sum += (int)(n % 10);
						n /= 10;
					}
					return sum;
				}

				public static long SumDigits(this BigInteger n) {
					int sum = 0;
					while (n > 0) {
						sum += (int)(n % 10);
						n /= 10;
					}
					return sum;
				}
		*/
	}
}

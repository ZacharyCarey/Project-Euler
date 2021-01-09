using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		public static long GCD(long a, long b) {
			return b == 0 ? a : GCD(b, a % b);
		}

	}
}

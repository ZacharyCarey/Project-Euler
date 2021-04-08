using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public partial class Utils {

		public static IEnumerable<int> Coprime10() {
			//We check for i > 0 so we can detect when the overflow happens to allow the generator to go all the way up to int.MaxValue
			for(int i = 3; i > 0; i+=2) {
				if(i % 5 != 0) {
					yield return i;
				}
			}
		}

		public static bool IsCoprime10(this int n) {
			if (n < 2) return false;
			if (n % 2 == 0) return false;
			if (n % 5 == 0) return false;

			return true;
		}

	}
}

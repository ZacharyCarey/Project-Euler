using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

        public static IEnumerable<int> Range(int start, int stop) {
            while (start <= stop) {
                yield return start;
                start++;
            }
        }

        public static IEnumerable<long> Range(long start, long stop) {
           while(start <= stop) {
                yield return start;
                start++;
			}
        }

    }
}

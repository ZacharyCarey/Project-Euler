using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

        //K = number of elements in the combination (i.e. elements={1, 2, 3, 4}, k=3 returns (1,2,3),(1,2,4),(1,3,4) etc
        public static IEnumerable<(T, T)> Combinations<T>(this T[] elements) {
            for(int i = 0; i < elements.Length - 1; i++) {
                for(int j = i + 1; j < elements.Length; j++) {
                    yield return (elements[i], elements[j]);
				}
			}
        }

        //With n number of elements return the number of different combinations that can be made
        //For example: n = 4 [1, 2, 3, 4]
        //Would return 15
        // 1, 2, 3, 4
        // 12, 13, 14
        // 23, 24
        // 34
        // 123, 124, 134
        // 234
        // 1234
        public static int NumberOfCombinations(int numberOfElements) {
            return (numberOfElements * numberOfElements) - 1;
		}

        public static long Ck(long n, long k) {
            long r = 1;
            if (k > n) return 0;
            for(int d = 1; d <= k; d++) {
                r *= n--;
                r /= d;
			}
            return r;
		}

    }
}

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

    }
}

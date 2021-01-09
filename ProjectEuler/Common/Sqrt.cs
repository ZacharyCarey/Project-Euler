using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

        public static BigInteger Sqrt(this BigInteger N) {
            BigInteger G = new BigInteger((int)(N >> ((N.GetByteCount() * 8 + 1) / 2)));
            BigInteger LastG = BigInteger.Zero;
            BigInteger One = BigInteger.One;

            while (true) {
                LastG = G;
                G = (N / G + G) >> 1;

                int i = G.CompareTo(LastG);

                if (i == 0) return G;

                if (i < 0) {
                    if ((LastG - G).CompareTo(One) == 0)
                        if ((G * G).CompareTo(N) < 0 && (LastG * LastG).CompareTo(N) > 0) return G;
                } else {
                    if ((G - LastG).CompareTo(One) == 0)
                        if ((LastG * LastG).CompareTo(N) < 0 && (G * G).CompareTo(N) > 0) return LastG;
                }

            }

        }

    }
}

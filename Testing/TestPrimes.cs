using ProjectEuler.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Testing {
	static class TestPrimes {
	
		public static void Test() {
			int n = 180;
			Stopwatch timer = new Stopwatch();
			/*
			timer.Start();
			List<int> primes = Utils.GeneratePrimes(n);
			timer.Stop();
			Console.WriteLine("First: {0} s", timer.Elapsed.TotalSeconds);
			Console.WriteLine(string.Join(", ", primes));*/
			/*
			primes = new List<int>(n);
			timer.Restart();
			primes.AddRange(Utils.GeneratePrimes().Take(n));
			timer.Stop();
			Console.WriteLine("Second: {0} s", timer.Elapsed.TotalSeconds);
			Console.WriteLine(string.Join(", ", primes));
			*/
			//List<int> primes;
			//timer.Restart();
			//primes = SieveOfErathostenes(n).ToList();
			//timer.Stop();
			//Console.WriteLine("Third: {0} s", timer.Elapsed.TotalSeconds);
			Console.WriteLine(string.Join(", ", Utils.Primes().Take(n)));
		}

		private static IEnumerable<int> SieveOfErathostenes(int upperLimit) {
			//BitArray works just like a bool[] but takes up a lot less space.
			//BitArray composite = new BitArray(upperLimit);
			HashSet<int> composite = new HashSet<int>();

			//Only need to cross off numbers up to sqrt.
			int sqrt = (int)Math.Sqrt(upperLimit);
			for (int p = 2; p <= sqrt; ++p) {
				if (composite.Contains(p)) continue; //The number is crossed off; skip it

				yield return p; //Not crossed off means it's prime. Return it.

				//Cross off each multiple of this prime
				//Start at the prime squared, because lower numbers will
				//have been crossed off already. No need to check them.
				for (int i = p * p; i < upperLimit; i += p)
					composite.Add(i);
			}
			//The remaining numbers not crossed off are also prime.
			for (int p = sqrt + 1; p < upperLimit; ++p) {
				if (!composite.Contains(p)) yield return p;
			}
		}

	}
}

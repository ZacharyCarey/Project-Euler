using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Common {
	public static class Utils {

		/// <summary>
		/// Returns all multiples of the number. !!WARNING!! This method will return infinitely if not stopped externally.
		/// </summary>
		/// <param name="number">The number to return multiples of.</param>
		/// <returns>All multiples of the given number, starting at that number.</returns>
		public static IEnumerable<int> Multiples(this int number) {
			int result = number;
			while (true) {
				yield return result;
				result += number;
			}
		}

		/// <summary>
		/// Returns all multiples of the number up to but not including the given limit.
		/// </summary>
		/// <param name="number">The number to return multiples of.</param>
		/// <param name="limit">The number that the multiples should not go above.</param>
		/// <returns>All multiples of the given number, starting at that number and stopping if the result equals or greater than the limit..</returns>
		public static IEnumerable<int> Multiples(this int number, int limit) {
			int result = number;
			while (result < limit) {
				yield return result;
				result += number;
			}
		}

		/// <summary>
		/// A fast union method that only works if both lists are unique values sorted in ascending order.
		/// </summary>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <returns>Only the elements present in both lists</returns>
		public static IEnumerable<T> SortedUnion<T>(this IEnumerable<T> source1, IEnumerable<T> source2, IComparer<T> comparer = null) {
			if (comparer == null) {
				comparer = Comparer<T>.Default;
			}

			IEnumerator<T> enum1 = source1.GetEnumerator();
			IEnumerator<T> enum2 = source2.GetEnumerator();

			//bool

			//Both must have at least 1 element to continue
			if(enum1.MoveNext() && enum2.MoveNext()) {
				//Keep returning elements until we run out
				while (true) {
					int compare = comparer.Compare(enum1.Current, enum2.Current);
					T result = (compare <= 0) ? enum1.Current : enum2.Current;
					yield return result;
					while(comparer.Compare(enum1.Current, result) == 0) {
						if (!enum1.MoveNext()) {
							//Add remaining elements from enum2 and exit
							while (comparer.Compare(enum2.Current, result) == 0) {
								if (!enum2.MoveNext()) {
									yield break;
								}
							}
							do {
								yield return enum2.Current;
							} while (enum2.MoveNext());
							yield break;
						}
					}
					while(comparer.Compare(enum2.Current, result) == 0) {
						if (!enum2.MoveNext()) {
							//Add remaining elements from enum1 and exit
							while (comparer.Compare(enum1.Current, result) == 0) {
								if (!enum1.MoveNext()) {
									yield break;
								}
							}
							do {
								yield return enum1.Current;
							} while (enum1.MoveNext());
							yield break;
						}
					}
					/*if (compare == 0) {
						//Both match!
						T result = enum1.Current;
						yield return result;
						do {
							if (!enum1.MoveNext()) {
								yield break;
							}
						} while (comparer.Compare(enum1.Current, result) == 0);
						do {
							if (!enum2.MoveNext()) {
								yield break;
							}
						} while (comparer.Compare(enum2.Current, result) == 0);
					} else {
						if (compare < 0) {
							if (!enum1.MoveNext()) {
								yield break;
							}
						} else {
							if (!enum1.MoveNext()) {
								yield break;
							}
						}
					}*/
				}
			} 
		}

	}
}

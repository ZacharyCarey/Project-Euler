using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Common {
	public static partial class Utils {

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
				}
			} 
		}

		/// <summary>
		/// Returns the lines of strings that are separated by a blank line (text blocks)
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<IEnumerable<string>> GetGroups(this IEnumerable<string> source) {
			List<string> group = new List<string>();
			foreach (string line in source) {
				if (!string.IsNullOrWhiteSpace(line)) {
					group.Add(line);
				} else {
					yield return group;
					group.Clear();
				}
			}

			if (group.Count > 0) {
				yield return group;
			}
		}

		/// <summary>
		/// Gets all string elements separated by either space or newlines
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetElements(this IEnumerable<string> source) {
			foreach (string line in source) {
				string[] elements = line.Split();
				foreach (string element in elements) {
					yield return element;
				}
			}
		}

		/// <summary>
		/// Gets all string elements separated by the given deliminator
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetElements(this IEnumerable<string> source, char delim) {
			foreach (string line in source) {
				string[] elements = line.Split(delim);
				foreach (string element in elements) {
					yield return element;
				}
			}
		}

		/// <summary>
		/// Gets all string elements separated by the given deliminator
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetElements(this IEnumerable<string> source, string delim) {
			foreach (string line in source) {
				string[] elements = line.Split(delim);
				foreach (string element in elements) {
					yield return element;
				}
			}
		}

		public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T newElement) {
			if (source == null) throw new ArgumentNullException("source", "Enumberable was null.");
			foreach (T element in source) yield return element;
			yield return newElement;
		}

		public static IEnumerable<int> Indices(this Array source) {
			for (int i = 0; i < source.Length; i++) {
				yield return i;
			}
		}

		/*public static IEnumerable<T> Values<T>(this T[] source) {
			for (int y = 0; y < source.GetLength(1); y++) {
				for (int x = 0; x < source.GetLength(0); x++) {
					yield return source[x, y];
				}
			}
		}*/

		public static IEnumerable<(int Index, T Element)> WithIndex<T>(this IEnumerable<T> source) {
			int index = 0;
			foreach (T element in source) {
				yield return (index++, element);
			}
		}

		public static BigInteger Sum(this IEnumerable<BigInteger> source) {
			BigInteger result = BigInteger.Zero;
			foreach(BigInteger element in source) {
				result += element;
			}
			return result;
		}

	}
}

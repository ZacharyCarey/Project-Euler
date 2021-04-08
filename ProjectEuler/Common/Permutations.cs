using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ProjectEuler.Common {
	public static partial class Utils {

		/*
         * A permutation is an ordered arrangement of objects.
         * e.x:
         * 0 1 2
         * 0 2 1
         * 1 0 2
         * 1 2 0
         * 2 0 1
         * 2 1 0
         */

		#region Interfaces
		public interface Swapable<T> : IComparer<T> {

			int ElementCount { get; }

			void Swap(int i, int j);

			T ElementAt(int index);

            /// <summary>
            /// Only used for Lexicographical permutation, so if not being used can be left empty.
            /// </summary>
            void Sort();

		}

        private class MethodComparer<T> : IComparer<T> {

            private Func<T, T, int> func;

            public MethodComparer(Func<T, T, int> staticFunc) {
                this.func = staticFunc;
			}

			public int Compare([AllowNull] T x, [AllowNull] T y) {
                return func(x, y);
			}
		}

		public struct SwapableArray<T> : Swapable<T>, IEnumerable<T> {

            public readonly T[] Array;
            private IComparer<T> Comparer; 

			public int ElementCount => Array.Length;

			public SwapableArray(T[] array, IComparer<T> comparer = null) {
                this.Array = array;
                Comparer = comparer ?? Comparer<T>.Default;
			}

            public SwapableArray(T[] array, Func<T, T, int> comparer) {
                this.Array = array;
                Comparer = new MethodComparer<T>(comparer);
            }

            public void Swap(int i, int j) {
                T temp = Array[i];
                Array[i] = Array[j];
                Array[j] = temp;
			}

            public IEnumerator<T> GetEnumerator() {
                return ((IEnumerable<T>)Array).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
				return Array.GetEnumerator();
			}

			public int Compare([AllowNull] T x, [AllowNull] T y) {
                return Comparer.Compare(x, y);
			}

			public T ElementAt(int index) {
                return Array[index];
			}

            public void Sort() {
                System.Array.Sort<T>(Array, this);
            }
		}
		public struct SwapableList<T> : Swapable<T>, IEnumerable<T> {
            public readonly List<T> List;
            private IComparer<T> Comparer;

            public int ElementCount => List.Count;

            public SwapableList(List<T> list, IComparer<T> comparer = null) {
                this.List = list;
                Comparer = comparer ?? Comparer<T>.Default;
            }

            public SwapableList(List<T> list, Func<T, T, int> comparer) {
                this.List = list;
                Comparer = new MethodComparer<T>(comparer);
            }

            public void Swap(int i, int j) {
                T temp = List[i];
                List[i] = List[j];
                List[j] = temp;
            }

            public IEnumerator<T> GetEnumerator() {
                return ((IEnumerable<T>)List).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return List.GetEnumerator();
            }

            public int Compare([AllowNull] T x, [AllowNull] T y) {
                return Comparer.Compare(x, y);
            }

            public T ElementAt(int index) {
                return List[index];
            }

            public void Sort() {
                List.Sort(this);
            }
        }
		#endregion

		#region Regular Permutations
		public static IEnumerable<T[]> Permutations<T>(this T[] items) => Permutations(new SwapableArray<T>(items)).Select(x => ((SwapableArray<T>)x).Array);
        public static IEnumerable<List<T>> Permutations<T>(this List<T> items) => Permutations(new SwapableList<T>(items)).Select(x => ((SwapableList<T>)x).List);

        public static IEnumerable<Swapable<T>> Permutations<T>(Swapable<T> items) {
            return Permutate(items, items.ElementCount);
        }

        private static IEnumerable<Swapable<T>> Permutate<T>(Swapable<T> items, int depth) {
            if(depth == 1) {
                yield return items;
            } else {
                foreach(Swapable<T> perm in Permutate(items, depth - 1)) {
                    yield return perm;
				}

                for (int i = 0; i < depth - 1; i++) {
                    items.Swap((depth % 2 == 0) ? i : 0, depth - 1);
                    foreach (Swapable<T> perm in Permutate(items, depth - 1)) {
                        yield return perm;
                    }
                }
            }
        }
		#endregion

		#region Lexicographic Permutations
		public static IEnumerable<T[]> LexicographicPermutations<T>(this T[] items) => LexicographicPermutations(new SwapableArray<T>(items)).Select(x => ((SwapableArray<T>)x).Array);
        public static IEnumerable<List<T>> LexicographicPermutations<T>(this List<T> items) => LexicographicPermutations(new SwapableList<T>(items)).Select(x => ((SwapableList<T>)x).List);
        public static IEnumerable<Swapable<T>> LexicographicPermutations<T>(Swapable<T> items) {
            items.Sort();

            while (true) {
                yield return items;

                //Find the rightmost item which is smaller than its next item. We will call this the "first item"
                int i;
                for(i = items.ElementCount - 2; i >= 0; i--) {
                    if (items.Compare(items.ElementAt(i), items.ElementAt(i + 1)) < 0) {
                        break;
					}
				}

                //If there is no such character, all are sorted which means we just printed the last permutation
                if(i == -1) {
                    yield break;
				} else {
                    //Find the ceil of the "first item" to the right
                    //The ceil is the smallest item greater than it
                    int ceilIndex = findCeil(items, items.ElementAt(i), i + 1, items.ElementCount - 1);
                    items.Swap(i, ceilIndex);
                    reverse(items, i + 1, items.ElementCount - i - 1);
				}

			}
        }

        // Find the index of the smalled element which is greater than 'current' and is present in the range [L..H]
        private static int findCeil<T>(Swapable<T> items, T current, int L, int H) {
            int ceilIndex = L;
            T ceilElement = items.ElementAt(L);
            for (int i = L + 1; i <= H; i++) {
                T element = items.ElementAt(i);
                if (items.Compare(element, current) > 0 && items.Compare(element, ceilElement) < 0) {
                    ceilIndex = i;
                    ceilElement = element;
                }
            }

            return ceilIndex;
        }

        private static void reverse<T>(Swapable<T> items, int index, int count) {
            int indexStop = index + count - 1;
            for(int i = 0; i < count / 2; i++) {
                items.Swap(index + i, indexStop - i);
			}
		}


        public static T[] LexicographicPermutationN<T>(this T[] items, int n) => ((SwapableArray<T>)LexicographicPermutationN(new SwapableArray<T>(items), n)).Array;
        public static List<T> LexicographicPermutationN<T>(this List<T> items, int n) => ((SwapableList<T>)LexicographicPermutationN(new SwapableList<T>(items), n)).List;
        public static Swapable<T> LexicographicPermutationN<T>(Swapable<T> items, int n) {
            items.Sort();
            PermutateN(items, n, 1, 1);
            return items;
		}

        private static int PermutateN<T>(Swapable<T> items, int n, int factorial, int depth) {
            factorial *= depth;
            if (depth + 1 < items.ElementCount) {
                // Subtract the returned offset
                n = PermutateN(items, n, factorial, depth + 1);
            }

            int index = n / factorial;
            int targetIndex = items.ElementCount - depth - 1;
            Bubble(items, targetIndex + index, targetIndex);

            return n % factorial; // The n offset for the previous depth
		}

        //Probably inefficient way to move items but we will keep it for now
        private static void Bubble<T>(Swapable<T> items, int index, int targetIndex) {
            while (index > targetIndex){
                items.Swap(index, index - 1);
                index--;
			}

            while(index < targetIndex) {
                items.Swap(index, index + 1);
                index++;
			}
		}
		#endregion

	}
}

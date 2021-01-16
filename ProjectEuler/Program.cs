using ProjectEuler.Puzzles;
using System;
using System.Diagnostics;

namespace ProjectEuler {
	class Program {

		static void Main(string[] args) {
			Puzzle CurrentPuzzle = new Puzzle0018();

			if (!Debugger.IsAttached) {
				CurrentPuzzle = null;
				while (CurrentPuzzle == null) {
					Console.Write("Which puzzle would you like to run? ");
					string input = Console.ReadLine();
					int puzzleID;
					if(!int.TryParse(input, out puzzleID)) {
						Console.Clear();
						Console.WriteLine("Invalid number.");
						continue;
					}
					CurrentPuzzle = GetPuzzle(puzzleID);
					if(CurrentPuzzle == null) {
						Console.Clear();
						Console.WriteLine("Invalid puzzle number.");
						continue;
					}
				}
			}

			SolvePuzzle(CurrentPuzzle);
			Console.Write("Press any key to continue...");
			Console.ReadKey();
		}

		static void SolvePuzzle(Puzzle puzzle) {
			Console.Clear();
			Console.WriteLine("Project Euler - Puzzle {0}", puzzle.GetType().Name.Replace("Puzzle", "").TrimStart('0'));
			Console.WriteLine();

			Console.WriteLine(puzzle.Question);

			Stopwatch stopwatch = Stopwatch.StartNew();
			object result = puzzle.Solve();
			stopwatch.Stop();

			Console.WriteLine();
			Console.WriteLine("Answer: {0}", result);
			Console.WriteLine();

			if (stopwatch.Elapsed.TotalMilliseconds < 1f) {
				Console.WriteLine("Took <1 millisecond.");
			} else {
				Console.WriteLine("Took {0:g} [d:hh:mm:ss.FF].", stopwatch.Elapsed.TotalSeconds);
			}

			Console.WriteLine();
		}

		static Puzzle GetPuzzle(int number) {
			string typeName = string.Format("Puzzle{0:0000}", number);
			Type puzzleType = Type.GetType(typeName);

			if (puzzleType != null) {
				return Activator.CreateInstance(puzzleType) as Puzzle;
			} else {
				return null;
			}
		}

	}
}

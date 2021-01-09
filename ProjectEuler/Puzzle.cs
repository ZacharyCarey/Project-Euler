using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectEuler {

	/// <summary>
	/// Base class for a puzzle
	/// </summary>
	abstract class Puzzle {

		/// <summary>
		/// Gets the text of the puzzle's question.
		/// </summary>
		public abstract string Question { get; }

		/// <summary>
		/// Solves the puzzle.
		/// </summary>
		/// <returns>The answer to the puzzle.</returns>
		public abstract object Solve();

		//Returns the path to the appropriate resource file for the current puzzle.
		private string GetResourcePath() {
			string className = this.GetType().Name;
			string puzzleName = className.Substring("Puzzle".Length);
			int PuzzleID;
			if (!className.StartsWith("Puzzle") || !int.TryParse(puzzleName, out PuzzleID)) {
				throw new FormatException("Class name was the wrong format.");
			}
			return "Resources/PuzzleData-" + puzzleName + ".txt";
		}

		/// <summary>
		/// Returns the <see cref="Stream"/> associated with the resource for the puzzle.
		/// </summary>
		/// <returns>
		/// A <see cref="Stream"/> containing the resource associated with the puzzle.
		/// </returns>
		protected Stream ReadResource() {
			return File.OpenRead(GetResourcePath());
		}

		/// <summary>
		/// Reads the resource file associated with the puzzle using the given function to open the file.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ReadFunction">The function used to open and read the resource file associated with the puzzle.</param>
		/// <returns>The read resource file.</returns>
		protected T ReadResource<T>(Func<string, T> ReadFunction) {
			return ReadFunction(GetResourcePath());
		}

		/// <summary>
		/// Reads the resource file associated with the puzzle by returning each line of the file.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of each line read from the resource file associated with the puzzle.</returns>
		protected IEnumerable<string> ReadLines() {
			return File.ReadLines(GetResourcePath());
		}

	}
}

using LemonTree.Test.Console.Interfaces;
using System.Collections.Generic;

namespace LemonTree.Test.Console.Classes
{
	/// <summary>
	/// Base class of the chess pieces
	/// </summary>
    public abstract class ChessPiece : IChessPiece
	{
		protected const int MaxSequencelength = 7;
		protected List<List<int>> _sequences = new List<List<int>>(); // List of all possible sequences of 7 numbers

		public string Name { get; protected set; } = string.Empty; 

		/// <summary>
		/// Returns a list of all possible sequences that start with specifed number
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public List<List<int>> GetAllSequences(int startNo, bool jumpAllowed = false)
        {
			var subSequence = new List<int>();
			return GetAllSequences(startNo, subSequence, jumpAllowed);
		}

		/// <summary>
		/// Returns a list of all possible sequences that start with specifed number, with knowledge 
		/// of the existing sequence digits
		/// </summary>
		/// <param name="startNo"></param>
		/// <param name="sequence"></param>
		/// <param name="jumpAllowed"></param>
		/// <returns></returns>
		public List<List<int>> GetAllSequences(int startNo, List<int> sequence, bool jumpAllowed)
		{
			_sequences.Clear();

			GetAllMoves(startNo, sequence, jumpAllowed);

			return _sequences;
		}

		/// <summary>
		/// Recursive method that incrementally finds a valid move to add to the sequence
		/// </summary>
		/// <param name="startNo"></param>
		/// <param name="sequence"></param>
		/// <param name="jumpAllowed"></param>
		protected abstract void GetAllMoves(int? startNo, List<int> sequence, bool jumpAllowed = false);
	}
}

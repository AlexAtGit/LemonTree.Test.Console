using LemonTree.Test.Business.Interfaces;
using System.Collections.Generic;
using System;

namespace LemonTree.Test.Business.Models
{
	/// <summary>
	/// Base class of the chess pieces
	/// </summary>
    public abstract class ChessPiece : IChessPiece
	{
        #region Fields
        protected const int MaxSequencelength = 7;
		protected List<List<int>> _sequences = new(); // List of all possible sequences of 7 numbers
        #endregion Fields

        #region Properties
        public string Name { get; protected set; } = string.Empty;
        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Returns a list of all possible sequences that start with specifed number
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<List<int>> GetAllSequences(int startNo, bool jumpAllowed = false)
        {
			if (startNo < 1 || startNo > 9) throw new ArgumentOutOfRangeException(nameof(startNo), "StartNo must be between 2 and 9");

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
			if (startNo < 1 || startNo > 9) throw new ArgumentOutOfRangeException(nameof(startNo), "StartNo must be between 2 and 9");
			if (sequence == null) throw new ArgumentNullException(nameof(sequence));

			_sequences.Clear();

			GetAllMoves(startNo, sequence, jumpAllowed);

			return _sequences;
		}
        #endregion Public Methods

        #region Protected Methods
        /// <summary>
        /// Recursive method that incrementally finds a valid move to add to the sequence
        /// </summary>
        /// <param name="startNo"></param>
        /// <param name="sequence"></param>
        /// <param name="jumpAllowed"></param>
        protected abstract void GetAllMoves(int? startNo, List<int> sequence, bool jumpAllowed = false);

        /// <summary>
        /// Return the next valid digit from the current digit, based on this move
        /// </summary>
        /// <param name="currentNo"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected static int? MoveRightUp(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.RightOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }
        protected static int? MoveRightDown(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.RightOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }

        protected static int? MoveLeftUp(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.LeftOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }
        protected static int? MoveLeftDown(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.LeftOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }

        /// <summary>
        /// Return the next valid digit from the current digit, based on this move
        /// </summary>
        /// <param name="currentNo"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected int? MoveRight(int currentNo, List<int> sequence)
        {
            int? nextNo = currentNo;

            do
            {
                nextNo = Keypad.RightOf(nextNo.Value);
                if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) break;
            }
            while (nextNo.HasValue);

            return nextNo;
        }
        protected int? MoveLeft(int currentNo, List<int> sequence)
        {
            int? nextNo = currentNo;

            do
            {
                nextNo = Keypad.LeftOf(nextNo.Value);
                if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) break;
            }
            while (nextNo.HasValue);

            return nextNo;
        }
        protected int? MoveUp(int currentNo, List<int> sequence)
        {
            int? nextNo = currentNo;

            do
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) break;
            }
            while (nextNo.HasValue);

            return nextNo;
        }
        protected int? MoveDown(int currentNo, List<int> sequence)
        {
            int? nextNo = currentNo;

            do
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) break;
            }
            while (nextNo.HasValue);

            return nextNo;
        }
        #endregion Protected Methods
    }
}

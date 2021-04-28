using System.Collections.Generic;

namespace LemonTree.Test.Console.Classes
{
    public class Pawn : ChessPiece
    {
        private readonly bool _tradePawnAllowed;

        public Pawn()
        {
            Name = nameof(Pawn);
        }
        public Pawn(bool tradePawnAllowed) : this()
        {
            _tradePawnAllowed = tradePawnAllowed;
        }

        protected override void GetAllMoves(int? startNo, List<int> sequence, bool jumpAllowed = false)
        {
            if (!startNo.HasValue) return; 

            // 1. Pawn chess pieces can only move forward one square, with two exceptions.
            // 2. Pawns can move directly forward two squares on their first move only.
            // 3. Pawns can move diagonally forward when capturing an opponent's chess piece.
            // 4. Once a pawn chess piece reaches the other side of the chess board, the player may "trade" the pawn in for any other chess piece if they choose, except another king.

            // Given the top 3 options above, it is not possible to generate phone numbers
            // However, if the 4th option is considered (_tradePawnAllowed), then potentially one could generate
            // acceptable number. Note that such number cannot be produced algorithmically, unless
            // some AI rules are used, which is beyond the scope of this exercise
            // So, here are possible sequences

            if (!_tradePawnAllowed) return;

            var downNumber1 = MoveDown(startNo.Value, sequence);
            if (!downNumber1.HasValue) return; // Cannot move forward

            var downNumber2 = MoveDown(downNumber1.Value, sequence);
            if (!downNumber2.HasValue) return; // Cannot move forward

            TradeAsRook(startNo.Value, downNumber1.Value, downNumber2.Value, sequence, jumpAllowed);
            var rookPiece = new Rook();

            var rookSequence = new List<int> { startNo.Value, downNumber1.Value };
            _sequences.AddRange(rookPiece.GetAllSequences(0, rookSequence, jumpAllowed));

            var upNumber = MoveUp(startNo.Value, sequence);
            if (!upNumber.HasValue)
            {
                // Can move down two squares
                rookSequence = new List<int> { startNo.Value, downNumber2.Value };

                _sequences.AddRange(rookPiece.GetAllSequences(0, rookSequence, jumpAllowed));
            }
        }
        private void TradeAsRook(int startNo, int downNumber1, int downNumber2, List<int> sequence, bool jumpAllowed)
        {
            var rookPiece = new Rook();

            var rookSequence = new List<int> { startNo, downNumber1 };
            _sequences.AddRange(rookPiece.GetAllSequences(0, rookSequence, jumpAllowed));

            var upNumber = MoveUp(startNo, sequence);
            if (!upNumber.HasValue)
            {
                // Can move down two squares
                rookSequence = new List<int> { startNo, downNumber2 };

                _sequences.AddRange(rookPiece.GetAllSequences(0, rookSequence, jumpAllowed));
            }
        }

        /// <summary>
        /// Return the next valid digit from the current digit, based on this move
        /// </summary>
        /// <param name="currentNo"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private int? MoveUp(int currentNo, List<int> sequence)
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
        /// <summary>
        /// Return the next valid digit from the current digit, based on this move
        /// </summary>
        /// <param name="currentNo"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private int? MoveDown(int currentNo, List<int> sequence)
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
    }
}

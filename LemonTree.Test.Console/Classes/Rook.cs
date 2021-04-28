using System.Collections.Generic;

namespace LemonTree.Test.Console.Classes
{
    public class Rook : ChessPiece
    {
        public Rook()
        {
            Name = nameof(Rook);
        }

        protected override void GetAllMoves(int? startNo, List<int> sequence, bool jumpAllowed = false)
        {
            if (!startNo.HasValue) return;

            var subSequence = new List<int>(sequence) { startNo.Value };
            if (subSequence.Count == MaxSequencelength)
            {
                _sequences.Add(subSequence);
                return;
            }

            // The rook piece can move forward, backward, left or right at any time.
            // The rook piece can move anywhere from 1 to 7 squares in any direction, so long as it is not obstructed by any other piece.

            int? nextNumber = startNo;
            bool skipRight = false, skipLeft = false, skipDown = false, skipUp = false;
            while (nextNumber.HasValue && subSequence.Count < MaxSequencelength)
            {
                if (!skipRight)
                {
                    nextNumber = MoveRight(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveRight(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipRight = true;
                }

                if (!skipLeft)
                {
                    nextNumber = MoveLeft(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveLeft(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipLeft = true;
                }

                if (!skipDown)
                {
                    nextNumber = MoveDown(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveDown(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipDown = true;
                }

                if (!skipUp)
                {
                    nextNumber = MoveUp(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveUp(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipUp = true;
                }

                if (skipRight && skipLeft && skipDown && skipUp) break;
            }
        }

        /// <summary>
        /// Return the next valid digit from the current digit, based on this move
        /// </summary>
        /// <param name="currentNo"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private int? MoveRight(int currentNo, List<int> sequence)
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
        private int? MoveLeft(int currentNo, List<int> sequence)
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

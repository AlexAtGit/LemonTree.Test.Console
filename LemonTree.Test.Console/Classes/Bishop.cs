using System.Collections.Generic;

namespace LemonTree.Test.Console.Classes
{
    public class Bishop : ChessPiece
    {
        public Bishop()
        {
            Name = nameof(Bishop);
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

            //The bishop can move in any direction diagonally, so long as it is not obstructed by another piece.
            //The bishop piece cannot move past any piece that is obstructing its path.
            //The bishop can take any other piece on the board that is within its bounds of movement.         

            int? nextNumber  = startNo;
            bool skipRightUp = false, skipLeftUp = false, skipRightDown = false, skipLeftDown = false;
            while (nextNumber.HasValue && subSequence.Count < MaxSequencelength)
            {
                if (!skipRightUp)
                {
                    nextNumber = MoveRightUp(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveRightUp(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipRightUp = true;
                }

                if (!skipLeftUp)
                {
                    nextNumber = MoveLeftUp(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveLeftUp(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipLeftUp = true;
                }

                if (!skipRightDown)
                {
                    nextNumber = MoveRightDown(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveRightDown(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipRightDown = true;
                }

                if (!skipLeftDown)
                {
                    nextNumber = MoveLeftDown(startNo.Value, subSequence);
                    if (jumpAllowed && nextNumber.HasValue) nextNumber = MoveLeftDown(nextNumber.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipLeftDown = true;
                }

                if (skipRightUp && skipLeftUp && skipRightDown && skipLeftDown) break;
            }
        }

        /// <summary>
        /// Return the next valid digit from the current digit, based on this move
        /// </summary>
        /// <param name="currentNo"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private int? MoveRightUp(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.RightOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }
        private int? MoveRightDown(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.RightOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }

        private int? MoveLeftUp(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.LeftOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }
        private int? MoveLeftDown(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.LeftOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue && sequence.Contains(nextNo.Value)) nextNo = null;
            }

            return nextNo;
        }
    }
}

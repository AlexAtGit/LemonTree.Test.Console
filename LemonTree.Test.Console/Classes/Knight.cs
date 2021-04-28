using System.Collections.Generic;

namespace LemonTree.Test.Console.Classes
{
    public class Knight : ChessPiece
    {
        public Knight()
        {
            Name = nameof(Knight);
        }

        protected override void GetAllMoves(int? startNo, List<int> sequence, bool jumpAllowed = false)
        {
            if (!startNo.HasValue || jumpAllowed) return; // Note that jump is no allowed here

            var subSequence = new List<int>(sequence) { startNo.Value };
            if (subSequence.Count == MaxSequencelength)
            {
                _sequences.Add(subSequence);
                return;
            }

            // The Knight piece moves in a "L" shape, as follows:
            // can move forward, backward, left or right two squares and must then move one square in either perpendicular direction.
            // can only move to one of up to eight positions on the board.
            // can move to any position not already inhabited by another piece of the same color.
            // can skip over any other pieces to reach its destination position.
            // 
            // In this exercise, we are just concerned with the L-shape move
            int? nextNumber  = startNo;
            bool skipRightUp = false, skipRightDown = false, skipLeftUp = false, skipLeftDown = false;
            bool skipDownRight = false, skipDownLeft = false, skipUpRight = false, skipUpLeft = false;
            while (nextNumber.HasValue && subSequence.Count < MaxSequencelength)
            {
                if (!skipRightUp)
                {
                    nextNumber = MoveRightUp(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipRightUp = true;
                }

                if (!skipRightDown)
                {
                    nextNumber = MoveRightDown(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipRightDown = true;
                }

                if (!skipLeftUp)
                {
                    nextNumber = MoveLeftUp(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipLeftUp = true;
                }

                if (!skipLeftDown)
                {
                    nextNumber = MoveLeftDown(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipLeftDown = true;
                }

                if (!skipDownRight)
                {
                    nextNumber = MoveDownRight(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipDownRight = true;
                }

                if (!skipDownLeft)
                {
                    nextNumber = MoveDownLeft(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipDownLeft = true;
                }

                if (!skipUpRight)
                {
                    nextNumber = MoveUpRight(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipUpRight = true;
                }

                if (!skipUpLeft)
                {
                    nextNumber = MoveUpLeft(startNo.Value, subSequence);

                    GetAllMoves(nextNumber, subSequence);
                    skipUpLeft = true;
                }

                if (skipRightUp   && skipRightDown && 
                    skipLeftUp    && skipLeftDown  && 
                    skipDownRight && skipDownLeft  &&
                    skipUpRight   && skipUpLeft) break;
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
                nextNo = Keypad.RightOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.UpOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo; 
                }
            }

            return null;
        }
        private int? MoveRightDown(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.RightOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.RightOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.DownOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo ;
                }
            }

            return null;
        }

        private int? MoveLeftUp(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.LeftOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.LeftOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.UpOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo;
                }
            }

            return null;
        }
        private int? MoveLeftDown(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.LeftOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.LeftOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.DownOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo;
                }
            }

            return null;
        }

        private int? MoveUpRight(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.UpOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.RightOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo;
                }
            }

            return null;
        }
        private int? MoveDownRight(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.DownOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.RightOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo;
                }
            }

            return null;
        }

        private int? MoveUpLeft(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.UpOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.UpOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.LeftOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo;
                }
            }

            return null;
        }
        private int? MoveDownLeft(int currentNo, List<int> sequence)
        {
            int? nextNo = Keypad.DownOf(currentNo);
            if (nextNo.HasValue)
            {
                nextNo = Keypad.DownOf(nextNo.Value);
                if (nextNo.HasValue)
                {
                    nextNo = Keypad.LeftOf(nextNo.Value);
                    if (nextNo.HasValue && !sequence.Contains(nextNo.Value)) return nextNo;
                }
            }

            return null;
        }
    }
}

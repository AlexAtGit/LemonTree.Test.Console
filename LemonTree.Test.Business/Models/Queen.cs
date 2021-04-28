using System.Collections.Generic;

namespace LemonTree.Test.Business.Models
{
    public class Queen : ChessPiece
    {
        public Queen()
        {
            Name = nameof(Queen);
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

            // The queen chess piece is like a combination of the Rook and Bishop chess pieces. 

            // The queen can move in any direction on a straight or diagonal path.
            // The queen cannot "jump" over any piece on the board, so its movements are restricted to any direction of unoccupied squares.
            // The queen can be used to capture any of your opponent's pieces on the board.

            int? nextNumber = startNo;
            bool skipRightUp = false, skipLeftUp = false, skipRightDown = false, skipLeftDown = false;
            bool skipRight = false, skipLeft = false, skipDown = false, skipUp = false;
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

                if (skipRight && skipLeft && skipDown && skipUp &&
                    skipRightUp && skipLeftUp && skipRightDown && skipLeftDown) break;
            }
        }
    }
}

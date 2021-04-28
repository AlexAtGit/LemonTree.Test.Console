using LemonTree.Test.Business.Models;
using System.Collections.Generic;
using Xunit;
using LemonTree.Test.Business;

namespace LemonTree.Test.Console.Tests
{
    public class PawnPieceTests
    {
        [Fact]
        public void NoTradeAllowedTest()
        {
            // Once a pawn chess piece reaches the other side of the chess board,
            // the player may "trade" the pawn in for any other chess piece if they choose
            // This is turned off by default. If true, it become a Rook for the purpose of this test
            var tradePawnAllowed = false;

            // Define all chess pieces to be considered
            var chessPiece = new Pawn(tradePawnAllowed);

            var listOfPhoneNumbers = new List<string>();

            var jumpAllowed = false;
            for (int i = 2; i <= 9; i++) // Cannot start with 1
            {
                // Get all 7-digit phone number sequences starting with number "i"
                var phoneDigitsList = chessPiece.GetAllSequences(i, jumpAllowed);

                // Convert to a text representation, i.e. NNN-NNNN
                foreach (var phoneDigits in phoneDigitsList)
                {
                    listOfPhoneNumbers.Add(Utility.Get7DigitPhoneNumber(phoneDigits));
                }
            }

            Assert.True(listOfPhoneNumbers.Count == 0);
        }
        [Fact]
        public void TradeAllowedTest()
        {
            // Once a pawn chess piece reaches the other side of the chess board,
            // the player may "trade" the pawn in for any other chess piece if they choose
            // This is turned off by default. If true, it become a Rook for the purpose of this test
            var tradePawnAllowed = true;

            // Define all chess pieces to be considered
            var chessPiece = new Pawn(tradePawnAllowed);

            var listOfPhoneNumbers = new List<string>();

            var jumpAllowed = false;
            for (int i = 2; i <= 9; i++) // Cannot start with 1
            {
                // Get all 7-digit phone number sequences starting with number "i"
                var phoneDigitsList = chessPiece.GetAllSequences(i, jumpAllowed);

                // Convert to a text representation, i.e. NNN-NNNN
                foreach (var phoneDigits in phoneDigitsList)
                {
                    listOfPhoneNumbers.Add(Utility.Get7DigitPhoneNumber(phoneDigits));
                }
            }

            Assert.True(listOfPhoneNumbers.Count > 0);
        }
    }
}

using LemonTree.Test.Business;
using LemonTree.Test.Business.Models;
using System.Collections.Generic;
using Xunit;

namespace LemonTree.Test.Console.Tests
{
    public class KnightPieceTests
    {
        [Fact]
        public void MatchFoundTest()
        {
            // Define all chess pieces to be considered
            var chessPiece = new Knight();

            // Get all 7-digit phone number sequences starting with number "i"
            var phoneDigitsList = chessPiece.GetAllSequences(2);
            Assert.Equal(2, phoneDigitsList.Count);

            var foundNumbers = new List<string> { Utility.Get7DigitPhoneNumber(phoneDigitsList[0]), Utility.Get7DigitPhoneNumber(phoneDigitsList[1]) };

            var expectedNumbers1 = "294-3816";
            var expectedNumbers2 = "276-1834";

            Assert.Contains(expectedNumbers1, foundNumbers);
            Assert.Contains(expectedNumbers2, foundNumbers);
        }
    }
}

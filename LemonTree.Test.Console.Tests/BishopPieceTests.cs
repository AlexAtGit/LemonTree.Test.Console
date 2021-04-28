using LemonTree.Test.Business.Models;
using Xunit;

namespace LemonTree.Test.Console.Tests
{
    public class BishopPieceTests
    {
        [Fact]
        public void NoTradeAllowedTest()
        {
            // Define all chess pieces to be considered
            var chessPiece = new Bishop();

            // Get all 7-digit phone number sequences starting with number "i"
            var jumpAllowed = false;
            var phoneDigitsList = chessPiece.GetAllSequences(3, jumpAllowed);
            Assert.True(phoneDigitsList.Count == 0);
        }
    }
}

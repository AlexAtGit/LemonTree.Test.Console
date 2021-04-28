using System;
using LemonTree.Test.Business.Models;
using Xunit;

namespace LemonTree.Test.Console.Tests
{
    public class ChessPieceTests
    {
        [Fact]
        public void OutOfRangeStartNumberTest()
        {
            var chessPiece = new Bishop();

            Assert.Throws<ArgumentOutOfRangeException>(() => chessPiece.GetAllSequences(0, false));
        }
        [Fact]
        public void NoSequenceProvidedTest()
        {
            var chessPiece = new Bishop();

            Assert.Throws<ArgumentNullException>(() => chessPiece.GetAllSequences(0, null, false));
        }
    }
}

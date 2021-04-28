using System.Collections.Generic;

namespace LemonTree.Test.Console.Interfaces
{
    public interface IChessPiece
    {
        string Name { get; }
        List<List<int>> GetAllSequences(int i, bool jumpAllowed = false);
    }
}

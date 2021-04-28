using System.Collections.Generic;

namespace LemonTree.Test.Business.Interfaces
{
    public interface IChessPiece
    {
        string Name { get; }
        List<List<int>> GetAllSequences(int i, bool jumpAllowed = false);
    }
}

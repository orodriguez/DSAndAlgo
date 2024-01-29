namespace DataStructures.Tree;

public interface IBinarySearchTreeNode
{
    void AddChild(int value);
    IEnumerable<int> Ordered();
    IEnumerable<int> PreOrdered();
    IEnumerable<int> PostOrdered();
    bool Contains(int value);
    int Max();
    int Min();
    int Sum();
    IBinarySearchTreeNode Delete(int value);
    bool IsEmpty { get; }
}
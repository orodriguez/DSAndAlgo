namespace DataStructures.Tree;

internal class EmptyNode : IBinarySearchTreeNode
{
    private readonly Action<int> _addChild;

    public EmptyNode(Action<int> addChild) =>
        _addChild = addChild;

    public void AddChild(int value) => _addChild(value);

    public IEnumerable<int> Ordered() => Array.Empty<int>();

    public IEnumerable<int> PreOrdered() => Array.Empty<int>();

    public IEnumerable<int> PostOrdered() => Array.Empty<int>();

    public bool Contains(int value) => false;

    public int Max() => 0;

    public int Min() => int.MaxValue;

    public int Sum() => 0;
    
    public IBinarySearchTreeNode Delete(int value) => this;

    public bool IsEmpty => true;
}
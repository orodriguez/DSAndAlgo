namespace DataStructures.Tree;

public class BinarySearchTreeNode
{
    private int Value { get; }
    private BinarySearchTreeNode? Left { get; set; }
    private BinarySearchTreeNode? Right { get; set; }

    private BinarySearchTreeNode(int value) => Value = value;
    
    public BinarySearchTreeNode(params int[] values)
    {
        if (!values.Any())
            throw new ArgumentException("Values can not be empty");
        
        (Value, var tail) = (values.First(), values.Skip(1));
        
        foreach (var value in tail)
            AddChild(value);
    }

    private void AddChild(int value)
    {
        if (value == Value)
            return;

        if (value < Value)
        {
            Left ??= new BinarySearchTreeNode(value);
            Left.AddChild(value);
            return;
        }
        
        Right ??= new BinarySearchTreeNode(value);
        Right.AddChild(value);
    }

    public IEnumerable<int> Ordered() =>
        (Left?.Ordered() ?? Array.Empty<int>())
            .Concat(new[] { Value })
            .Concat(Right?.Ordered() ?? Array.Empty<int>());

    public IEnumerable<int> PreOrdered() =>
        new[] { Value }
            .Concat(Left?.PreOrdered() ?? Array.Empty<int>())
            .Concat(Right?.PreOrdered() ?? Array.Empty<int>());

    public IEnumerable<int> PostOrdered() =>
        (Left?.PostOrdered() ?? Array.Empty<int>())
            .Concat(Right?.PostOrdered() ?? Array.Empty<int>())
            .Concat(new[] { Value });

    public bool Contains(int value)
    {
        if (value == Value)
            return true;

        if (value < Value)
            return Left?.Contains(value) ?? false;
        
        return Right?.Contains(value) ?? false;
    }

    public int Max() => Right?.Max() ?? Value;

    public int Min() => Left?.Min() ?? Value;

    public int Sum() => 
        Value + (Left?.Sum() ?? 0) + (Right?.Sum() ?? 0);
}
namespace DataStructures.Tree;

public class BinarySearchTreeNode
{
    private int Value { get; set; }
    private BinarySearchTreeNode? Left { get; set; }
    private BinarySearchTreeNode? Right { get; set; }

    private BinarySearchTreeNode(int value) => Value = value;
    
    public BinarySearchTreeNode(params int[] values)
    {
        if (!values.Any())
            throw new ArgumentException("Values can not be empty");
        
        Value = values.First();
        foreach (var value in values.Skip(1)) AddChild(value);
    }

    private void AddChild(int value)
    {
        if (value == Value)
            return;

        if (value < Value)
            if (Left == null)
                Left = new BinarySearchTreeNode(value);
            else
                Left.AddChild(value);
        else
        {
            if (Right == null)
                Right = new BinarySearchTreeNode(value);
            else
                Right.AddChild(value);
        }
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

    public int Min()
    {
        var min = Value;

        var currentNode = Left;
        while (currentNode != null)
        {
            min = Math.Min(min, currentNode.Value);
            currentNode = currentNode.Left;
        }
        
        return min;
    }

    public int Max()
    {
        var max = Value;

        var currentNode = Right;
        while (currentNode != null)
        {
            max = Math.Max(max, currentNode.Value);
            currentNode = currentNode.Right;
        }
        
        return max;
    }

    public int Sum() => 
        Value + (Left?.Sum() ?? 0) + (Right?.Sum() ?? 0);
}
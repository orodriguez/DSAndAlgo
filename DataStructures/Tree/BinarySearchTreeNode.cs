namespace DataStructures.Tree;

public class BinarySearchTreeNode : IBinarySearchTreeNode
{
    public static BinarySearchTreeNode From(int[] values)
    {
        if (!values.Any())
            throw new ArgumentException("Values can not be empty");

        var node = new BinarySearchTreeNode(values.First());

        node.AddChildren(values.Skip(1));

        return node;
    }

    public void AddChild(int value)
    {
        if (value == Value)
            return;

        if (value < Value)
            Left.AddChild(value);
        else
            Right.AddChild(value);
    }

    public IEnumerable<int> Ordered() =>
        Left.Ordered().Concat(new[] { Value }).Concat(Right.Ordered());

    public IEnumerable<int> PreOrdered() =>
        new[] { Value }.Concat(Left.PreOrdered()).Concat(Right.PreOrdered());

    public IEnumerable<int> PostOrdered() =>
        Left.PostOrdered().Concat(Right.PostOrdered()).Concat(new[] { Value });

    public bool Contains(int value)
    {
        if (value == Value)
            return true;

        return value < Value ? Left.Contains(value) : Right.Contains(value);
    }

    public int Max() => Math.Max(Value, Right.Max());

    public int Min() => Math.Min(Value, Left.Min());

    public int Sum() => Value + Left.Sum() + Right.Sum();

    public bool IsEmpty => false;

    public IBinarySearchTreeNode Delete(int value)
    {
        if (Value < value)
        {
            Right = Right.Delete(value);
            return this;
        }

        if (Value > value)
        {
            Left = Left.Delete(value);
            return this;
        }
        
        // Value == value
        
        if (Left.IsEmpty && Right.IsEmpty) return new EmptyNode(AddChild);

        if (Left.IsEmpty) return Right;

        if (Right.IsEmpty) return Left;

        var minRight = Right.Min();
        Value = minRight;
        Right = Right.Delete(minRight);
        return this;
    }

    private void AddChildren(IEnumerable<int> values)
    {
        foreach (var value in values)
            AddChild(value);
    }

    private int Value { get; set; }

    private IBinarySearchTreeNode Left { get; set; }

    private IBinarySearchTreeNode Right { get; set; }

    private BinarySearchTreeNode(int value)
    {
        Value = value;
        Left = new EmptyNode(
            addedValue => Left = new BinarySearchTreeNode(addedValue));
        Right = new EmptyNode(
            addedValue => Right = new BinarySearchTreeNode(addedValue));
    }
}
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

    private void AddChildren(IEnumerable<int> values)
    {
        foreach (var value in values)
            AddChild(value);
    }

    private int Value { get; }

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

    private class EmptyNode : IBinarySearchTreeNode
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
    }
}
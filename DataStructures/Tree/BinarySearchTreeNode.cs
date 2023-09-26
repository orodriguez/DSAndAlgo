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

    public IEnumerable<int> TraverseInOrder()
    {
        var result = new List<int>();

        if (Left != null)
            result.AddRange(Left.TraverseInOrder());

        result.Add(Value);

        if (Right != null)
            result.AddRange(Right.TraverseInOrder());
        return result;
    }

    public bool Contains(int value)
    {
        if (value == Value)
            return true;

        if (value < Value)
            return Left != null && Left.Contains(value);

        if (value > Value && Right != null)
            return Right.Contains(value);

        return false;
    }
}
using System.Runtime.Serialization;

namespace DataStructures.Tree;

public class TreeNode<T>
{
    private T Value { get; }
    private readonly List<TreeNode<T>> _children;
    public TreeNode<T>? Parent { get; set; }

    public TreeNode(T value, IEnumerable<TreeNode<T>> children) : this(value)
    {
        foreach (var child in children) 
            AddChild(child);
    }

    public TreeNode(T value)
    {
        Value = value;
        _children = new List<TreeNode<T>>();
        Parent = null;
    }

    private int Level {
        get
        {
            var level = 0;
            var parent = Parent;
            while (parent != null)
            {
                level++;
                parent = parent.Parent;
            }
            return level;
        }
    }

    public void AddChild(TreeNode<T> child)
    {
        child.Parent = this;
        _children.Add(child);
    }

    public string Print() =>
        _children
            .Aggregate("" + Value, 
                (current, child) => $"{current}\n{child.Indent()}{child.Print()}");

    private string Indent() => 
        string.Concat(Enumerable.Repeat("  ", Level)) + "|__";
}
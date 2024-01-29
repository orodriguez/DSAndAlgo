using DataStructures.Tree;

namespace Tests.Tree;

public class BinarySearchTreeNodeTests
{
    // Left => Root => Right
    [Theory]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(
        new[] { 15, 12, 27, 7, 14, 20, 88, 23 },
        new[] { 7, 12, 14, 15, 20, 23, 27, 88 })]
    public void InOrder(int[] values, int[] expectedOrder)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expectedOrder, tree.Ordered());
    }

    // Root => Left => Right
    [Theory]
    [InlineData(
        new[] { 15, 12, 27, 7, 14, 20, 88, 23 },
        new[] { 15, 12, 7, 14, 27, 20, 23, 88 })]
    public void PreOrder(int[] values, int[] expectedOrder)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expectedOrder, tree.PreOrdered());
    }

    // Right => Left => Root
    [Theory]
    [InlineData(
        new[] { 15, 12, 27, 7, 14, 20, 88, 23 },
        new[] { 7, 14, 12, 23, 20, 88, 27, 15 })]
    public void PostOrder(int[] values, int[] expectedOrder)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expectedOrder, tree.PostOrdered());
    }

    [Theory]
    [InlineData(new[] { 1 }, 1, true)]
    [InlineData(new[] { 1, 3, 5, 6, 8 }, 6, true)]
    [InlineData(new[] { 1, 2, 3 }, 4, false)]
    public void Contains(int[] values, int value, bool expected)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expected, tree.Contains(value));
    }

    [Theory]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 4, 7, 2, 8 }, 2)]
    public void Min(int[] values, int expected)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expected, tree.Min());
    }

    [Theory]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 4, 7, 2, 8, 10, 9 }, 10)]
    public void Max(int[] values, int expected)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expected, tree.Max());
    }

    [Theory]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 2, 3, 4 }, 10)]
    public void Sum(int[] values, int expected)
    {
        var tree = BinarySearchTreeNode.From(values);
        Assert.Equal(expected, tree.Sum());
    }

    [Theory]
    // Delete node without child
    [InlineData(new[] { 1, 2 }, 2, new[] { 1 })]
    [InlineData(new[] { 2, 1 }, 1, new[] { 2 })]

    // Delete node with one child
    [InlineData(new[] { 1, 2, 3 }, 2, new[] { 1, 3 })]
    [InlineData(new[] { 3, 2, 1 }, 2, new[] { 1, 3 })]

    // Delete node with two children
    [InlineData(new[] { 1, 3, 2, 4 }, 3, new[] { 1, 2, 4 })]
    [InlineData(new[] { 1, 3, 2, 4, 5 }, 3, new[] { 1, 2, 4, 5 })]
    [InlineData(new[] { 2, 1, 4, 3, 6, 5, 7 }, 6, new[] { 1, 2, 3, 4, 5, 7 })]

    // Does not exist
    [InlineData(new[] { 1 }, 2, new[] { 1 })]
    [InlineData(new[] { 2 }, 1, new[] { 2 })]
    [InlineData(new[] { 1, 2 }, 3, new[] { 1, 2 })]
    [InlineData(new[] { 3, 2 }, 1, new[] { 2, 3 })]
    public void Delete(int[] values, int value, int[] expectedOrder)
    {
        var tree = BinarySearchTreeNode.From(values);
        var newTree = tree.Delete(value);
        Assert.Equal(expectedOrder, newTree.Ordered());
    }

    [Fact]
    public void ValuesConstructor_WhenEmpty_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            BinarySearchTreeNode.From(Array.Empty<int>()));
        Assert.Equal("Values can not be empty", exception.Message);
    }
}
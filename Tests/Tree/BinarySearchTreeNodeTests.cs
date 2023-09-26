using DataStructures.Tree;

namespace Tests.Tree;

public class BinarySearchTreeNodeTests
{
    [Theory]
    [InlineData(new[] {1}, new[] {1})]
    [InlineData(new[] {1, 2}, new[] {1, 2})]
    [InlineData(new[] {2, 1}, new[] {1, 2})]
    [InlineData(new[] {1, 3, 5, 2, 4}, new[] {1, 2, 3, 4, 5})]
    public void TraverseInOrder(int[] elements, int[] elementsInExpectedOrder)
    {
        var tree = new BinarySearchTreeNode(elements);
        Assert.Equal(elementsInExpectedOrder,tree.TraverseInOrder());
    }

    [Theory]
    [InlineData(new[] { 1 }, 1, true)]
    [InlineData(new[] { 1, 3, 5, 6, 8 }, 6, true)]
    [InlineData(new[] { 1, 2, 3 }, 4, false)]
    public void Contains(int[] values, int value, bool expected)
    {
        var tree = new BinarySearchTreeNode(values);
        Assert.Equal(expected, tree.Contains(value));
    }

    [Fact]
    public void ValuesConstructor_WhenEmpty_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => 
            new BinarySearchTreeNode());
        Assert.Equal("Values can not be empty", exception.Message);
    }
}
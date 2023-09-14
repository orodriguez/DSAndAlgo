using DataStructures.Tree;
using Xunit.Abstractions;

namespace Tests.Tree;

// https://github.com/codebasics/data-structures-algorithms-python/blob/master/data_structures/7_Tree/7_tree_exercise.md
public class PrintTreeTests
{
    private readonly ITestOutputHelper _output;

    public PrintTreeTests(ITestOutputHelper output) => 
        _output = output;

    [Fact]
    public void Test()
    {
        var root = new TreeNode<string>("Omar", new[]
        {
            new TreeNode<string>("John", new[]
            {
                new TreeNode<string>("Mark")
            }),
            new TreeNode<string>("Paul", new[]
            {
                new TreeNode<string>("Luke"),
                new TreeNode<string>("Mathew")
            })
        });
        
        _output.WriteLine(root.Print());
    }
}
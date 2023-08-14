using DataStructures.Stack;

namespace Tests.Stack;
using static ReverseString;

public class ReverseStringTest
{
    [Fact]
    public void Empty() => 
        Assert.Equal("", Reverse(""));

    [Fact]
    public void OneChar() =>
        Assert.Equal("a", Reverse("a"));

    [Fact]
    public void TwoChars() =>
        Assert.Equal("ba", Reverse("ab"));
    
    [Fact]
    public void ManyChars() =>
        Assert.Equal("ihgfedcba", Reverse("abcdefghi"));
}
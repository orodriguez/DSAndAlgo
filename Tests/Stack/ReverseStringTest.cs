using DataStructures.Stack;

namespace Tests.Stack;
using static ReverseString;

public class ReverseStringTest
{
    [Theory]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("ab", "ba")]
    [InlineData("abcd", "dcba")]
    public void Test(string input, string result) =>
        Assert.Equal(result, Reverse(input));
}
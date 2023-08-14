using DataStructures.Stack;

namespace Tests.Stack;

public class ParenthesesBalanceTest
{
    [Theory]
    [InlineData("(", false)]
    [InlineData(")", false)]
    [InlineData("(()", false)]
    [InlineData("())", false)]
    [InlineData("()(", false)]
    [InlineData("()(){", false)]
    [InlineData("{{}}[[]", false)]
    [InlineData("", true)]
    [InlineData("()", true)]
    [InlineData("()()", true)]
    [InlineData("(()())()(())", true)]
    [InlineData("()[]", true)]
    [InlineData("([])", true)]
    [InlineData("([]){}", true)]
    [InlineData("([{}])", true)]
    public void Test(string str, bool isBalanced) => 
        Assert.Equal(isBalanced, str.IsBalanced());
}
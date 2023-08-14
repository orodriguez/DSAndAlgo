namespace DataStructures.Stack;

public static class ParenthesesBalanceExtensions
{
    static readonly Dictionary<char, char> Openers = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' }
    };
    public static bool IsBalanced(this string str)
    {
        var stack = new Stack<char>();
        foreach (var chr in str)
        {
            if (IsOpener(chr))
                stack.Push(chr);

            if (IsCloser(chr))
            {
                if (stack.Count == 0)
                    return false;
                
                var lastOpener = stack.Pop();
                if (lastOpener != MatchFor(chr))
                    return false;
            }
        }
        return stack.Count == 0;
    }

    private static bool IsOpener(char chr) => 
        Openers.ContainsValue(chr);

    private static bool IsCloser(char chr) => 
        Openers.ContainsKey(chr);

    private static char MatchFor(char chr) => Openers[chr];
}
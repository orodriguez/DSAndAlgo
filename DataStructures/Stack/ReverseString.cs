using System.Text;

namespace DataStructures.Stack;

public static class ReverseString
{
    public static string Reverse(string str)
    {
        var stack = new Stack<char>();
        foreach (var chr in str) 
            stack.Push(chr);

        var result = new StringBuilder();
        foreach (var chr in stack) 
            result.Append(chr);
        
        return result.ToString();
    }
}
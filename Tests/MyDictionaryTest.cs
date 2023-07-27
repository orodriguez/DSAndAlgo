using DataStructures;

namespace Tests;

public class MyDictionaryTest
{
    [Fact]
    public void Add()
    {
        var d = new MyDictionary<string, int>
        {
            ["Jul 26"] = 50
        };

        Assert.Equal(50, d["Jul 26"]);
    }
}
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
    
    [Fact]
    public void Add_Collision()
    {
        var d = new MyDictionary<string, int>
        {
            ["Jul 26"] = 50
        };

        d["Jul 26"] = 60;

        Assert.Equal(60, d["Jul 26"]);
    }

    [Fact]
    public void Clear()
    {
        var d = new MyDictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 2
        };
        
        d.Clear();
        
        Assert.Empty(d);
    }
}
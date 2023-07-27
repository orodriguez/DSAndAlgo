using DataStructures;

namespace Tests.Dictionary;

public abstract class AbstractDictionaryTest
{
    [Fact]
    public void Add()
    {
        var d = CreateEmptyDictionary<string, int>();
        d["Jul 26"] = 50;

        Assert.Equal(50, d["Jul 26"]);
    }

    [Fact]
    public void Add_Collision()
    {
        var d = CreateEmptyDictionary<string, int>();;
        d["Jul 26"] = 50;
        d["Jul 26"] = 60;

        Assert.Equal(60, d["Jul 26"]);
    }

    [Fact]
    public void Clear()
    {
        var d = CreateEmptyDictionary<string, int>();
        d["a"] = 1;
        d["b"] = 2;

        d.Clear();
        
        Assert.Empty(d);
    }

    [Fact]
    public void Contains()
    {
        var d = CreateEmptyDictionary<string, int>();;
        d["a"] = 1;
        d["b"] = 2;

        var contains = d.Contains(new KeyValuePair<string, int>("a", 1)); 
        Assert.True(contains);
    }

    [Fact]
    public void Contains_NotFound()
    {
        var d = CreateEmptyDictionary<string, int>();;
        d["a"] = 1;
        d["b"] = 2;

        var contains = d.Contains(new KeyValuePair<string, int>("a", 10)); 
        Assert.False(contains);
    }

    [Fact]
    public void ContainsKey()
    {
        var d = CreateEmptyDictionary<string, int>();
        d["a"] = 1;
        d["b"] = 2;

        Assert.True(d.ContainsKey("a"));
    }

    [Fact]
    public void ContainsKey_NotFound()
    {
        var d = CreateEmptyDictionary<string, int>();;
        d["a"] = 1;
        d["b"] = 2;

        Assert.False(d.ContainsKey("c"));
    }

    [Fact]
    public void RemoveKey()
    {
        var d = CreateEmptyDictionary<string, int>();
        d["a"] = 1;
        d["b"] = 2;

        d.Remove("a");
        Assert.False(d.ContainsKey("a"));
    }

    [Fact]
    public void RemoveKey_NotFound()
    {
        var d = CreateEmptyDictionary<string, int>();
        d["a"] = 1;

        d.Remove("c");
        Assert.Equal(new[] { "a" }, d.Keys);
    }
    
    protected abstract IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>() 
        where TKey : notnull;
}
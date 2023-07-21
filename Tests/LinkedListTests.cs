namespace Tests;

public class LinkedListTests
{
    [Fact]
    public void Constructor()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>();

        Assert.Null(ll.Head);
    }

    [Fact]
    public void ConvertToString_Empty()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>();

        Assert.Equal("List is empty", ll.ToString());
    }

    [Fact]
    public void ConvertToString_OneElement()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>("Foo");

        Assert.Equal("LinkedList(Foo)", ll.ToString());
    }

    [Fact]
    public void InsertAtStart()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>("Bar");

        ll.InsertAtStart("Foo");
        
        Assert.Equal("LinkedList(Foo --> Bar)", ll.ToString());
    }

    [Fact]
    public void InsertAtEnd()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>("Foo");

        ll.InsertAtEnd("Bar");
        
        Assert.Equal("LinkedList(Foo --> Bar)", ll.ToString());
    }
    
    [Fact]
    public void InsertValues()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>();

        ll.InsertValues("Foo", "Bar");
        
        Assert.Equal("LinkedList(Foo --> Bar)", ll.ToString());
    }
    
    [Fact]
    public void InsertAt()
    {
        var ll = new DataStructures.LinkedList.LinkedList<int>();
        
        ll.InsertValues(1, 3);
        
        ll.InsertAt(1, 2);
        
        Assert.Equal("LinkedList(1 --> 2 --> 3)", ll.ToString());
    }

    [Fact]
    public void InsertAfterValue()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>();

        ll.InsertValues("banana", "mango", "grapes");
        
        ll.InsertAfterValue("mango", "apple");
        
        Assert.Equal("LinkedList(banana --> mango --> apple --> grapes)", ll.ToString());
    }
    
    [Fact]
    public void InsertAfterValue_Empty()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>();
        
        ll.InsertAfterValue("a", "b");

        Assert.Equal(0, ll.Count());
    }
    
    [Fact]
    public void InsertAfterValue_One()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>("mango");
        
        ll.InsertAfterValue("mango", "banana");
        Assert.Equal("LinkedList(mango --> banana)", ll.ToString());
    }
    
    [Fact]
    public void RemoveByValue()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>();
        
        ll.InsertValues("a", "b", "c");

        ll.RemoveByValue("b");
        
        Assert.Equal("LinkedList(a --> c)", ll.ToString());
    }
    
    [Fact]
    public void RemoveByValue_One()
    {
        var ll = new DataStructures.LinkedList.LinkedList<string>("a");

        ll.RemoveByValue("a");
        
        Assert.Equal(0, ll.Count());
    }
}
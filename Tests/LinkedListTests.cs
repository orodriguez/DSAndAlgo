using DataStructures.LinkedList;

namespace Tests;

public class LinkedListTests
{
    [Fact]
    public void Constructor() =>
        Assert.Null(new SimpleLinkedList<string>().Head);

    [Fact]
    public void ConvertToString_Empty() =>
        Assert.Equal(Array.Empty<string>(), 
            new SimpleLinkedList<string>());

    [Fact]
    public void ConvertToString_OneElement()
    {
        string[] values = new[] { "Foo" };
        Assert.Equal(new[] { "Foo" }, 
            new SimpleLinkedList<string>(values));
    }

    [Fact]
    public void InsertAtStart()
    {
        string[] values = new[] { "Bar" };
        var ll = new SimpleLinkedList<string>(values);
        ll.InsertAtStart("Foo");

        Assert.Equal(new[] { "Foo", "Bar" }, ll);
    }

    [Fact]
    public void InsertAtEnd()
    {
        string[] values = new[] { "Foo" };
        var ll = new SimpleLinkedList<string>(values);
        ll.InsertAtEnd("Bar");

        Assert.Equal(new[] { "Foo", "Bar" }, ll);
    }

    [Fact]
    public void InsertValues()
    {
        var ll = new SimpleLinkedList<string>();
        ll.InsertValues("Foo", "Bar");

        Assert.Equal(new[] { "Foo", "Bar" }, ll);
    }

    [Fact]
    public void InsertAt()
    {
        string[] values = new[] { "a", "c" };
        var ll = new SimpleLinkedList<string>(values);
        ll.InsertAt(1, "b");

        Assert.Equal(new[] { "a", "b", "c" }, ll);
    }

    [Fact]
    public void InsertAfterValue()
    {
        string[] values = new[] { "banana", "mango", "grapes" };
        var ll = new SimpleLinkedList<string>(values);
        ll.InsertAfterValue("mango", "apple");

        Assert.Equal(new[] { "banana", "mango", "apple", "grapes" }, ll);
    }

    [Fact]
    public void InsertAfterValue_Empty()
    {
        var ll = new SimpleLinkedList<string>();
        ll.InsertAfterValue("a", "b");

        Assert.Empty(ll);
    }

    [Fact]
    public void InsertAfterValue_One()
    {
        string[] values = new[] { "mango" };
        var ll = new SimpleLinkedList<string>(values);
        ll.InsertAfterValue("mango", "banana");
        
        Assert.Equal(new[] { "mango", "banana" }, ll);
    }

    [Fact]
    public void RemoveByValue()
    {
        string[] values = new[] { "a", "b", "c" };
        var ll = new SimpleLinkedList<string>(values);
        ll.RemoveByValue("b");

        Assert.Equal(new[] {"a", "c"}, ll);
    }

    [Fact]
    public void RemoveByValue_One()
    {
        string[] values = new[] { "a" };
        var ll = new SimpleLinkedList<string>(values);
        ll.RemoveByValue("a");

        Assert.Empty(ll);
    }
}
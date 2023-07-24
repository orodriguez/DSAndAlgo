using DataStructures.LinkedList;
using static DataStructures.LinkedList.SimpleLinkedList;

namespace Tests;

public class LinkedListTests
{
    [Fact]
    public void Constructor() =>
        Assert.Null(LinkedList<string>().Head);

    [Fact]
    public void ConvertToString_Empty() =>
        Assert.Equal(Array.Empty<string>(), LinkedList<string>());

    [Fact]
    public void ConvertToString_OneElement() =>
        Assert.Equal(new[] { "Foo" }, LinkedList<string>("Foo"));

    [Fact]
    public void InsertAtStart()
    {
        var ll = LinkedList<string>("Bar");
        ll.InsertAtStart("Foo");

        Assert.Equal(new[] { "Foo", "Bar" }, ll);
    }

    [Fact]
    public void InsertAtEnd()
    {
        var ll = LinkedList<string>("Foo");
        ll.InsertAtEnd("Bar");

        Assert.Equal(new[] { "Foo", "Bar" }, ll);
    }

    [Fact]
    public void InsertValues()
    {
        var ll = LinkedList<string>();
        ll.InsertValues("Foo", "Bar");

        Assert.Equal(new[] { "Foo", "Bar" }, ll);
    }

    [Fact]
    public void InsertAt()
    {
        var ll = LinkedList<string>("a", "c");
        ll.InsertAt(1, "b");

        Assert.Equal(new[] { "a", "b", "c" }, ll);
    }

    [Fact]
    public void InsertAfterValue()
    {
        var ll = LinkedList<string>("banana", "mango", "grapes");
        ll.InsertAfterValue("mango", "apple");

        Assert.Equal(new[] { "banana", "mango", "apple", "grapes" }, ll);
    }

    [Fact]
    public void InsertAfterValue_Empty()
    {
        var ll = LinkedList<string>();
        ll.InsertAfterValue("a", "b");

        Assert.Empty(ll);
    }

    [Fact]
    public void InsertAfterValue_One()
    {
        var ll = LinkedList<string>("mango");
        ll.InsertAfterValue("mango", "banana");
        
        Assert.Equal(new[] { "mango", "banana" }, ll);
    }

    [Fact]
    public void RemoveByValue()
    {
        var ll = LinkedList<string>("a", "b", "c");
        ll.RemoveByValue("b");

        Assert.Equal(new[] {"a", "c"}, ll);
    }

    [Fact]
    public void RemoveByValue_One()
    {
        var ll = LinkedList<string>("a");
        ll.RemoveByValue("a");

        Assert.Empty(ll);
    }
}
using DataStructures.LinkedList;

namespace Tests.LinkedList;

public class DoublyLinkedListTest
{
    [Fact]
    public void Constructor()
    {
        var dll = new DoublyLinkedList<int>();

        Assert.Empty(dll);
    }

    [Fact]
    public void InsertAtStart_Empty()
    {
        var dll = new DoublyLinkedList<string>();
        dll.InsertAtStart("Foo");

        Assert.Equal("Foo", dll.First());
    }

    [Fact]
    public void InsertAtStart_NonEmpty()
    {
        var dll = new DoublyLinkedList<string>("Bar");
        dll.InsertAtStart("Foo");

        Assert.Equal(new[] { "Foo", "Bar" }, dll);
        Assert.Equal(new[] { "Bar", "Foo" }, dll.EnumerateBackwards());
    }

    [Fact]
    public void InsertAtEnd_Empty()
    {
        var dll = new DoublyLinkedList<string>();
        dll.InsertAtEnd("Foo");

        Assert.Equal("Foo", dll.Last());
    }

    [Fact]
    public void InsertAtEnd_NonEmpty()
    {
        var dll = new DoublyLinkedList<string>("Foo");
        dll.InsertAtEnd("Bar");

        Assert.Equal(new[] { "Foo", "Bar" }, dll);
        Assert.Equal(new[] { "Bar", "Foo" }, dll.EnumerateBackwards());
    }

    [Fact]
    public void InsertValues()
    {
        var dll = new DoublyLinkedList<string>();
        dll.InsertValues("a", "b", "c");

        Assert.Equal(new[] { "a", "b", "c" }, dll);
        Assert.Equal(new[] { "c", "b", "a" }, dll.EnumerateBackwards());
    }

    [Fact]
    public void InsertAt()
    {
        var dll = new DoublyLinkedList<string>("a", "c");
        dll.InsertAt(1, "b");

        Assert.Equal(new[] { "a", "b", "c" }, dll);
        Assert.Equal(new[] { "c", "b", "a" }, dll.EnumerateBackwards());
    }

    [Fact]
    public void InsertAt_IndexLessThanZero()
    {
        var dll = new DoublyLinkedList<string>("a", "c");

        var exception = Assert.Throws<Exception>(() =>
            dll.InsertAt(-1, "b"));

        Assert.Equal("Invalid Index", exception.Message);
    }

    [Fact]
    public void InsertAt_IndexGreaterThanListSize()
    {
        var dll = new DoublyLinkedList<string>("a", "c");

        var exception = Assert.Throws<Exception>(() =>
            dll.InsertAt(10, "b"));

        Assert.Equal("Invalid Index", exception.Message);
    }

    [Fact]
    public void InsertAt_IndexZero()
    {
        var dll = new DoublyLinkedList<string>("b");
        dll.InsertAt(0, "a");

        Assert.Equal(new[] { "a", "b" }, dll);
        Assert.Equal(new[] { "b", "a" }, dll.EnumerateBackwards());
    }

    [Fact]
    public void InsertAfterValue_One()
    {
        var dll = new DoublyLinkedList<string>("a");
        dll.InsertAfterValue("a", "b");

        Assert.Equal(new[] { "a", "b"}, dll);
        Assert.Equal(new[] { "b", "a"}, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void InsertAfterValue()
    {
        var dll = new DoublyLinkedList<string>("a", "c");
        dll.InsertAfterValue("a", "b");

        Assert.Equal(new[] { "a", "b", "c" }, dll);
        Assert.Equal(new[] { "c", "b", "a" }, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void InsertAfterValue_ValueDoesNotExist()
    {
        var dll = new DoublyLinkedList<string>("a", "c");
        dll.InsertAfterValue("d", "b");

        Assert.Equal(new[] { "a", "c" }, dll);
        Assert.Equal(new[] { "c", "a" }, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void InsertAfterValue_Last()
    {
        var dll = new DoublyLinkedList<string>("a", "b");
        dll.InsertAfterValue("b", "c");

        Assert.Equal(new[] { "a", "b", "c" }, dll);
        Assert.Equal(new[] { "c", "b", "a" }, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void InsertAfterValue_Empty()
    {
        var dll = new DoublyLinkedList<string>();
        dll.InsertAfterValue("a", "b");

        Assert.Empty(dll);
    }
    
    [Fact]
    public void Count_Empty()
    {
        var dll = new DoublyLinkedList<string>();

        Assert.Equal(0, dll.Count());
    }
    
    [Fact]
    public void Count_One()
    {
        var dll = new DoublyLinkedList<string>("a");

        Assert.Equal(1, dll.Count());
    }
    
    [Fact]
    public void Count_Many()
    {
        var dll = new DoublyLinkedList<string>("a", "b", "c");

        Assert.Equal(3, dll.Count());
    }
    
    [Fact]
    public void RemoveByValue_One()
    {
        var dll = new DoublyLinkedList<string>("a");
        dll.RemoveByValue("a");
        
        Assert.Empty(dll);
    }
    
    [Fact]
    public void RemoveByValue_Empty()
    {
        var dll = new DoublyLinkedList<string>();
        dll.RemoveByValue("a");
        
        Assert.Empty(dll);
    }
    
    [Fact]
    public void RemoveByValue_NotFound()
    {
        var dll = new DoublyLinkedList<string>("b");
        dll.RemoveByValue("a");
        
        Assert.Equal(new[] {"b"}, dll);
    }
    
    [Fact]
    public void RemoveByValue_InMiddle()
    {
        var dll = new DoublyLinkedList<string>("a", "b", "c");
        dll.RemoveByValue("b");
        
        Assert.Equal(new[] {"a", "c"}, dll);
        Assert.Equal(new[] {"c", "a"}, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void RemoveByValue_Last()
    {
        var dll = new DoublyLinkedList<string>("a", "b", "c");
        dll.RemoveByValue("c");
        
        Assert.Equal(new[] {"a", "b"}, dll);
        Assert.Equal(new[] {"b", "a"}, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void RemoveByValue_First()
    {
        var dll = new DoublyLinkedList<string>("a", "b", "c");
        dll.RemoveByValue("a");
        
        Assert.Equal(new[] {"b", "c"}, dll);
        Assert.Equal(new[] {"c", "b"}, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void RemoveFirst()
    {
        var dll = new DoublyLinkedList<string>("a", "b", "c");
        dll.RemoveFirst();
        
        Assert.Equal(new[] {"b", "c"}, dll);
        Assert.Equal(new[] {"c", "b"}, dll.EnumerateBackwards());
    }
}
using System.Runtime.InteropServices;
using DataStructures.LinkedList;

namespace Tests;

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
        
        Assert.Equal(new[] {"Foo", "Bar"}, dll);
        Assert.Equal(new[] {"Bar", "Foo"}, dll.EnumerateBackwards());
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
        
        Assert.Equal(new[] {"Foo", "Bar"}, dll);
        Assert.Equal(new[] {"Bar", "Foo"}, dll.EnumerateBackwards());
    }
    
    [Fact]
    public void InsertValues()
    {
        var dll = new DoublyLinkedList<string>();
        dll.InsertValues("a", "b", "c");
        
        Assert.Equal(new[] {"a", "b", "c"}, dll);
        Assert.Equal(new[] {"c", "b", "a"}, dll.EnumerateBackwards());
    }
}
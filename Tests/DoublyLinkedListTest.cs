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
        var dll = new DoublyLinkedList<string>();
        dll.InsertAtStart("Bar");
        dll.InsertAtStart("Foo");
        
        Assert.Equal(new[] {"Foo", "Bar"}, dll);
        Assert.Equal(new[] {"Bar", "Foo"}, dll.EnumerateBackwards());
    }
}
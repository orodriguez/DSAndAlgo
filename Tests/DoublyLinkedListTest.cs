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
}
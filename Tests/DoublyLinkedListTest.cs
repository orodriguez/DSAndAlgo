using DataStructures.LinkedList;

namespace Tests;

public class DoublyLinkedListTest
{
    [Fact]
    public void Constructor_HeadIsNull()
    {
        var dll = new DoublyLinkedList<int>();
        
        Assert.Equal(new[] {1, 2}, dll);
    }
}
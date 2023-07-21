namespace Tests;

public class DoublyLinkedListTest
{
    [Fact]
    public void ToArray()
    {
        var dll = new DoublyLinkedList<int>(1, 2);
        
        Assert.Equal(new[] {1, 2}, dll.ToArray());
    }
}

public class DoublyLinkedList<T>
{
    public DoublyLinkedList(params T[] values)
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }
}
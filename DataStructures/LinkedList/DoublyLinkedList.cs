using System.Collections;

namespace DataStructures.LinkedList;

public class DoublyLinkedList<T> : ILinkedList<T>
{
    public DoublyLinkedList(params T[] values)
    {
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        throw new NotImplementedException();
    }

    public Node<T>? Head { get; }

    public void InsertAtStart(T value)
    {
        throw new NotImplementedException();
    }

    public void InsertAtEnd(T value)
    {
        throw new NotImplementedException();
    }

    public void InsertValues(params T[] values)
    {
        throw new NotImplementedException();
    }

    public void InsertAt(int index, T value)
    {
        throw new NotImplementedException();
    }

    public void InsertAfterValue(T existingValue, T value)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

    public void RemoveByValue(T value)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
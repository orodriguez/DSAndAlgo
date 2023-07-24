using System.Collections;

namespace DataStructures.LinkedList;

public class DoublyLinkedList<T> : ILinkedList<T>
{
    private Node? Head { get; set; } = null;

    private Node? Last { get; set; } = null;

    public void InsertAtStart(T value) => 
        Head = new Node(value);

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
        for (var itr = Head; itr != null; itr = itr.Next)
            yield return itr.Value; 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }

        public Node(T value, Node? next = null, Node? previous = null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
}
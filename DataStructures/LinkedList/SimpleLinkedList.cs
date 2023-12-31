using System.Collections;

namespace DataStructures.LinkedList;

public class SimpleLinkedList<T> : ILinkedList<T>
{
    public Node? Head { get; private set; }

    private SimpleLinkedList() => 
        Head = null;

    public SimpleLinkedList(params T[] values) : this() => 
        InsertValues(values);

    public void InsertAtStart(T value)
    {
        var node = new Node(value, Head);
        Head = node;
    }

    public void InsertAtEnd(T value)
    {
        if (Head == null)
        {
            Head = new Node(value);
            return;
        }

        var itr = Head;

        while (itr.Next != null) 
            itr = itr.Next;

        itr.Next = new Node(value);
    }

    public void InsertValues(params T[] values)
    {
        Head = null;
        foreach (var value in values) 
            InsertAtEnd(value);
    }

    public void InsertAt(int index, T value)
    {
        if (index < 0 || index > Count())
            throw new Exception("Invalid Index");

        if (index == 0)
        {
            InsertAtStart(value);
            return;
        }

        var currentIndex = 0;
        var itr = Head;
        while (itr != null)
        {
            if (currentIndex == index - 1)
            {
                var node = new Node(value, itr.Next);
                itr.Next = node;
                break;
            }

            itr = itr.Next;
            currentIndex++;
        }
    }

    public void InsertAfterValue(T existingValue, T value)
    {
        if (Head == null)
            return;

        for (var itr = Head; itr != null; itr = itr.Next)
        {
            if (itr.Value != null && itr.Value.Equals(existingValue))
            {
                itr.Next = new Node(value, itr.Next);
                break;
            }
        }
    }

    public int Count()
    {
        var count = 0;
        var itr = Head;
        while (itr != null)
        {
            count++;
            itr = itr.Next;
        }

        return count;
    }

    public void RemoveByValue(T value)
    {
        if (Head == null)
            return;

        if (Head.Value != null && Head.Value.Equals(value))
        {
            Head = Head.Next;
            return;
        }
        
        for (var itr = Head; itr != null; itr = itr.Next)
        {
            if (itr.Next != null && itr.Next.Value != null && itr.Next.Value.Equals(value))
            {
                itr.Next = itr.Next.Next;
                break;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var itr = Head; itr != null; itr = itr.Next)
            yield return itr.Value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public class Node
    {
        public Node(T value, Node? next = null)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; set; }
        public Node? Next { get; set; }
    }
}
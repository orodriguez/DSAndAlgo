using System.Collections;
using System.Runtime.InteropServices.ObjectiveC;

namespace DataStructures.LinkedList;

public class DoublyLinkedList<T> : ILinkedList<T>
{
    private Node? Head { get; set; } = null;
    private Node? Last { get; set; } = null;

    public DoublyLinkedList(params T[] values) =>
        InsertValues(values);

    public void InsertAtStart(T value)
    {
        var node = new Node(value);
        if (Head == null)
        {
            Head = node;
            Last = node;
            return;
        }

        Head.Previous = node;
        node.Next = Head;
        Head = node;
    }

    public void InsertAtEnd(T value)
    {
        var node = new Node(value);
        if (Last == null)
        {
            InsertAtStart(value);
            return;
        }

        Last.Next = node;
        node.Previous = Last;
        Last = node;
    }

    public void InsertValues(params T[] values)
    {
        foreach (var value in values) InsertAtEnd(value);
    }

    public void InsertAt(int index, T value)
    {
        switch (index)
        {
            case < 0:
                throw new Exception("Invalid Index");
            case 0:
                InsertAtStart(value);
                return;
        }

        var currentIndex = 0;
        var itr = Head;
        while (itr != null && currentIndex < index)
        {
            currentIndex++;
            itr = itr.Next;
        }

        switch (itr)
        {
            case null when index > currentIndex:
                throw new Exception("Invalid Index");
            case null:
                return;
        }

        var node = new Node(value, itr, itr.Previous);
        itr.Previous!.Next = node;
        itr.Previous = node;
    }

    public void InsertAfterValue(T existingValue, T value)
    {
        var existingNode = FindNodeByValue(existingValue);

        if (existingNode == null)
            return;

        if (existingNode.Next == null)
        {
            InsertAtEnd(value);
            return;
        }

        var newNode = new Node(value, existingNode.Next, existingNode);

        existingNode.Next.Previous = newNode;
        existingNode.Next = newNode;
    }

    public int Count()
    {
        if (Head == null)
            return 0;

        if (Head == Last)
            return 1;

        var itr = Head;
        var count = 0;
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

        if (Head.Value.Equals(value))
        {
            RemoveFirst();
            return;
        }

        if (Last.Value.Equals(value))
        {
            RemoveLast();
            return;
        }

        var existingNode = FindNodeByValue(value);

        if (existingNode == null)
            return;

        var previousNode = existingNode.Previous;
        var nextNode = existingNode.Next;

        if (nextNode == null)
        {
            previousNode.Next = null;
            Last = previousNode;
            return;
        }

        previousNode.LinkTo(nextNode);
    }

    public void RemoveFirst()
    {
        if (Head == null)
            return;

        if (Head == Last)
        {
            Head = null;
            Last = null;
            return;
        }

        Head = Head.Next;
        Head.Previous = null;
    }

    private void RemoveLast()
    {
        if (Last == null)
            return;

        if (Head == Last)
        {
            Head = null;
            Last = null;
            return;
        }

        Last = Last.Previous;
        Last.Next = null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var itr = Head; itr != null; itr = itr.Next)
            yield return itr.Value;
    }

    public IEnumerable<T> EnumerateBackwards()
    {
        for (var itr = Last; itr != null; itr = itr.Previous)
            yield return itr.Value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private Node? FindNodeByValue(T existingValue)
    {
        var itr = Head;
        while (itr != null)
        {
            if (itr.Value != null && itr.Value.Equals(existingValue))
                return itr;

            itr = itr.Next;
        }

        return null;
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

        public void LinkTo(Node node)
        {
            Next = node;
            node.Previous = this;
        }
    }
}
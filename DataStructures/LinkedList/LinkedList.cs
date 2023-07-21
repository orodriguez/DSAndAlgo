namespace DataStructures.LinkedList;

public class LinkedList<T> : ILinkedList<T>
{
    public Node<T>? Head { get; private set; }

    public LinkedList()
    {
        Head = null;
    }

    public LinkedList(T value) 
    {
        Head = new Node<T>(value);
    }

    public void InsertAtStart(T value)
    {
        var node = new Node<T>(value, Head);
        Head = node;
    }

    public override string ToString()
    {
        if (Head == null)
            return "List is empty";
        
        var result = "";

        for (var itr = Head; itr != null; itr = itr.Next)
        {
            if (itr.Next != null)
                result += itr.Value + " --> ";
            else
                result += itr.Value;
        }

        return $"LinkedList({result})";
    }

    public void InsertAtEnd(T value)
    {
        if (Head == null)
        {
            Head = new Node<T>(value);
            return;
        }

        var itr = Head;

        while (itr.Next != null) 
            itr = itr.Next;

        itr.Next = new Node<T>(value);
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
                var node = new Node<T>(value, itr.Next);
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
                itr.Next = new Node<T>(value, itr.Next);
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
}
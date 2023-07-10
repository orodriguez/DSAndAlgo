namespace Tests;

public class LinkedListTests
{
    [Fact]
    public void Constructor()
    {
        var ll = new LinkedList<string>();

        Assert.Null(ll.Head);
    }

    [Fact]
    public void ConvertToString_Empty()
    {
        var ll = new LinkedList<string>();

        Assert.Equal("List is empty", ll.ToString());
    }

    [Fact]
    public void ConvertToString_OneElement()
    {
        var ll = new LinkedList<string>("Foo");

        Assert.Equal("LinkedList(Foo)", ll.ToString());
    }

    [Fact]
    public void InsertAtStart()
    {
        var ll = new LinkedList<string>("Bar");

        ll.InsertAtStart("Foo");
        
        Assert.Equal("LinkedList(Foo --> Bar)", ll.ToString());
    }

    [Fact]
    public void InsertAtEnd()
    {
        var ll = new LinkedList<string>("Foo");

        ll.InsertAtEnd("Bar");
        
        Assert.Equal("LinkedList(Foo --> Bar)", ll.ToString());
    }
    
    [Fact]
    public void InsertValues()
    {
        var ll = new LinkedList<string>();

        ll.InsertValues("Foo", "Bar");
        
        Assert.Equal("LinkedList(Foo --> Bar)", ll.ToString());
    }
    
    [Fact]
    public void InsertAt()
    {
        var ll = new LinkedList<int>();
        
        ll.InsertValues(1, 3);
        
        ll.InsertAt(1, 2);
        
        Assert.Equal("LinkedList(1 --> 2 --> 3)", ll.ToString());
    }

    [Fact]
    public void InsertAfterValue()
    {
        var ll = new LinkedList<string>();

        ll.InsertValues("banana", "mango", "grapes");
        
        ll.InsertAfterValue("mango", "apple");
        
        Assert.Equal("LinkedList(banana --> mango --> apple --> grapes)", ll.ToString());
    }
    
    [Fact]
    public void InsertAfterValue_Empty()
    {
        var ll = new LinkedList<string>();
        
        ll.InsertAfterValue("a", "b");

        Assert.Equal(0, ll.Count());
    }
    
    [Fact]
    public void InsertAfterValue_One()
    {
        var ll = new LinkedList<string>("mango");
        
        ll.InsertAfterValue("mango", "banana");
        Assert.Equal("LinkedList(mango --> banana)", ll.ToString());
    }
    
    [Fact]
    public void RemoveByValue()
    {
        var ll = new LinkedList<string>();
        
        ll.InsertValues("a", "b", "c");

        ll.RemoveByValue("b");
        
        Assert.Equal("LinkedList(a --> c)", ll.ToString());
    }
    
    [Fact]
    public void RemoveByValue_One()
    {
        var ll = new LinkedList<string>("a");

        ll.RemoveByValue("a");
        
        Assert.Equal(0, ll.Count());
    }
}

public class Node<T>
{
    public Node(T value, Node<T>? next = null)
    {
        Value = value;
        Next = next;
    }

    public T Value { get; set; }
    public Node<T>? Next { get; set; }
}

public class LinkedList<T>
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

        Node<T>? previous = null;
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
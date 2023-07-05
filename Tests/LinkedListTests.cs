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
    public Node<T>? Head { get; set; }

    public LinkedList() : this(null)
    {
    }

    private LinkedList(Node<T>? head) => Head = head;

    public LinkedList(T firstElement) : this(new Node<T>(firstElement))
    {
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

        var itr = Head;
        var result = "";

        while (itr != null)
        {
            if (itr.Next != null)
                result += itr.Value + " --> ";
            else
                result += itr.Value;
            itr = itr.Next;
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

    private int Count()
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
}
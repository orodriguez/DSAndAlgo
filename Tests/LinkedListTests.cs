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
}

public class Node<T>
{
    public Node(T value) => Value = value;

    public T Value { get; set; }
    public Node<T>? Next { get; set; }
}

public class LinkedList<T>
{
    public Node<T>? Head { get; }

    public LinkedList() : this(null)
    {
    }

    private LinkedList(Node<T>? head) => Head = head;

    public LinkedList(T firstElement) : this(new Node<T>(firstElement))
    {
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
}
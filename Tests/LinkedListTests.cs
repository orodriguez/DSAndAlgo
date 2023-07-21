namespace Tests;

public class LinkedListTests
{
    private readonly DataStructures.LinkedList.LinkedList<string> _subject;

    public LinkedListTests() =>
        _subject = new DataStructures.LinkedList.LinkedList<string>();

    [Fact]
    public void Constructor() =>
        Assert.Null(_subject.Head);

    [Fact]
    public void ConvertToString_Empty() => 
        Assert.Equal("List is empty", _subject.ToString());

    [Fact]
    public void ConvertToString_OneElement()
    {
        _subject.InsertValues("Foo");

        Assert.Equal("LinkedList(Foo)", _subject.ToString());
    }

    [Fact]
    public void InsertAtStart()
    {
        _subject.InsertValues("Bar");

        _subject.InsertAtStart("Foo");

        Assert.Equal("LinkedList(Foo --> Bar)", _subject.ToString());
    }

    [Fact]
    public void InsertAtEnd()
    {
        _subject.InsertValues("Foo");

        _subject.InsertAtEnd("Bar");

        Assert.Equal("LinkedList(Foo --> Bar)", _subject.ToString());
    }

    [Fact]
    public void InsertValues()
    {
        _subject.InsertValues("Foo", "Bar");

        Assert.Equal("LinkedList(Foo --> Bar)", _subject.ToString());
    }

    [Fact]
    public void InsertAt()
    {
        _subject.InsertValues("a", "c");

        _subject.InsertAt(1, "b");

        Assert.Equal("LinkedList(a --> b --> c)", _subject.ToString());
    }

    [Fact]
    public void InsertAfterValue()
    {
        _subject.InsertValues("banana", "mango", "grapes");

        _subject.InsertAfterValue("mango", "apple");

        Assert.Equal("LinkedList(banana --> mango --> apple --> grapes)", _subject.ToString());
    }

    [Fact]
    public void InsertAfterValue_Empty()
    {
        _subject.InsertAfterValue("a", "b");

        Assert.Equal(0, _subject.Count());
    }

    [Fact]
    public void InsertAfterValue_One()
    {
        _subject.InsertValues("mango");

        _subject.InsertAfterValue("mango", "banana");
        Assert.Equal("LinkedList(mango --> banana)", _subject.ToString());
    }

    [Fact]
    public void RemoveByValue()
    {
        _subject.InsertValues("a", "b", "c");

        _subject.RemoveByValue("b");

        Assert.Equal("LinkedList(a --> c)", _subject.ToString());
    }

    [Fact]
    public void RemoveByValue_One()
    {
        _subject.InsertValues("a");

        _subject.RemoveByValue("a");

        Assert.Equal(0, _subject.Count());
    }
}
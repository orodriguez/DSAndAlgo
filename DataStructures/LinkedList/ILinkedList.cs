namespace DataStructures.LinkedList;

public interface ILinkedList<T>
{
    Node<T>? Head { get; }
    void InsertAtStart(T value);
    string ToString();
    void InsertAtEnd(T value);
    void InsertValues(params T[] values);
    void InsertAt(int index, T value);
    void InsertAfterValue(T existingValue, T value);
    int Count();
    void RemoveByValue(T value);
}
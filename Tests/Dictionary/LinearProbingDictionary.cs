using System.Collections;
using static System.Math;

namespace Tests.Dictionary;

public class LinearProbingDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : notnull
{
    private readonly KeyValuePair<TKey, TValue>[] _pairs = new KeyValuePair<TKey, TValue>[10];

    private Func<TKey, int> Hash { get; set; }

    public LinearProbingDictionary()
    {
        Hash = key => int.Abs(key.GetHashCode() % 10);
    }

    public LinearProbingDictionary(Func<TKey, int> hash)
    {
        Hash = hash;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        var hash = Hash(item.Key);
        while (_pairs[hash].Equals(null))
        {
            hash++;
        }

        _pairs[hash] = item;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }

    public bool IsReadOnly { get; }

    public void Add(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }

    public bool ContainsKey(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        throw new NotImplementedException();
    }

    public TValue this[TKey key]
    {
        get => _pairs[Hash(key)].Value;
        set => Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public ICollection<TKey> Keys { get; }

    public ICollection<TValue> Values { get; }
}
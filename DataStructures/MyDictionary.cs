using System.Collections;

namespace DataStructures;

public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
    private readonly LinkedList<KeyValuePair<TKey, TValue>>[] _buckets;

    public MyDictionary()
    {
        _buckets = new LinkedList<KeyValuePair<TKey, TValue>>[10];
        for (var i = 0; i < 10; i++) 
            _buckets[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
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
        var bucket = GetBucketByKey(item.Key);
        bucket.AddLast(item);
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
    public void Add(TKey key, TValue value) => 
        Add(new KeyValuePair<TKey, TValue>(key, value));

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
        get => Get(key);
        set => Add(key, value);
    }

    private TValue Get(TKey key)
    {
        var bucket = GetBucketByKey(key);
        return bucket.First(pair => pair.Key!.Equals(key)).Value;
    }

    public ICollection<TKey> Keys { get; }

    public ICollection<TValue> Values { get; }

    private LinkedList<KeyValuePair<TKey, TValue>> GetBucketByKey(TKey key)
    {
        var hashCode = CustomHash(key);
        var bucket = _buckets[hashCode];
        return bucket;
    }

    private int CustomHash(TKey key)
    {
        var hasCode = key.GetHashCode().ToString().Last();
        return hasCode % 10;
    }
}
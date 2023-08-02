using System.Collections;
using System.IO.Pipes;
using static System.Math;

namespace Tests.Dictionary;

public class LinearProbingDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : notnull
{
    private const int InitialCapacity = 10;
    private const int Capacity = InitialCapacity;

    private KeyValuePair<TKey, TValue>[] _pairs = 
        new KeyValuePair<TKey, TValue>[Capacity];

    private Func<TKey, int> Hash { get; set; }


    public LinearProbingDictionary() => 
        Hash = key => int.Abs(key.GetHashCode()) % Capacity;

    public LinearProbingDictionary(Func<TKey, int> hash) => 
        Hash = hash;

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>
        _pairs
            .Where(pair => !pair.Equals(default(KeyValuePair<TKey, TValue>)))
            .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        var currentIndex = Hash(item.Key);
        while (!_pairs[currentIndex].Equals(default(KeyValuePair<TKey, TValue>)))
        {
            if (_pairs[currentIndex].Key.Equals(item.Key))
            {
                _pairs[currentIndex] = new KeyValuePair<TKey, TValue>(
                    item.Key, item.Value);
                return;
            }

            currentIndex = (currentIndex + 1) % Capacity;
        }

        _pairs[currentIndex] = item;
    }

    public void Clear()
    {
        _pairs = new KeyValuePair<TKey, TValue>[InitialCapacity];
    }

    public bool Contains(KeyValuePair<TKey, TValue> item) => 
        _pairs.Any(pair => 
            EqualityComparer<TKey>.Default.Equals(pair.Key, item.Key) 
            && EqualityComparer<TValue>.Default.Equals(pair.Value, item.Value));

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

    public bool ContainsKey(TKey key) => 
        _pairs.Any(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key));

    public bool Remove(TKey key)
    {
        var index = FindIndex(key);
        if (index == -1)
            return false;
        
        _pairs[index] = default;
        return true;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var index = FindIndex(key);
        value = _pairs[index].Value;
        return true;
    }

    public TValue this[TKey key]
    {
        get => GetValue(key);
        set => Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public ICollection<TKey> Keys => _pairs
        .Where(pair => !EqualityComparer<KeyValuePair<TKey, TValue>>.Default
            .Equals(pair, default(KeyValuePair<TKey, TValue>)))
        .Select(pair => pair.Key)
        .ToArray();

    public ICollection<TValue> Values { get; }

    private TValue GetValue(TKey key)
    {
        TryGetValue(key, out var value);
        if (EqualityComparer<TValue>.Default.Equals(value, default))
            throw new KeyNotFoundException();
        return value;
    }

    private int FindIndex(TKey key)
    {
        var firstIndex = Hash(key);
        var currentIndex = firstIndex;
        var currentPair = _pairs[currentIndex];
        while (!currentPair.Equals(default(KeyValuePair<TKey, TValue>)))
        {
            if (currentPair.Key.Equals(key))
                return currentIndex;

            currentIndex = (currentIndex + 1) % Capacity;
            currentPair = _pairs[currentIndex];

            if (currentIndex == firstIndex)
                break;
        }
        return -1;
    }
}
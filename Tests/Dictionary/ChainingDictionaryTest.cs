using DataStructures;

namespace Tests.Dictionary;

public class ChainingDictionaryTest : AbstractDictionaryTest
{
    protected override IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>() => 
        new ChainingDictionary<TKey, TValue>();

    protected override IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>(Func<TKey, int> hash) => 
        new ChainingDictionary<TKey, TValue>(hash);
}
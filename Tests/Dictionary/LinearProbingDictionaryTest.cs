namespace Tests.Dictionary;

public class LinearProbingDictionaryTest : AbstractDictionaryTest
{
    protected override IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>() => 
        new LinearProbingDictionary<TKey, TValue>();

    protected override IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>(Func<TKey, int> hash) => 
        new LinearProbingDictionary<TKey, TValue>(hash);
}
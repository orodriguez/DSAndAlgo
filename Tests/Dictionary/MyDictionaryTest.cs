namespace Tests.Dictionary;

public class MyDictionaryTest : AbstractDictionaryTest
{
    protected override IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>() => 
        new Dictionary<TKey, TValue>();
}
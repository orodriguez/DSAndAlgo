namespace Tests.Dictionary;

public class DictionaryTest : AbstractDictionaryTest
{
    protected override IDictionary<TKey, TValue> CreateEmptyDictionary<TKey, TValue>() => 
        new Dictionary<TKey, TValue>();
}
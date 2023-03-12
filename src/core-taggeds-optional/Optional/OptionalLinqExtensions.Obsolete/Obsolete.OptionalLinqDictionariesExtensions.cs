using System.Collections.Generic;

namespace System.Linq;

// TODO: Remove the class in v3.0
[Obsolete("This class is obsolete. Use GetValueOrAbsent extension methods instead.", error: true)]
public static class OptionalLinqDictionariesExtensions
{
    private const string ObsoleteMessage_GetValueOrAbsent
        =
        "This method is obsolete. Call GetValueOrAbsent extension method instead.";

    [Obsolete(ObsoleteMessage_GetValueOrAbsent, error: true)]
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
    {
        _ = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

        return dictionary.GetValueOrAbsent(key);
    }

    [Obsolete(ObsoleteMessage_GetValueOrAbsent, error: true)]
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
    {
        _ = pairs ?? throw new ArgumentNullException(nameof(pairs));

        return pairs.GetValueOrAbsent(key);
    }
}

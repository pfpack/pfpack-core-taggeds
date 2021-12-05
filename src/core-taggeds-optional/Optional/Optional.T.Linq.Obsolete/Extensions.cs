using System.Collections.Generic;

namespace System.Linq;

// TODO: Consider to remove the class in v3.0
[Obsolete(InnerObsoleteMessage, error: true)]
public static class OptionalLinqDictionariesExtensions
{
    private const string InnerObsoleteMessage
        =
        $"This class is obsolete. Use {nameof(OptionalLinqExtensions.GetValueOrAbsent)} extension methods instead.";

    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
    {
        _ = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

        return dictionary.GetValueOrAbsent(key);
    }

    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
    {
        _ = pairs ?? throw new ArgumentNullException(nameof(pairs));

        return pairs.GetValueOrAbsent(key);
    }
}

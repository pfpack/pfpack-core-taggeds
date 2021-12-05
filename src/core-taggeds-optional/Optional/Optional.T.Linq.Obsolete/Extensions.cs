using System.Collections.Generic;

namespace System.Linq;

// TODO: Consider to remove the class in v3.0
[Obsolete(InnerClassObsoleteMessage, error: true)]
public static class OptionalLinqDictionariesExtensions
{
    private const string InnerClassObsoleteMessage
        =
        $"This class is obsolete. Use {InnerGetValueOrAbsentActual} extension methods instead.";

    private const string InnerMethodObsoleteMessage
        =
        $"This method is obsolete. Call {InnerGetValueOrAbsentActual} extension method instead.";

    private const string InnerGetValueOrAbsentActual
        =
        nameof(OptionalLinqExtensions.GetValueOrAbsent);

    [Obsolete(InnerMethodObsoleteMessage, error: true)]
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IReadOnlyDictionary<TKey, TValue> dictionary,
        TKey key)
    {
        _ = dictionary ?? throw new ArgumentNullException(nameof(dictionary));

        return dictionary.GetValueOrAbsent(key);
    }

    [Obsolete(InnerMethodObsoleteMessage, error: true)]
    public static Optional<TValue> GetValueOrAbsent<TKey, TValue>(
        IEnumerable<KeyValuePair<TKey, TValue>> pairs,
        TKey key)
    {
        _ = pairs ?? throw new ArgumentNullException(nameof(pairs));

        return pairs.GetValueOrAbsent(key);
    }
}

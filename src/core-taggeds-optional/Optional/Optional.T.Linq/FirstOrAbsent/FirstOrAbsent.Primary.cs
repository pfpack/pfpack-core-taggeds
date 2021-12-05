using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> FirstOrAbsent<TSource>(
        this IEnumerable<TSource> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source.InnerFirstOrAbsentPrimary();
    }

    public static Optional<TSource> FirstOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        return source.InnerFirstOrAbsentPrimary(predicate);
    }
}

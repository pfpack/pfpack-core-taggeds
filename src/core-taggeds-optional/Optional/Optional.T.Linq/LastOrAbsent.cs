using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> LastOrAbsent<TSource>(
        this IEnumerable<TSource> source)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));

        return source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerLastOrAbsent(),

            IList<TSource> list
            =>
            list.InnerLastOrAbsent(),

            _ =>
            source.InnerLastOrAbsent()
        };
    }

    public static Optional<TSource> LastOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        _ = source ?? throw new ArgumentNullException(nameof(source));
        _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

        return source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerLastOrAbsent(predicate),

            IList<TSource> list
            =>
            list.InnerLastOrAbsent(predicate),

            _ =>
            source.InnerLastOrAbsent(predicate)
        };
    }
}

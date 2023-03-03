using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> LastOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        InnerLastOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)));

    public static Optional<TSource> LastOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerLastOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));
}

using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> FirstOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        InnerFirstOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)));

    public static Optional<TSource> FirstOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerFirstOrAbsentPrimary(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));
}

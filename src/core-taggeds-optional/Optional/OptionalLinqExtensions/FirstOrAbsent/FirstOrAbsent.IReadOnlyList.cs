using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    public static Optional<TSource> FirstOrAbsent<TSource>(
        this IReadOnlyList<TSource> source)
        =>
        InnerFirstOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)));

    public static Optional<TSource> FirstOrAbsent<TSource>(
        this IReadOnlyList<TSource> source,
        Func<TSource, bool> predicate)
        =>
        InnerFirstOrAbsent(
            source ?? throw new ArgumentNullException(nameof(source)),
            predicate ?? throw new ArgumentNullException(nameof(predicate)));
}

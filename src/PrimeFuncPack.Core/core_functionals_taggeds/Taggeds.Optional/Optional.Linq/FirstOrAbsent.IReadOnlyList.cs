#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> FirstOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return source.InternalFirstOrAbsent();
        }

        public static Optional<TSource> FirstOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in Func<TSource, bool> predicate)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return source.InternalFirstOrAbsent(predicate);
        }
    }
}

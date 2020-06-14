#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> LastOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.InternalLastOrAbsent();
        }

        public static Optional<TSource> LastOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in Func<TSource, bool> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return source.InternalLastOrAbsent(predicate);
        }
    }
}

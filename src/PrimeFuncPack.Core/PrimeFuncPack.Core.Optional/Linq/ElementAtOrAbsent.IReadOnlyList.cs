#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> ElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in int index)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.InternalElementAtOrAbsent(index);
        }

        public static Optional<TSource> ElementAtOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in long index)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.InternalElementAtOrAbsent(index);
        }
    }
}

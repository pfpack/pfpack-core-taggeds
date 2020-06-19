#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> ElementAtOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in int index)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source switch
            {
                IReadOnlyList<TSource> list
                =>
                list.InternalElementAtOrAbsent(index),

                IList<TSource> list
                =>
                list.InternalElementAtOrAbsent(index),

                var enumerable
                =>
                enumerable.InternalElementAtOrAbsent(index)
            };
        }

        public static Optional<TSource> ElementAtOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in long index)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source switch
            {
                IReadOnlyList<TSource> list
                =>
                list.InternalElementAtOrAbsent(index),

                IList<TSource> list
                =>
                list.InternalElementAtOrAbsent(index),

                var enumerable
                =>
                enumerable.InternalElementAtOrAbsent(index)
            };
        }
    }
}

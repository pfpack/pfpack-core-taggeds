#nullable enable

using PrimeFuncPack;
using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source switch
            {
                IReadOnlyList<TSource> list
                =>
                list.InternalSingleOrAbsent(),

                IList<TSource> list
                =>
                list.InternalSingleOrAbsent(),

                var enumerable
                =>
                enumerable.InternalSingleOrAbsent()
            };
        }

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
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

            return source switch
            {
                IReadOnlyList<TSource> list
                =>
                list.InternalSingleOrAbsent(predicate),

                IList<TSource> list
                =>
                list.InternalSingleOrAbsent(predicate),

                var enumerable
                =>
                enumerable.InternalSingleOrAbsent(predicate)
            };
        }
    }
}

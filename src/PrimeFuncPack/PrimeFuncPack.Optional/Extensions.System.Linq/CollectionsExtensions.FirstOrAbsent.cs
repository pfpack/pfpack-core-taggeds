#nullable enable

using PrimeFuncPack;
using PrimeFuncPack.Extensions.System.Linq.Internal;
using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> FirstOrAbsent<TSource>(
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
                list.InternalFirstOrAbsent(),

                IList<TSource> list
                =>
                list.InternalFirstOrAbsent(),

                var enumerable
                =>
                enumerable.InternalFirstOrAbsent()
            };
        }

        public static Optional<TSource> FirstOrAbsent<TSource>(
            this IEnumerable<TSource> source, in Func<TSource, bool> predicate)
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
                list.InternalFirstOrAbsent(predicate),

                IList<TSource> list
                =>
                list.InternalFirstOrAbsent(predicate),

                var enumerable
                =>
                enumerable.InternalFirstOrAbsent(predicate)
            };
        }
    }
}

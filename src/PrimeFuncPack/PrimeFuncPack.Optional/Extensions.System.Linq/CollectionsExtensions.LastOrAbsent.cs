#nullable enable

using PrimeFuncPack;
using PrimeFuncPack.Extensions.System.Linq.Internal;
using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> LastOrAbsent<TSource>(
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
                list.InternalLastOrAbsent(),

                IList<TSource> list
                =>
                list.InternalLastOrAbsent(),

                var enumerable
                =>
                enumerable.InternalLastOrAbsent()
            };
        }

        public static Optional<TSource> LastOrAbsent<TSource>(
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
                list.InternalLastOrAbsent(predicate),

                IList<TSource> list
                =>
                list.InternalLastOrAbsent(predicate),

                var enumerable
                =>
                enumerable.InternalLastOrAbsent(predicate)
            };
        }
    }
}

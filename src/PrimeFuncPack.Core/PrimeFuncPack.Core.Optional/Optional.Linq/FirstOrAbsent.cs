#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> FirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

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
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

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

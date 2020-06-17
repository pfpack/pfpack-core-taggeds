#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
            =>
            source.SingleOrAbsent(GetMoreThanOneElementExceptionFactory());

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in Func<Exception> moreThanOneElementExceptionFactory)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (moreThanOneElementExceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory));
            }

            return source.InternalSingleOrAbsent(moreThanOneElementExceptionFactory);
        }

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in Func<TSource, bool> predicate)
            =>
            source.SingleOrAbsent(predicate, GetMoreThanOneMatchExceptionFactory());

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in Func<TSource, bool> predicate,
            in Func<Exception> moreThanOneMatchExceptionFactory)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (moreThanOneMatchExceptionFactory is null)
            {
                throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory));
            }

            return source.InternalSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory);
        }
    }
}

#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IEnumerable<TSource> source)
            =>
            source.SingleOrAbsent(CreateMoreThanOneElementException);

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<Exception> moreThanOneElementExceptionFactory)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = moreThanOneElementExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneElementExceptionFactory));

            return source switch
            {
                IReadOnlyList<TSource> list
                =>
                list.InternalSingleOrAbsent(moreThanOneElementExceptionFactory),

                IList<TSource> list
                =>
                list.InternalSingleOrAbsent(moreThanOneElementExceptionFactory),

                var enumerable
                =>
                enumerable.InternalSingleOrAbsent(moreThanOneElementExceptionFactory)
            };
        }

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate)
            =>
            source.SingleOrAbsent(predicate, CreateMoreThanOneMatchException);

        public static Optional<TSource> SingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate,
            in Func<Exception> moreThanOneMatchExceptionFactory)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = moreThanOneMatchExceptionFactory ?? throw new ArgumentNullException(nameof(moreThanOneMatchExceptionFactory));

            return source switch
            {
                IReadOnlyList<TSource> list
                =>
                list.InternalSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory),

                IList<TSource> list
                =>
                list.InternalSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory),

                var enumerable
                =>
                enumerable.InternalSingleOrAbsent(predicate, moreThanOneMatchExceptionFactory)
            };
        }
    }
}

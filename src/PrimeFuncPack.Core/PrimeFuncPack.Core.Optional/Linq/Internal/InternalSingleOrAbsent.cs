#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (enumerator.MoveNext())
                {
                    throw CreateMoreThanOneElementException();
                }

                return Optional.Present(current);
            }

            return default;
        }

        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate)
        {
            using var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (predicate.Invoke(current))
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                        {
                            throw CreateMoreThanOneMatchException();
                        }
                    }

                    return Optional.Present(current);
                }
            }

            return default;
        }
    }
}

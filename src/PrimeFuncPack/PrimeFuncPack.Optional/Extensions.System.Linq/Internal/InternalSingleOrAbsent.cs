#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                var result = Optional.Present(enumerator.Current);

                if (enumerator.MoveNext())
                {
                    throw CreateMoreThanOneElementException();
                }

                return result;
            }

            return default;
        }

        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate)
        {
            Optional<TSource> result = default;

            foreach (var current in source)
            {
                if (predicate.Invoke(current))
                {
                    if (result.IsPresent)
                    {
                        throw CreateMoreThanOneMatchException();
                    }

                    result = Optional.Present(current);
                }
            }

            return result;
        }
    }
}

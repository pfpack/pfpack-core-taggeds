#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                return Optional.Present(enumerator.Current);
            }

            return default;
        }

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate)
        {
            foreach (var current in source)
            {
                if (predicate.Invoke(current))
                {
                    return Optional.Present(current);
                }
            }

            return default;
        }
    }
}

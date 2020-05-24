#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                return Optional.PresentEvenIfNull(enumerator.Current);
            }

            return default;
        }

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source, in Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return Optional.PresentEvenIfNull(item);
                }
            }

            return default;
        }
    }
}

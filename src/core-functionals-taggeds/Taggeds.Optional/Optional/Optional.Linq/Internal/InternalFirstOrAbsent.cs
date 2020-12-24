﻿#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            return enumerator.MoveNext() switch
            {
                true => Optional.Present(enumerator.Current),
                _ => default
            };
        }

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
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

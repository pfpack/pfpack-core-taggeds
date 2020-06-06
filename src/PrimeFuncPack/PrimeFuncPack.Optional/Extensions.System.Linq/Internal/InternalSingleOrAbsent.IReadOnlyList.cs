#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
            =>
            source.Count switch
            {
                var count when count > 1 => throw CreateMoreThanOneElementException(),

                1 => Optional.Present(source[0]),

                _ => default
            };

        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            in Func<TSource, bool> predicate)
        {
            Optional<TSource> result = default;

            for (var i = 0; i < source.Count; i++)
            {
                var current = source[i];

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

#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IList<TSource> source)
            =>
            source.Count switch
            {
                var count when count > 1 => throw CreateMoreThanOneElementException(),

                1 => Optional.Present(source[0]),

                _ => default
            };

        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IList<TSource> source,
            in Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Count; i++)
            {
                var current = source[i];

                if (predicate.Invoke(current))
                {
                    if (i < source.Count - 1)
                    {
                        for (var j = i + 1; j < source.Count; j++)
                        {
                            if (predicate.Invoke(source[j]))
                            {
                                throw CreateMoreThanOneMatchException();
                            }
                        }
                    }

                    return Optional.Present(current);
                }
            }

            return default;
        }
    }
}

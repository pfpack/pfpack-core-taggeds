#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            Optional<TSource> result = default;

            foreach (var current in source)
            {
                result = Optional.Present(current);
            }

            return result;
        }

        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            in Func<TSource, bool> predicate)
        {
            Optional<TSource> result = default;

            foreach (var current in source)
            {
                if (predicate.Invoke(current))
                {
                    result = Optional.Present(current);
                }
            }

            return result;
        }
    }
}

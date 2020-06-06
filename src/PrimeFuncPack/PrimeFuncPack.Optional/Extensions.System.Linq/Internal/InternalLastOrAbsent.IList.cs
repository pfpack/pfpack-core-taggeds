#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IList<TSource> source)
        {
            if (source.Count > 0)
            {
                return Optional.Present(source[^1]);
            }

            return default;
        }

        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IList<TSource> source, in Func<TSource, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

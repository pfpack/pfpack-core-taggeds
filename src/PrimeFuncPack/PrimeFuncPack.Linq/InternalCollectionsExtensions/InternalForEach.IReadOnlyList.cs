#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static IReadOnlyList<TSource> InternalForEach<TSource>(
           this IReadOnlyList<TSource> source,
           in Action<TSource> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action.Invoke(source[i]);
            }

            return source;
        }

        public static IReadOnlyList<TSource> InternalForEach<TSource>(
           this IReadOnlyList<TSource> source,
           in Action<int, TSource> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action.Invoke(i, source[i]);
            }

            return source;
        }

        public static IReadOnlyList<TSource> InternalForEach<TSource>(
           this IReadOnlyList<TSource> source,
           in Action<long, TSource> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action.Invoke(i, source[i]);
            }

            return source;
        }
    }
}

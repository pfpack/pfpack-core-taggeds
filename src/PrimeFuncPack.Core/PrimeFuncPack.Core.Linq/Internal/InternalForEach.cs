#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<TSource> action)
        {
            foreach (var current in source)
            {
                action.Invoke(current);
            }
        }

        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<int, TSource> action)
        {
            int currentIndex = -1;

            foreach (var current in source)
            {
                checked { currentIndex++; }

                action.Invoke(currentIndex, current);
            }
        }

        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<long, TSource> action)
        {
            long currentIndex = -1;

            foreach (var current in source)
            {
                checked { currentIndex++; }

                action.Invoke(currentIndex, current);
            }
        }
    }
}

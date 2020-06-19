#nullable enable

using System.Collections.Generic;

namespace System.Linq
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
                currentIndex = unchecked(++currentIndex) & int.MaxValue;

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
                currentIndex = unchecked(++currentIndex) & long.MaxValue;

                action.Invoke(currentIndex, current);
            }
        }
    }
}

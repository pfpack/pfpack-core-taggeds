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
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                int currentIndex = -1;

                do
                {
                    checked { currentIndex++; }

                    action.Invoke(currentIndex, enumerator.Current);
                }
                while (enumerator.MoveNext());
            }
        }

        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<long, TSource> action)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                long currentIndex = -1;

                do
                {
                    checked { currentIndex++; }

                    action.Invoke(currentIndex, enumerator.Current);
                }
                while (enumerator.MoveNext());
            }
        }
    }
}

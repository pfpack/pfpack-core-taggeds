#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static void InternalForEach<TSource>(
           this IList<TSource> source,
           in Action<TSource> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action.Invoke(source[i]);
            }
        }

        public static void InternalForEach<TSource>(
           this IList<TSource> source,
           in Action<int, TSource> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action.Invoke(i, source[i]);
            }
        }

        public static void InternalForEach<TSource>(
           this IList<TSource> source,
           in Action<long, TSource> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action.Invoke(i, source[i]);
            }
        }
    }
}

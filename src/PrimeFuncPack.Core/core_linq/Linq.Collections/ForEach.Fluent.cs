#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static TCollection ForEach<TCollection, TSource>(
            this TCollection source,
            Action<TSource> action)
            where TCollection : IEnumerable<TSource>
        {
            source.ForEach<TSource>(action);
            return source;
        }

        public static TCollection ForEach<TCollection, TSource>(
            this TCollection source,
            Action<int, TSource> action)
            where TCollection : IEnumerable<TSource>
        {
            source.ForEach<TSource>(action);
            return source;
        }

        public static TCollection ForEach<TCollection, TSource>(
            this TCollection source,
            Action<long, TSource> action)
            where TCollection : IEnumerable<TSource>
        {
            source.ForEach<TSource>(action);
            return source;
        }
    }
}

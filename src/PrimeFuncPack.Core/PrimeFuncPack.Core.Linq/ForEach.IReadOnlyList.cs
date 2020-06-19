#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static IReadOnlyList<TSource> ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            in Action<TSource> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (action is null)
            {
                throw new ArgumentException(nameof(action));
            }

            source.InternalForEach(action);

            return source;
        }

        public static IReadOnlyList<TSource> ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            in Action<int, TSource> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (action is null)
            {
                throw new ArgumentException(nameof(action));
            }

            source.InternalForEach(action);

            return source;
        }

        public static IReadOnlyList<TSource> ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            in Action<long, TSource> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (action is null)
            {
                throw new ArgumentException(nameof(action));
            }

            source.InternalForEach(action);

            return source;
        }
    }
}

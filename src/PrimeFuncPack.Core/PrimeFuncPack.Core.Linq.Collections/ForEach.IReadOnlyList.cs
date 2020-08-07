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
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            source.InternalForEach(action);

            return source;
        }

        public static IReadOnlyList<TSource> ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            in Action<int, TSource> action)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            source.InternalForEach(action);

            return source;
        }

        public static IReadOnlyList<TSource> ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            in Action<long, TSource> action)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            source.InternalForEach(action);

            return source;
        }
    }
}

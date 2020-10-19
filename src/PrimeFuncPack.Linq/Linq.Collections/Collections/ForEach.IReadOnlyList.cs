#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static void ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            Action<TSource> action)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            source.InternalForEach(action);
        }

        public static void ForEach<TSource>(
            this IReadOnlyList<TSource> source,
            Action<int, TSource> action)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            source.InternalForEach(action);
        }
    }
}

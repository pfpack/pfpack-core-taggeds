#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static void ForEach<TSource>(
            this IEnumerable<TSource> source,
            Action<TSource> action)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            switch (source)
            {
                case IReadOnlyList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case IList<TSource> list:
                    list.InternalForEach(action);
                    break;

                default:
                    source.InternalForEach(action);
                    break;
            }
        }

        public static void ForEach<TSource>(
            this IEnumerable<TSource> source,
            Action<int, TSource> action)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            switch (source)
            {
                case IReadOnlyList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case IList<TSource> list:
                    list.InternalForEach(action);
                    break;

                default:
                    source.InternalForEach(action);
                    break;
            }
        }
    }
}

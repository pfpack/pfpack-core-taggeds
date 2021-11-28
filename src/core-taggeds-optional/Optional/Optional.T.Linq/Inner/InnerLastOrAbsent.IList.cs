using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static Optional<TSource> InnerLastOrAbsent<TSource>(
            this IList<TSource> source)
            =>
            source.Count > 0
                ? new(source[^1])
                : default;

        private static Optional<TSource> InnerLastOrAbsent<TSource>(
            this IList<TSource> source,
            Func<TSource, bool> predicate)
        {
            for (var i = source.Count - 1; i >= 0; i--)
            {
                var current = source[i];

                if (predicate.Invoke(current))
                {
                    return new(current);
                }
            }

            return default;
        }
    }
}

#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static Optional<TSource> InnerFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            return enumerator.MoveNext()
                ? new(enumerator.Current)
                : default;
        }

        private static Optional<TSource> InnerFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var current in source)
            {
                if (predicate.Invoke(current))
                {
                    return new(current);
                }
            }

            return default;
        }
    }
}

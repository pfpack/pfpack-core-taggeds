#nullable enable

using System.Collections.Generic;
using static System.Optional;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            return enumerator.MoveNext() switch
            {
                true => Present(enumerator.Current),
                _ => default
            };
        }

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            foreach (var current in source)
            {
                if (predicate.Invoke(current))
                {
                    return Present(current);
                }
            }

            return default;
        }
    }
}

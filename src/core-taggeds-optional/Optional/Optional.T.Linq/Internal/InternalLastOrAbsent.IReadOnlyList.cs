#nullable enable

using System.Collections.Generic;
using static System.Optional;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
            =>
            source.Count > 0
                ? Present(source[^1])
                : default;

        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, bool> predicate)
        {
            for (var i = source.Count - 1; i >= 0; i--)
            {
                var current = source[i];

                if (predicate.Invoke(current))
                {
                    return Present(current);
                }
            }

            return default;
        }
    }
}

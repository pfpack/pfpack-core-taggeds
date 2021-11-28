using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static Optional<TSource> InnerLastOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                TSource current;

                do
                {
                    current = enumerator.Current;
                }
                while (enumerator.MoveNext());

                return new(current);
            }

            return default;
        }

        private static Optional<TSource> InnerLastOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            using var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (predicate.Invoke(current))
                {
                    while (enumerator.MoveNext())
                    {
                        TSource next = enumerator.Current;

                        if (predicate.Invoke(next))
                        {
                            current = next;
                        }
                    }

                    return new(current);
                }
            }

            return default;
        }
    }
}

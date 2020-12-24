﻿#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalLastOrAbsent<TSource>(
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

                return Optional.Present(current);
            }

            return default;
        }

        public static Optional<TSource> InternalLastOrAbsent<TSource>(
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

                    return Optional.Present(current);
                }
            }

            return default;
        }
    }
}

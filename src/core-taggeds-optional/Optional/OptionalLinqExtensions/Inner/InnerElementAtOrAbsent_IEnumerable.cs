﻿using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsent_IEnumerable<TSource>(
        this IEnumerable<TSource> source,
        int index)
    {
        if (index >= 0)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                var countdownIndex = index;

                do
                {
                    if (countdownIndex == 0)
                    {
                        return new(enumerator.Current);
                    }

                    countdownIndex--;
                }
                while (enumerator.MoveNext());
            }
        }

        return default;
    }
}

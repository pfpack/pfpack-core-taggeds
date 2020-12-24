﻿#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IList<TSource> source,
            Func<Exception> moreThanOneElementExceptionFactory)
            =>
            source.Count switch
            {
                > 1 => throw moreThanOneElementExceptionFactory.Invoke(),

                1 => Optional.Present(source[0]),

                _ => default
            };

        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IList<TSource> source,
            Func<TSource, bool> predicate,
            Func<Exception> moreThanOneMatchExceptionFactory)
        {
            for (var i = 0; i < source.Count; i++)
            {
                var current = source[i];

                if (predicate.Invoke(current))
                {
                    for (var j = i + 1; j < source.Count; j++)
                    {
                        if (predicate.Invoke(source[j]))
                        {
                            throw moreThanOneMatchExceptionFactory.Invoke();
                        }
                    }

                    return Optional.Present(current);
                }
            }

            return default;
        }
    }
}

#nullable enable

using System;
using System.Collections.Generic;

namespace PrimeFuncPack.Extensions.System.Linq.Internal
{
    partial class InternalCollectionsExtensions
    {
        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                TSource result;

                do
                {
                    result = enumerator.Current;
                }
                while (enumerator.MoveNext());

                return Optional.Present(result);
            }

            return default;
        }

        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IEnumerable<TSource> source, in Func<TSource, bool> predicate)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                Box<TSource>? result = null;

                do
                {
                    var current = enumerator.Current;

                    if (predicate(current))
                    {
                        result = current;
                    }
                }
                while (enumerator.MoveNext());

                if (result is object)
                {
                    return Optional.Present(result.Value);
                }
            }

            return default;
        }
    }
}

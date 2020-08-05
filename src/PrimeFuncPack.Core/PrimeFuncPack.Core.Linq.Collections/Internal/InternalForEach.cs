#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<TSource> action)
        {
            foreach (var current in source)
            {
                action.Invoke(current);
            }
        }

        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<int, TSource> action)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                int currentIndex = 0;

                do
                {
                    action.Invoke(currentIndex, enumerator.Current);

                    currentIndex = unchecked(++currentIndex) & int.MaxValue;
                }
                while (enumerator.MoveNext());
            }
        }

        public static void InternalForEach<TSource>(
           this IEnumerable<TSource> source,
           in Action<long, TSource> action)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                long currentIndex = 0;

                do
                {
                    action.Invoke(currentIndex, enumerator.Current);

                    currentIndex = unchecked(++currentIndex) & long.MaxValue;
                }
                while (enumerator.MoveNext());
            }
        }
    }
}

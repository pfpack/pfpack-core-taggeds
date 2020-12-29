#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        public static Optional<TSource> ElementAtOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            int index)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return source switch
            {
                IReadOnlyList<TSource> list => list
                .InternalElementAtOrAbsent(index),

                IList<TSource> list => list
                .InternalElementAtOrAbsent(index),

                _ => source
                .InternalElementAtOrAbsent(index)
            };
        }

        public static Optional<TSource> ElementAtOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            long index)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return source switch
            {
                IReadOnlyList<TSource> list => list
                .InternalElementAtOrAbsent(index),

                IList<TSource> list => list
                .InternalElementAtOrAbsent(index),

                _ => source
                .InternalElementAtOrAbsent(index)
            };
        }
    }
}

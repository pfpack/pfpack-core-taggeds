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
                .InnerElementAtOrAbsent(index),

                IList<TSource> list => list
                .InnerElementAtOrAbsent(index),

                _ => source
                .InnerElementAtOrAbsent(index)
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
                .InnerElementAtOrAbsent(index),

                IList<TSource> list => list
                .InnerElementAtOrAbsent(index),

                _ => source
                .InnerElementAtOrAbsent(index)
            };
        }
    }
}

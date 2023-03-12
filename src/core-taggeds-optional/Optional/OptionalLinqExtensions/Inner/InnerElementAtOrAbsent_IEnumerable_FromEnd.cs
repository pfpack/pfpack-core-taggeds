using System.Collections.Generic;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    private static Optional<TSource> InnerElementAtOrAbsent_IEnumerable_FromEnd<TSource>(
        this IEnumerable<TSource> source,
        int indexFromEnd)
    {
        if (indexFromEnd > 0)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                var queue = new Queue<TSource>();
                queue.Enqueue(enumerator.Current);

                while (enumerator.MoveNext())
                {
                    if (queue.Count == indexFromEnd)
                    {
                        _ = queue.Dequeue();
                    }

                    queue.Enqueue(enumerator.Current);
                }

                if (queue.Count == indexFromEnd)
                {
                    return queue.Dequeue();
                }
            }
        }

        return default;
    }
}

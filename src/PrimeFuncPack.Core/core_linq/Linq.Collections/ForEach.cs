#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class CollectionsExtensions
    {
        public static TCollection ForEach<TCollection, TSource>(
            this TCollection source,
            in Action<TSource> action)
            where TCollection : IEnumerable<TSource>
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            switch (source)
            {
                case IReadOnlyList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case IList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case var collection:
                    collection.InternalForEach(action);
                    break;
            }

            return source;
        }

        public static TCollection ForEach<TCollection, TSource>(
            this TCollection source,
            in Action<int, TSource> action)
            where TCollection : IEnumerable<TSource>
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            switch (source)
            {
                case IReadOnlyList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case IList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case var collection:
                    collection.InternalForEach(action);
                    break;
            }

            return source;
        }

        public static TCollection ForEach<TCollection, TSource>(
            this TCollection source,
            in Action<long, TSource> action)
            where TCollection : IEnumerable<TSource>
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            switch (source)
            {
                case IReadOnlyList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case IList<TSource> list:
                    list.InternalForEach(action);
                    break;

                case var collection:
                    collection.InternalForEach(action);
                    break;
            }

            return source;
        }
    }
}

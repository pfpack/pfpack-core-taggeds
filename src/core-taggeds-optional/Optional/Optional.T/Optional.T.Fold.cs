#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public TResult Fold<TResult>(
            Func<T, TResult> map,
            Func<TResult> otherFactory)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return InternalHandleFold(map, otherFactory);
        }

        public Task<TResult> FoldAsync<TResult>(
            Func<T, Task<TResult>> mapAsync,
            Func<Task<TResult>> otherFactoryAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalHandleFold(mapAsync, otherFactoryAsync);
        }

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<T, ValueTask<TResult>> mapAsync,
            Func<ValueTask<TResult>> otherFactoryAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalHandleFold(mapAsync, otherFactoryAsync);
        }
    }
}

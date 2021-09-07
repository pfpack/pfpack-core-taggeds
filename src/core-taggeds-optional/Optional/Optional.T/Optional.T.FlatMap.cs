#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(Func<T, Optional<TResult>> map)
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return InternalFold(map, static () => default);
        }

        public Task<Optional<TResult>> FlatMapAsync<TResult>(Func<T, Task<Optional<TResult>>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return InternalFold(mapAsync, static () => default(Optional<TResult>).Pipe(Task.FromResult));
        }

        public ValueTask<Optional<TResult>> FlatMapValueAsync<TResult>(Func<T, ValueTask<Optional<TResult>>> mapAsync)
        {
            _ = mapAsync ?? throw new ArgumentNullException(nameof(mapAsync));

            return InternalFold(mapAsync, static () => default);
        }
    }
}

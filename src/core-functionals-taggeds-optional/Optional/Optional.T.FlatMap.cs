#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(Func<T, Optional<TResult>> map)
            =>
            InternalFold(
                map ?? throw new ArgumentNullException(nameof(map)),
                static () => default);

        public Task<Optional<TResult>> FlatMapAsync<TResult>(Func<T, Task<Optional<TResult>>> mapAsync)
            =>
            InternalFold(
                mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)),
                static () => Task.FromResult<Optional<TResult>>(default));

        public ValueTask<Optional<TResult>> FlatMapValueAsync<TResult>(Func<T, ValueTask<Optional<TResult>>> mapAsync)
            =>
            InternalFold(
                mapAsync ?? throw new ArgumentNullException(nameof(mapAsync)),
                static () => default);
    }
}

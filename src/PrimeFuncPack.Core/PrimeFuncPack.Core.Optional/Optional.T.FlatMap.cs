#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(in Func<T, Optional<TResult>> map)
            =>
            InternalFlatMap<TResult, Optional<TResult>>(map, () => default);

        public Task<Optional<TResult>> FlatMapAsync<TResult>(in Func<T, Task<Optional<TResult>>> mapAsync)
            =>
            InternalFlatMap<TResult, Task<Optional<TResult>>>(mapAsync, () => Task.FromResult<Optional<TResult>>(default));

        public ValueTask<Optional<TResult>> FlatMapAsync<TResult>(in Func<T, ValueTask<Optional<TResult>>> mapAsync)
            =>
            InternalFlatMap<TResult, ValueTask<Optional<TResult>>>(mapAsync, () => default);

        private TOuterResult InternalFlatMap<TResult, TOuterResult>(in Func<T, TOuterResult> map, in Func<TOuterResult> defaultOuterFactory)
        {
            if (map is null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            return box switch
            {
                null => defaultOuterFactory.Invoke(),
                var present => map.Invoke(present)
            };
        }
    }
}

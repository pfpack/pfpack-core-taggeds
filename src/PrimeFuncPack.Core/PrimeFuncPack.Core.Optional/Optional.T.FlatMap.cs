#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> FlatMap<TResult>(in Func<T, Optional<TResult>> map)
        {
            if (map is null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            return box switch
            {
                null => default,
                var present => map.Invoke(present)
            };
        }

        public Task<Optional<TResult>> FlatMapAsync<TResult>(in Func<T, Task<Optional<TResult>>> mapAsync)
        {
            if (mapAsync is null)
            {
                throw new ArgumentNullException(nameof(mapAsync));
            }

            return box switch
            {
                null => Task.FromResult<Optional<TResult>>(default),
                var present => mapAsync.Invoke(present)
            };
        }
    }
}

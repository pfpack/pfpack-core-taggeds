#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Task<Optional<TResult>> FlatMapAsync<TResult>(in Func<T, Task<Optional<TResult>>> map)
            =>
            IsPresent switch
            {
                true => map.Invoke(Value),
                _ => Task.FromResult<Optional<TResult>>(default)
            };
    }
}

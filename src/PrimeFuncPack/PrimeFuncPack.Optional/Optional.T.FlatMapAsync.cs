#nullable enable

using System;
using System.Threading.Tasks;

namespace PrimeFuncPack
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

using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<Result<TSuccess, TResultFailure>> MapFailureAsync<TResultFailure>(
        Func<TFailure, Task<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        InnerMapFailureAsync(
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}

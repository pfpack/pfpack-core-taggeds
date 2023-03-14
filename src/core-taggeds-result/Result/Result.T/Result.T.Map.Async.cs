using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<Result<TResultSuccess, TResultFailure>> MapAsync<TResultSuccess, TResultFailure>(
        Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync,
        Func<TFailure, Task<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        InnerMapAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}

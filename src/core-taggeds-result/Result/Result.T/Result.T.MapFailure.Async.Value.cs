using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<Result<TSuccess, TResultFailure>> MapFailureValueAsync<TResultFailure>(
        Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        InnerMapFailureValueAsync(
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}

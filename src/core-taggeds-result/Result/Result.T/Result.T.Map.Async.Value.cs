using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<Result<TResultSuccess, TResultFailure>> MapValueAsync<TResultSuccess, TResultFailure>(
        Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        InnerMapValueAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));
}

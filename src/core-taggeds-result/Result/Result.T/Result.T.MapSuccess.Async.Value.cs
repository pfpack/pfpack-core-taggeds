using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<Result<TResultSuccess, TFailure>> MapSuccessValueAsync<TResultSuccess>(
        Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync)
        =>
        InnerMapSuccessValueAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)));
}

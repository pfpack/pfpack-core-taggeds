using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<Result<TResultSuccess, TFailure>> MapSuccessAsync<TResultSuccess>(
        Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync)
        =>
        InnerMapSuccessAsync(
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)));
}

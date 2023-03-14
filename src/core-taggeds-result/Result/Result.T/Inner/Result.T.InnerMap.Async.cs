using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TResultSuccess, TResultFailure>> InnerMapAsync<TResultSuccess, TResultFailure>(
        Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync,
        Func<TFailure, Task<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        isSuccess
            ? new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false))
            : new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
}

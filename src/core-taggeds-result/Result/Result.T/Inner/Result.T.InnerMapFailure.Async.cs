using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TSuccess, TResultFailure>> InnerMapFailureAsync<TResultFailure>(
        Func<TFailure, Task<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        isSuccess
            ? new(success)
            : new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
}

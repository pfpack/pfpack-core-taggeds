using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task<Result<TResultSuccess, TFailure>> InnerMapSuccessAsync<TResultSuccess>(
        Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync)
        =>
        isSuccess
            ? new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false))
            : new(failure);
}

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TResultSuccess, TFailure>> InnerMapSuccessValueAsync<TResultSuccess>(
        Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync)
        =>
        isSuccess
            ? new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false))
            : new(failure);
}

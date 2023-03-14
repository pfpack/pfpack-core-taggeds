using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async ValueTask<Result<TResultSuccess, TResultFailure>> InnerMapValueAsync<TResultSuccess, TResultFailure>(
        Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync,
        Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
        where TResultFailure : struct
        =>
        isSuccess
            ? new(await mapSuccessAsync.Invoke(success).ConfigureAwait(false))
            : new(await mapFailureAsync.Invoke(failure).ConfigureAwait(false));
}

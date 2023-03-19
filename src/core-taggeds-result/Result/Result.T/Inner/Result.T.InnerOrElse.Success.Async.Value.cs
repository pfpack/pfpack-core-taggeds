using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TSuccess> InnerSuccessOrElseValueAsync(Func<ValueTask<TSuccess>> otherFactoryAsync)
        =>
        isSuccess ? ValueTask.FromResult(success) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<TSuccess> InnerSuccessOrElseValueAsync(Func<TFailure, ValueTask<TSuccess>> otherFactoryAsync)
        =>
        isSuccess ? ValueTask.FromResult(success) : otherFactoryAsync.Invoke(failure);
}

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TSuccess> InnerSuccessOrElseAsync(Func<Task<TSuccess>> otherFactoryAsync)
        =>
        isSuccess ? Task.FromResult(success) : otherFactoryAsync.Invoke();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task<TSuccess> InnerSuccessOrElseAsync(Func<TFailure, Task<TSuccess>> otherFactoryAsync)
        =>
        isSuccess ? Task.FromResult(success) : otherFactoryAsync.Invoke(failure);
}

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl3<T1, T2, T3, T4, T5, T6, T7, TResult> : IAsyncFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, TResult> func;

    internal AsyncFuncImpl3(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        =>
        this.func = func;

    public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, CancellationToken cancellationToken = default)
        =>
        Task.FromResult(func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
}

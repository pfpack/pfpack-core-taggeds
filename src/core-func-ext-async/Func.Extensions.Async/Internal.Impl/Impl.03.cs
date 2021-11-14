using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl<T1, T2, T3, TResult> : IAsyncFunc<T1, T2, T3, TResult>
{
    private readonly Func<T1, T2, T3, CancellationToken, Task<TResult>> funcAsync;

    internal AsyncFuncImpl(Func<T1, T2, T3, CancellationToken, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke(arg1, arg2, arg3, cancellationToken);
}

#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl2<T1, T2, TResult> : IAsyncFunc<T1, T2, TResult>
{
    private readonly Func<T1, T2, Task<TResult>> funcAsync;

    internal AsyncFuncImpl2(Func<T1, T2, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(arg1, arg2);
}

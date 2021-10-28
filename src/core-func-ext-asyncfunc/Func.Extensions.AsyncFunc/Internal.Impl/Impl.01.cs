#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl<T, TResult> : IAsyncFunc<T, TResult>
{
    private readonly Func<T, CancellationToken, Task<TResult>> funcAsync;

    internal AsyncFuncImpl(Func<T, CancellationToken, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(arg, cancellationToken);
}

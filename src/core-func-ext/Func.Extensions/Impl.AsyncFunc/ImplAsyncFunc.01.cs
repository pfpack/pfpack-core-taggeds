#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class ImplAsyncFunc<T, TResult> : IAsyncFunc<T, TResult>
{
    private readonly Func<T, CancellationToken, Task<TResult>> funcAsync;

    internal ImplAsyncFunc(
        Func<T, CancellationToken, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(arg, cancellationToken);
}

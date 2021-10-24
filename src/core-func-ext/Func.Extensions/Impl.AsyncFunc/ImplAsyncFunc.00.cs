#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class ImplAsyncFunc<TResult> : IAsyncFunc<TResult>
{
    private readonly Func<CancellationToken, Task<TResult>> funcAsync;

    internal ImplAsyncFunc(
        Func<CancellationToken, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(cancellationToken);
}

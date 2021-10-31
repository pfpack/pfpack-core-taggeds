#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl<TResult> : IAsyncValueFunc<TResult>
{
    private readonly Func<CancellationToken, ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl(Func<CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? ValueTask.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(cancellationToken);
}

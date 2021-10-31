#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl<T, TResult> : IAsyncValueFunc<T, TResult>
{
    private readonly Func<T, CancellationToken, ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl(Func<T, CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? ValueTask.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(arg, cancellationToken);
}

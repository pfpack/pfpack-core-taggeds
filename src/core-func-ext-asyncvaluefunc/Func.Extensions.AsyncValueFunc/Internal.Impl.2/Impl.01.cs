#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl2<T, TResult> : IAsyncValueFunc<T, TResult>
{
    private readonly Func<T, ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl2(Func<T, ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? ValueTask.FromCanceled<TResult>(cancellationToken)
            : funcAsync.Invoke(arg);
}

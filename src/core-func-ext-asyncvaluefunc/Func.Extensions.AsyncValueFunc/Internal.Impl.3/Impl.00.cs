#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl3<TResult> : IAsyncValueFunc<TResult>
{
    private readonly Func<TResult> func;

    internal AsyncValueFuncImpl3(Func<TResult> func)
        =>
        this.func = func;

    public ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? ValueTask.FromCanceled<TResult>(cancellationToken)
            : ValueTask.FromResult(func.Invoke());
}

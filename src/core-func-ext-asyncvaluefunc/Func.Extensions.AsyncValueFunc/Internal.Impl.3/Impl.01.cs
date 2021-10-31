#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl3<T, TResult> : IAsyncValueFunc<T, TResult>
{
    private readonly Func<T, TResult> func;

    internal AsyncValueFuncImpl3(Func<T, TResult> func)
        =>
        this.func = func;

    public ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? ValueTask.FromCanceled<TResult>(cancellationToken)
            : ValueTask.FromResult(func.Invoke(arg));
}

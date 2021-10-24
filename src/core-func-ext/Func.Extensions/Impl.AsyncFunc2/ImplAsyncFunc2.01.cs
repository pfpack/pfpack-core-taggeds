#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class ImplAsyncFunc2<T, TResult> : IAsyncFunc<T, TResult>
{
    private readonly Func<T, TResult> func;

    internal ImplAsyncFunc2(
        Func<T, TResult> func)
        =>
        this.func = func;

    public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : Task.FromResult(func.Invoke(arg));
}

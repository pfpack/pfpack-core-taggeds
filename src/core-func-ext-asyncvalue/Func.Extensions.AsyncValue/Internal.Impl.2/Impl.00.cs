#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl2<TResult> : IAsyncValueFunc<TResult>
{
    private readonly Func<ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl2(Func<ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke();
}

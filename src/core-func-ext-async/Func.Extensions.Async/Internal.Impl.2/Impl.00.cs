#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl2<TResult> : IAsyncFunc<TResult>
{
    private readonly Func<Task<TResult>> funcAsync;

    internal AsyncFuncImpl2(Func<Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke();
}

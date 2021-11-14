using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl3<T, TResult> : IAsyncFunc<T, TResult>
{
    private readonly Func<T, TResult> func;

    internal AsyncFuncImpl3(Func<T, TResult> func)
        =>
        this.func = func;

    public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        Task.FromResult(func.Invoke(arg));
}

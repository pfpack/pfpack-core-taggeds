using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl2<T, TResult> : IAsyncFunc<T, TResult>
{
    private readonly Func<T, Task<TResult>> funcAsync;

    internal AsyncFuncImpl2(Func<T, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke(arg);
}

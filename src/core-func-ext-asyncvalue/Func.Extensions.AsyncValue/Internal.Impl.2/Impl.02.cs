using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl2<T1, T2, TResult> : IAsyncValueFunc<T1, T2, TResult>
{
    private readonly Func<T1, T2, ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl2(Func<T1, T2, ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke(arg1, arg2);
}

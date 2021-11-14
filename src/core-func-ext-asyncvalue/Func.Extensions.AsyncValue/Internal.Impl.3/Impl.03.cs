using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl3<T1, T2, T3, TResult> : IAsyncValueFunc<T1, T2, T3, TResult>
{
    private readonly Func<T1, T2, T3, TResult> func;

    internal AsyncValueFuncImpl3(Func<T1, T2, T3, TResult> func)
        =>
        this.func = func;

    public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default)
        =>
        ValueTask.FromResult(func.Invoke(arg1, arg2, arg3));
}

#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl<T1, T2, T3, T4, TResult> : IAsyncValueFunc<T1, T2, T3, T4, TResult>
{
    private readonly Func<T1, T2, T3, T4, CancellationToken, ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl(Func<T1, T2, T3, T4, CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke(arg1, arg2, arg3, arg4, cancellationToken);
}

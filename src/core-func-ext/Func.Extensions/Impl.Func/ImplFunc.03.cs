#nullable enable

namespace System;

internal sealed class ImplFunc<T1, T2, T3, TResult> : IFunc<T1, T2, T3, TResult>
{
    private readonly Func<T1, T2, T3, TResult> func;

    internal ImplFunc(
        Func<T1, T2, T3, TResult> func)
        =>
        this.func = func;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
        =>
        func.Invoke(arg1, arg2, arg3);
}

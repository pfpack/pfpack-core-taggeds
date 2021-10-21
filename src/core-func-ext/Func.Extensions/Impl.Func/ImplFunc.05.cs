#nullable enable

namespace System;

internal sealed class ImplFunc<T1, T2, T3, T4, T5, TResult> : IFunc<T1, T2, T3, T4, T5, TResult>
{
    private readonly Func<T1, T2, T3, T4, T5, TResult> func;

    internal ImplFunc(
        Func<T1, T2, T3, T4, T5, TResult> func)
        =>
        this.func = func;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        =>
        func.Invoke(arg1, arg2, arg3, arg4, arg5);
}

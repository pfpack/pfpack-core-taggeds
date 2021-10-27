#nullable enable

namespace System;

internal sealed class FuncImpl<T1, T2, TResult> : IFunc<T1, T2, TResult>
{
    private readonly Func<T1, T2, TResult> func;

    internal FuncImpl(Func<T1, T2, TResult> func)
        =>
        this.func = func;

    public TResult Invoke(T1 arg1, T2 arg2)
        =>
        func.Invoke(arg1, arg2);
}

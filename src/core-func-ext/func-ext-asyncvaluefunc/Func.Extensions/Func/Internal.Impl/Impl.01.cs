#nullable enable

namespace System;

internal sealed class FuncImpl<T, TResult> : IFunc<T, TResult>
{
    private readonly Func<T, TResult> func;

    internal FuncImpl(Func<T, TResult> func)
        =>
        this.func = func;

    public TResult Invoke(T arg)
        =>
        func.Invoke(arg);
}

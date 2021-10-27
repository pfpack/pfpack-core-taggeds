#nullable enable

namespace System;

internal sealed class FuncImpl<TResult> : IFunc<TResult>
{
    private readonly Func<TResult> func;

    internal FuncImpl(Func<TResult> func)
        =>
        this.func = func;

    public TResult Invoke()
        =>
        func.Invoke();
}

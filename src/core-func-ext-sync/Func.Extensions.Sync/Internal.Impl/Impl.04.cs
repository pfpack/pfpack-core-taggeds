namespace System;

internal sealed class FuncImpl<T1, T2, T3, T4, TResult> : IFunc<T1, T2, T3, T4, TResult>
{
    private readonly Func<T1, T2, T3, T4, TResult> func;

    internal FuncImpl(Func<T1, T2, T3, T4, TResult> func)
        =>
        this.func = func;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        =>
        func.Invoke(arg1, arg2, arg3, arg4);
}

namespace System;

partial class Func
{
    public static IFunc<T1, T2, T3, TResult> From<T1, T2, T3, TResult>(
        Func<T1, T2, T3, TResult> func)
        =>
        new FuncImpl<T1, T2, T3, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

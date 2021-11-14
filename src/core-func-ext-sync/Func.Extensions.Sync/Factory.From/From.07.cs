namespace System;

partial class Func
{
    public static IFunc<T1, T2, T3, T4, T5, T6, T7, TResult> From<T1, T2, T3, T4, T5, T6, T7, TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        =>
        new FuncImpl<T1, T2, T3, T4, T5, T6, T7, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

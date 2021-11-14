namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T1, T2, T3, TResult> From<T1, T2, T3, TResult>(
        Func<T1, T2, T3, TResult> func)
        =>
        new AsyncValueFuncImpl3<T1, T2, T3, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

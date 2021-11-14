namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T1, T2, TResult> From<T1, T2, TResult>(
        Func<T1, T2, TResult> func)
        =>
        new AsyncFuncImpl3<T1, T2, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

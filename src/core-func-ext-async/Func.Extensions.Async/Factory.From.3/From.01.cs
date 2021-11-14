namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T, TResult> From<T, TResult>(
        Func<T, TResult> func)
        =>
        new AsyncFuncImpl3<T, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

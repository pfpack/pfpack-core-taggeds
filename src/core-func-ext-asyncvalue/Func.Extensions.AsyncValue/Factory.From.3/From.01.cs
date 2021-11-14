namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T, TResult> From<T, TResult>(
        Func<T, TResult> func)
        =>
        new AsyncValueFuncImpl3<T, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

#nullable enable

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<TResult> From<TResult>(
        Func<TResult> func)
        =>
        new AsyncFuncImpl3<TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

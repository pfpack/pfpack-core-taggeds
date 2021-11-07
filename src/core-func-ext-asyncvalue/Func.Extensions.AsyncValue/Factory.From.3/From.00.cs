#nullable enable

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<TResult> From<TResult>(
        Func<TResult> func)
        =>
        new AsyncValueFuncImpl3<TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

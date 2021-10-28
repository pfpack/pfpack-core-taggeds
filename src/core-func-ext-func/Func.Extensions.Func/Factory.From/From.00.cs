#nullable enable

namespace System;

partial class Func
{
    public static IFunc<TResult> From<TResult>(
        Func<TResult> func)
        =>
        new FuncImpl<TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

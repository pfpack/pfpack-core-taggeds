namespace System;

partial class Func
{
    public static IFunc<T, TResult> From<T, TResult>(
        Func<T, TResult> func)
        =>
        new FuncImpl<T, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

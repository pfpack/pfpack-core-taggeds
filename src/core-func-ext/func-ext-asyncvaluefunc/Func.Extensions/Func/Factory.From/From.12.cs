#nullable enable

namespace System;

partial class Func
{
    public static IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> From<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
        =>
        new FuncImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

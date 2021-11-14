using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T1, T2, TResult> From<T1, T2, TResult>(
        Func<T1, T2, ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl2<T1, T2, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

using System.Threading.Tasks;

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T1, T2, T3, T4, T5, TResult> From<T1, T2, T3, T4, T5, TResult>(
        Func<T1, T2, T3, T4, T5, Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl2<T1, T2, T3, T4, T5, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

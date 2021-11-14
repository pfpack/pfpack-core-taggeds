using System.Threading.Tasks;

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T, TResult> From<T, TResult>(
        Func<T, Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl2<T, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

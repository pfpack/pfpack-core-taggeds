using System.Threading;
using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T1, T2, T3, T4, TResult> From<T1, T2, T3, T4, TResult>(
        Func<T1, T2, T3, T4, CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl<T1, T2, T3, T4, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

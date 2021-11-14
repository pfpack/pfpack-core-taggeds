using System.Threading;
using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T1, T2, TResult> From<T1, T2, TResult>(
        Func<T1, T2, CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl<T1, T2, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

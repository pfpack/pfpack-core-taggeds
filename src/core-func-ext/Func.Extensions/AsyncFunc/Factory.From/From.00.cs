#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<TResult> From<TResult>(
        Func<CancellationToken, Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl<TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));

    public static IAsyncFunc<TResult> From<TResult>(
        Func<Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl2<TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));

    public static IAsyncFunc<TResult> From<TResult>(
        Func<TResult> func)
        =>
        new AsyncFuncImpl3<TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}

using System.Threading;
using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<TResult> From<TResult>(
        Func<CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl<TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

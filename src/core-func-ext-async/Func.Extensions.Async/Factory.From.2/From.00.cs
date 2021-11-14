using System.Threading.Tasks;

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<TResult> From<TResult>(
        Func<Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl2<TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

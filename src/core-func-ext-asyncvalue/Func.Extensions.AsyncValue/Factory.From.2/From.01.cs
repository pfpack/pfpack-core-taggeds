using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T, TResult> From<T, TResult>(
        Func<T, ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl2<T, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

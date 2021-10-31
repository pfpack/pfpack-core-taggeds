#nullable enable

using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<TResult> From<TResult>(
        Func<ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl2<TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}

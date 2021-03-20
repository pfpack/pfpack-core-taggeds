#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class AsyncFunc
    {
        public static IAsyncFunc<T1, T2, T3, TResult> From<T1, T2, T3, TResult>(
            Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            new ImplAsyncFunc<T1, T2, T3, TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}
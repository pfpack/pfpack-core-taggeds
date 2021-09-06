#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class AsyncFunc
    {
        public static IAsyncFunc<T1, T2, T3, T4, T5, T6, TResult> From<T1, T2, T3, T4, T5, T6, TResult>(
            Func<T1, T2, T3, T4, T5, T6, CancellationToken, Task<TResult>> funcAsync)
            =>
            new ImplAsyncFunc<T1, T2, T3, T4, T5, T6, TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}

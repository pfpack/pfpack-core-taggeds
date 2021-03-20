#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class AsyncFunc
    {
        public static IAsyncFunc<T, TResult> From<T, TResult>(
            Func<T, CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            new ImplAsyncFunc<T, TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}
#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class AsyncValueFunc
    {
        public static IAsyncValueFunc<T, TResult> From<T, TResult>(
            Func<T, CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            new ImplAsyncValueFunc<T, TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}
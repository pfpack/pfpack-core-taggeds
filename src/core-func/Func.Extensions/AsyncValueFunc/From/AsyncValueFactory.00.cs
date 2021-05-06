#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class AsyncValueFunc
    {
        public static IAsyncValueFunc<TResult> From<TResult>(
            Func<CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            new ImplAsyncValueFunc<TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}
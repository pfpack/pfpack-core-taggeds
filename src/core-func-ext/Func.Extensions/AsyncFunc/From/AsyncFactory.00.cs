#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class AsyncFunc
    {
        public static IAsyncFunc<TResult> From<TResult>(
            Func<CancellationToken, Task<TResult>> funcAsync)
            =>
            new ImplAsyncFunc<TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}

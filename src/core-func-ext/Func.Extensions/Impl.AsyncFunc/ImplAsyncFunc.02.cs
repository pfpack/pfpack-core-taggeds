#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<T1, T2, TResult> : IAsyncFunc<T1, T2, TResult>
    {
        private readonly Func<T1, T2, CancellationToken, Task<TResult>> funcAsync;

        internal ImplAsyncFunc(
            Func<T1, T2, CancellationToken, Task<TResult>> funcAsync)
            =>
            this.funcAsync = funcAsync;

        public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default)
            =>
            funcAsync.Invoke(arg1, arg2, cancellationToken);
    }
}

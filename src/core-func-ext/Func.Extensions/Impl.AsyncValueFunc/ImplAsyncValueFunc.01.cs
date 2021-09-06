#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncValueFunc<T, TResult> : IAsyncValueFunc<T, TResult>
    {
        private readonly Func<T, CancellationToken, ValueTask<TResult>> funcAsync;

        internal ImplAsyncValueFunc(
            Func<T, CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            this.funcAsync = funcAsync;

        public ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
            =>
            funcAsync.Invoke(arg, cancellationToken);
    }
}

#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncValueFunc<TResult> : IAsyncValueFunc<TResult>
    {
        private readonly Func<CancellationToken, ValueTask<TResult>> funcAsync;

        public ImplAsyncValueFunc(
            Func<CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            this.funcAsync = funcAsync;

        public ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default)
            =>
            funcAsync.Invoke(cancellationToken);
    }
}
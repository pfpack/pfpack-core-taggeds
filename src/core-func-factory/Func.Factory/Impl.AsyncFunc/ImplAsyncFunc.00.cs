#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<TResult> : IAsyncFunc<TResult>
    {
        private readonly Func<CancellationToken, ValueTask<TResult>> funcAsync;

        public ImplAsyncFunc(
            Func<CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            this.funcAsync = funcAsync;

        public ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken)
            =>
            funcAsync.Invoke(cancellationToken);
    }
}
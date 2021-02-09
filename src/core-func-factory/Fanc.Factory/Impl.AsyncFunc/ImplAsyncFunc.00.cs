#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<TResult> : IAsyncFunc<TResult>
    {
        private readonly Func<CancellationToken, ValueTask<TResult>> func;

        public ImplAsyncFunc(
            Func<CancellationToken, ValueTask<TResult>> func)
            =>
            this.func = func;

        public ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
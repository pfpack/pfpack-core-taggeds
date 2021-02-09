#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<T, TResult> : IAsyncFunc<T, TResult>
    {
        private readonly Func<T, CancellationToken, ValueTask<TResult>> func;

        public ImplAsyncFunc(
            Func<T, CancellationToken, ValueTask<TResult>> func)
            =>
            this.func = func;

        public ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default)
            =>
            func.Invoke(arg, cancellationToken);
    }
}
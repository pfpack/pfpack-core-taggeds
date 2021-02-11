#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<T1, T2, TResult> : IAsyncFunc<T1, T2, TResult>
    {
        private readonly Func<T1, T2, CancellationToken, ValueTask<TResult>> funcAsync;

        public ImplAsyncFunc(
            Func<T1, T2, CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            this.funcAsync = funcAsync;

        public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken)
            =>
            funcAsync.Invoke(arg1, arg2, cancellationToken);
    }
}
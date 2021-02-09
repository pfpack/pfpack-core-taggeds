#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<T1, T2, TResult> : IAsyncFunc<T1, T2, TResult>
    {
        private readonly Func<T1, T2, CancellationToken, ValueTask<TResult>> func;

        public ImplAsyncFunc(
            Func<T1, T2, CancellationToken, ValueTask<TResult>> func)
            =>
            this.func = func;

        public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
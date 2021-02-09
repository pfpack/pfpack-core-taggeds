#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    internal sealed class ImplAsyncFunc<T1, T2, T3, TResult> : IAsyncFunc<T1, T2, T3, TResult>
    {
        private readonly Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> func;

        public ImplAsyncFunc(
            Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> func)
            =>
            this.func = func;

        public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default)
            =>
            func.Invoke(arg1, arg2, arg3, cancellationToken);
    }
}
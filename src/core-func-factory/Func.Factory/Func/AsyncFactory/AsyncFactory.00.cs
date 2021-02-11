#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class Func
    {
        public static IAsyncFunc<TResult> Create<TResult>(
            Func<CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            new ImplAsyncFunc<TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}
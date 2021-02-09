#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class Func
    {
        public static IAsyncFunc<T, TResult> Create<T, TResult>(
            Func<T, CancellationToken, ValueTask<TResult>> func)
            =>
            new ImplAsyncFunc<T, TResult>(
                func ?? throw new ArgumentNullException(nameof(func)));
    }
}
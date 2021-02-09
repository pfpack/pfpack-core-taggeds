#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class Func
    {
        public static IAsyncFunc<TResult> Create<TResult>(
            Func<CancellationToken, ValueTask<TResult>> func)
            =>
            throw new NotImplementedException();
    }
}
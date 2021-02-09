#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class Func
    {
        public static IAsyncFunc<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(
            Func<T1, T2, T3, CancellationToken, ValueTask<TResult>> func)
            =>
            throw new NotImplementedException();
    }
}
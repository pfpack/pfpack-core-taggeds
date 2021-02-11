#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncFunc<in T1, in T2, in T3, in T4, in T5, in T6, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, CancellationToken cancellationToken);
    }
}
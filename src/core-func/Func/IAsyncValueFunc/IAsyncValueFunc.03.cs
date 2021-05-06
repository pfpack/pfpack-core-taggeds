#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncValueFunc<in T1, in T2, in T3, TResult>
    {
        Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken = default);
    }
}
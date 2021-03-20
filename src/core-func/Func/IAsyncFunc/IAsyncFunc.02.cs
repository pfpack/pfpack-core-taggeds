#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncFunc<in T1, in T2, TResult>
    {
        Task<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default);
    }
}
#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncFunc<in T, TResult>
    {
        Task<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default);
    }
}

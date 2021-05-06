#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncValueFunc<TResult>
    {
        Task<TResult> InvokeAsync(CancellationToken cancellationToken = default);
    }
}
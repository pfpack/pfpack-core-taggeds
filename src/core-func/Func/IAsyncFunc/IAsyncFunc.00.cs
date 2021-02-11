#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncFunc<TResult>
    {
        ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default);
    }
}
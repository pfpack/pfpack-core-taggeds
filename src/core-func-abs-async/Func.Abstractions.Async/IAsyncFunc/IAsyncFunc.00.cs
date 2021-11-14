using System.Threading;
using System.Threading.Tasks;

namespace System;

public interface IAsyncFunc<TResult>
{
    Task<TResult> InvokeAsync(CancellationToken cancellationToken = default);
}

using System.Threading;
using System.Threading.Tasks;

namespace System;

public interface IAsyncValueFunc<TResult>
{
    ValueTask<TResult> InvokeAsync(CancellationToken cancellationToken = default);
}

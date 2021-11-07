#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

public interface IAsyncValueFunc<in T, TResult>
{
    ValueTask<TResult> InvokeAsync(T arg, CancellationToken cancellationToken = default);
}

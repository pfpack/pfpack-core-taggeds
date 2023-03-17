using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests

    public Task<TSuccess> SuccessOrElseAsync(Func<Task<TSuccess>> otherFactoryAsync)
        =>
        InnerSuccessOrElseAsync(otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public Task<TSuccess> SuccessOrElseAsync(Func<TFailure, Task<TSuccess>> otherFactoryAsync)
        =>
        InnerSuccessOrElseAsync(otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}

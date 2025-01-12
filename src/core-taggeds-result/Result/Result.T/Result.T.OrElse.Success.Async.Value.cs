using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests and open the methods

    internal ValueTask<TSuccess> SuccessOrElseValueAsync(Func<ValueTask<TSuccess>> otherFactoryAsync)
        =>
        InnerSuccessOrElseValueAsync(otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    internal ValueTask<TSuccess> SuccessOrElseValueAsync(Func<TFailure, ValueTask<TSuccess>> otherFactoryAsync)
        =>
        InnerSuccessOrElseValueAsync(otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}

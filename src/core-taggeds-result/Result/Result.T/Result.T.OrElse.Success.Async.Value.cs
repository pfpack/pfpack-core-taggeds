using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    // TODO: Add the tests

    public ValueTask<TSuccess> SuccessOrElseValueAsync(Func<ValueTask<TSuccess>> otherFactoryAsync)
        =>
        InnerSuccessOrElseValueAsync(otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<TSuccess> SuccessOrElseValueAsync(Func<TFailure, ValueTask<TSuccess>> otherFactoryAsync)
        =>
        InnerSuccessOrElseValueAsync(otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}

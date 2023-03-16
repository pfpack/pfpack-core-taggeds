using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<Result<TOtherSuccess, TOtherFailure>> RecoverValueAsync<TOtherSuccess, TOtherFailure>(
        Func<TFailure, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, ValueTask<TOtherSuccess>> mapSuccessAsync)
        where TOtherFailure : struct
        =>
        InnerRecoverValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)),
            mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync)));

    public ValueTask<Result<TSuccess, TOtherFailure>> RecoverValueAsync<TOtherFailure>(
        Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TOtherFailure : struct
        =>
        InnerRecoverValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

    public ValueTask<Result<TSuccess, TFailure>> RecoverValueAsync(
        Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        =>
        InnerRecoverValueAsync(
            otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
}

using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public ValueTask<Result<TSuccess, TCauseFailure>> FilterValueAsync<TCauseFailure>(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, ValueTask<TCauseFailure>> mapFailureAsync)
        where TCauseFailure : struct
        =>
        InnerFilterValueAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)),
            causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));

    public ValueTask<Result<TSuccess, TCauseFailure>> FilterValueAsync<TCauseFailure>(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, TCauseFailure> mapFailure)
        where TCauseFailure : struct
        =>
        InnerFilterValueAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)),
            causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));

    public ValueTask<Result<TSuccess, TFailure>> FilterValueAsync(
        Func<TSuccess, ValueTask<bool>> predicateAsync,
        Func<TSuccess, ValueTask<TFailure>> causeFactoryAsync)
        =>
        InnerFilterValueAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)),
            causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync)));
}

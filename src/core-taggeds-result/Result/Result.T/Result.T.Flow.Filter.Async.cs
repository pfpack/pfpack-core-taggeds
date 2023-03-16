using System.Threading.Tasks;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    public Task<Result<TSuccess, TCauseFailure>> FilterAsync<TCauseFailure>(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, Task<TCauseFailure>> mapFailureAsync)
        where TCauseFailure : struct
        =>
        InnerFilterAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)),
            causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync)),
            mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync)));

    public Task<Result<TSuccess, TCauseFailure>> FilterAsync<TCauseFailure>(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
        Func<TFailure, TCauseFailure> mapFailure)
        where TCauseFailure : struct
        =>
        InnerFilterAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)),
            causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync)),
            mapFailure ?? throw new ArgumentNullException(nameof(mapFailure)));

    public Task<Result<TSuccess, TFailure>> FilterAsync(
        Func<TSuccess, Task<bool>> predicateAsync,
        Func<TSuccess, Task<TFailure>> causeFactoryAsync)
        =>
        InnerFilterAsync(
            predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync)),
            causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync)));
}

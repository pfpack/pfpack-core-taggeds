#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Filter

        public Result<TSuccess, TCauseFailure> Filter<TCauseFailure>(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TCauseFailure> causeFactory,
            Func<TFailure, TCauseFailure> mapFailure)
            where TCauseFailure : struct
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Fold(FilterSuccess, failure => mapFailure.Invoke(failure));

            Result<TSuccess, TCauseFailure> FilterSuccess(TSuccess success)
                =>
                predicate.Invoke(success) switch
                {
                    true => success,
                    _ => causeFactory.Invoke(success)
                };
        }

        public Result<TSuccess, TFailure> Filter(
            Func<TSuccess, bool> predicate,
            Func<TSuccess, TFailure> causeFactory)
        {
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));

            var @this = this;

            return Fold(FilterSuccess, _ => @this);

            Result<TSuccess, TFailure> FilterSuccess(TSuccess success)
                =>
                predicate.Invoke(success) switch
                {
                    true => @this,
                    _ => causeFactory.Invoke(success)
                };
        }

        // Filter Async / Task

        public Task<Result<TSuccess, TCauseFailure>> FilterAsync<TCauseFailure>(
            Func<TSuccess, Task<bool>> predicateAsync,
            Func<TSuccess, Task<TCauseFailure>> causeFactoryAsync,
            Func<TFailure, Task<TCauseFailure>> mapFailureAsync)
            where TCauseFailure : struct
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));
            _ = causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return FoldAsync(FilterSuccessAsync, MapFailureAsync);

            async Task<Result<TSuccess, TCauseFailure>> FilterSuccessAsync(TSuccess success)
                =>
                await predicateAsync.Invoke(success).ConfigureAwait(false) switch
                {
                    true => success,
                    _ => await causeFactoryAsync.Invoke(success).ConfigureAwait(false)
                };

            async Task<Result<TSuccess, TCauseFailure>> MapFailureAsync(TFailure failure)
                =>
                await mapFailureAsync.Invoke(failure).ConfigureAwait(false);
        }

        public Task<Result<TSuccess, TFailure>> FilterAsync(
            Func<TSuccess, Task<bool>> predicateAsync,
            Func<TSuccess, Task<TFailure>> causeFactoryAsync)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));
            _ = causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync));

            var @this = this;

            return FoldAsync(FilterSuccessAsync, _ => Task.FromResult(@this));

            async Task<Result<TSuccess, TFailure>> FilterSuccessAsync(TSuccess success)
                =>
                await predicateAsync.Invoke(success).ConfigureAwait(false) switch
                {
                    true => @this,
                    _ => await causeFactoryAsync.Invoke(success).ConfigureAwait(false)
                };
        }

        // Filter Async / ValueTask

        public ValueTask<Result<TSuccess, TCauseFailure>> FilterValueAsync<TCauseFailure>(
            Func<TSuccess, ValueTask<bool>> predicateAsync,
            Func<TSuccess, ValueTask<TCauseFailure>> causeFactoryAsync,
            Func<TFailure, ValueTask<TCauseFailure>> mapFailureAsync)
            where TCauseFailure : struct
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));
            _ = causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return FoldValueAsync(FilterSuccessValueAsync, MapFailureValueAsync);

            async ValueTask<Result<TSuccess, TCauseFailure>> FilterSuccessValueAsync(TSuccess success)
                =>
                await predicateAsync.Invoke(success).ConfigureAwait(false) switch
                {
                    true => success,
                    _ => await causeFactoryAsync.Invoke(success).ConfigureAwait(false)
                };

            async ValueTask<Result<TSuccess, TCauseFailure>> MapFailureValueAsync(TFailure failure)
                =>
                await mapFailureAsync.Invoke(failure).ConfigureAwait(false);
        }

        public ValueTask<Result<TSuccess, TFailure>> FilterValueAsync(
            Func<TSuccess, ValueTask<bool>> predicateAsync,
            Func<TSuccess, ValueTask<TFailure>> causeFactoryAsync)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));
            _ = causeFactoryAsync ?? throw new ArgumentNullException(nameof(causeFactoryAsync));

            var @this = this;

            return FoldValueAsync(FilterSuccessValueAsync, _ => ValueTask.FromResult(@this));

            async ValueTask<Result<TSuccess, TFailure>> FilterSuccessValueAsync(TSuccess success)
                =>
                await predicateAsync.Invoke(success).ConfigureAwait(false) switch
                {
                    true => @this,
                    _ => await causeFactoryAsync.Invoke(success).ConfigureAwait(false)
                };
        }
    }
}

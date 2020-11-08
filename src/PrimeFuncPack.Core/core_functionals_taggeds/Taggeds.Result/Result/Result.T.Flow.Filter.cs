#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Filter

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

        public Task<Result<TSuccess, TFailure>> FilterAsync(
            Func<TSuccess, Task<bool>> predicateAsync,
            Func<TSuccess, TFailure> causeFactory)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));

            var @this = this;

            return FoldAsync(FilterSuccessAsync, _ => Task.FromResult(@this));

            async Task<Result<TSuccess, TFailure>> FilterSuccessAsync(TSuccess success)
                =>
                await predicateAsync.Invoke(success).ConfigureAwait(false) switch
                {
                    true => @this,
                    _ => causeFactory.Invoke(success)
                };
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

        public ValueTask<Result<TSuccess, TFailure>> FilterValueAsync(
            Func<TSuccess, ValueTask<bool>> predicateAsync,
            Func<TSuccess, TFailure> causeFactory)
        {
            _ = predicateAsync ?? throw new ArgumentNullException(nameof(predicateAsync));
            _ = causeFactory ?? throw new ArgumentNullException(nameof(causeFactory));

            var @this = this;

            return FoldValueAsync(FilterSuccessValueAsync, _ => ValueTask.FromResult(@this));

            async ValueTask<Result<TSuccess, TFailure>> FilterSuccessValueAsync(TSuccess success)
                =>
                await predicateAsync.Invoke(success).ConfigureAwait(false) switch
                {
                    true => @this,
                    _ => causeFactory.Invoke(success)
                };
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

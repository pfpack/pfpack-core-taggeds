#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Recover

        public Result<TSuccess, TOtherFailure> RecoverCatching<TOtherFailure>(
            Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory,
            Func<Exception, TOtherFailure> failureFactory)
            where TOtherFailure : struct
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return Fold(
                success => success,
                failure => InternalRecoverFailureCatching(failure, otherFactory, failureFactory));
        }

        public Result<TSuccess, TFailure> RecoverCatching(
            Func<TFailure, Result<TSuccess, TFailure>> otherFactory,
            Func<Exception, TFailure> failureFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            var @this = this;

            return Fold(
                _ => @this,
                failure => InternalRecoverFailureCatching(failure, otherFactory, failureFactory));
        }

        // Recover Async / Task

        public Task<Result<TSuccess, TOtherFailure>> RecoverCatchingAsync<TOtherFailure>(
            Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<Exception, TOtherFailure> failureFactory)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return FoldAsync(
                success => Task.FromResult<Result<TSuccess, TOtherFailure>>(success),
                failure => InternalRecoverFailureCatchingAsync(failure, otherFactoryAsync, failureFactory));
        }

        public Task<Result<TSuccess, TFailure>> RecoverCatchingAsync(
            Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync,
            Func<Exception, TFailure> failureFactory)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            var @this = this;

            return FoldAsync(
                _ => Task.FromResult(@this),
                failure => InternalRecoverFailureCatchingAsync(failure, otherFactoryAsync, failureFactory));
        }

        // Recover Async / ValueTask

        public ValueTask<Result<TSuccess, TOtherFailure>> RecoverCatchingValueAsync<TOtherFailure>(
            Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<Exception, TOtherFailure> failureFactory)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return FoldValueAsync(
                success => ValueTask.FromResult<Result<TSuccess, TOtherFailure>>(success),
                failure => InternalRecoverFailureCatchingValueAsync(failure, otherFactoryAsync, failureFactory));
        }

        public ValueTask<Result<TSuccess, TFailure>> RecoverCatchingValueAsync(
            Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync,
            Func<Exception, TFailure> failureFactory)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            var @this = this;

            return FoldValueAsync(
                _ => ValueTask.FromResult(@this),
                failure => InternalRecoverFailureCatchingValueAsync(failure, otherFactoryAsync, failureFactory));
        }
    }
}

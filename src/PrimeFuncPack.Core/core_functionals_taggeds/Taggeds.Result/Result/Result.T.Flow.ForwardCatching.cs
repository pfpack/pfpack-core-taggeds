#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // ForwardCatching

        public Result<TNextSuccess, TNextFailure> ForwardCatching<TNextSuccess, TNextFailure>(
            Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
            Func<TFailure, TNextFailure> mapFailure,
            Func<Exception, TNextFailure> failureFactory)
            where TNextSuccess : notnull
            where TNextFailure : struct
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return Fold(
                success => InternalNextFactoryCatching(success, nextFactory, failureFactory),
                failure => mapFailure.Invoke(failure));
        }

        public Result<TNextSuccess, TFailure> ForwardCatching<TNextSuccess>(
            Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory,
            Func<Exception, TFailure> failureFactory)
            where TNextSuccess : notnull
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return Fold(
                success => InternalNextFactoryCatching(success, nextFactory, failureFactory),
                failure => failure);
        }

        public Result<TSuccess, TFailure> ForwardCatching(
            Func<TSuccess, Result<TSuccess, TFailure>> nextFactory,
            Func<Exception, TFailure> failureFactory)
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            var @this = this;

            return Fold(
                success => InternalNextFactoryCatching(success, nextFactory, failureFactory),
                _ => @this);
        }

        // ForwardCatching Async / Task

        public Task<Result<TNextSuccess, TNextFailure>> ForwardCatchingAsync<TNextSuccess, TNextFailure>(
            Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<TFailure, TNextFailure> mapFailure,
            Func<Exception, TNextFailure> failureFactory)
            where TNextSuccess : notnull
            where TNextFailure : struct
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return FoldAsync(
                success => InternalNextFactoryCatchingAsync(success, nextFactoryAsync, failureFactory),
                failure => Task.FromResult<Result<TNextSuccess, TNextFailure>>(mapFailure.Invoke(failure)));
        }

        public Task<Result<TNextSuccess, TFailure>> ForwardCatchingAsync<TNextSuccess>(
            Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync,
            Func<Exception, TFailure> failureFactory)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return FoldAsync(
                success => InternalNextFactoryCatchingAsync(success, nextFactoryAsync, failureFactory),
                failure => Task.FromResult<Result<TNextSuccess, TFailure>>(failure));
        }

        public Task<Result<TSuccess, TFailure>> ForwardCatchingAsync(
            Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync,
            Func<Exception, TFailure> failureFactory)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            var @this = this;

            return FoldAsync(
                success => InternalNextFactoryCatchingAsync(success, nextFactoryAsync, failureFactory),
                _ => Task.FromResult(@this));
        }

        // ForwardCatching Async / ValueTask

        public ValueTask<Result<TNextSuccess, TNextFailure>> ForwardCatchingValueAsync<TNextSuccess, TNextFailure>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<TFailure, TNextFailure> mapFailure,
            Func<Exception, TNextFailure> failureFactory)
            where TNextSuccess : notnull
            where TNextFailure : struct
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return FoldValueAsync(
                success => InternalNextFactoryCatchingValueAsync(success, nextFactoryAsync, failureFactory),
                failure => ValueTask.FromResult<Result<TNextSuccess, TNextFailure>>(mapFailure.Invoke(failure)));
        }

        public ValueTask<Result<TNextSuccess, TFailure>> ForwardCatchingValueAsync<TNextSuccess>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync,
            Func<Exception, TFailure> failureFactory)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            return FoldValueAsync(
                success => InternalNextFactoryCatchingValueAsync(success, nextFactoryAsync, failureFactory),
                failure => ValueTask.FromResult<Result<TNextSuccess, TFailure>>(failure));
        }

        public ValueTask<Result<TSuccess, TFailure>> ForwardCatchingValueAsync(
            Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync,
            Func<Exception, TFailure> failureFactory)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = failureFactory ?? throw new ArgumentNullException(nameof(failureFactory));

            var @this = this;

            return FoldValueAsync(
                success => InternalNextFactoryCatchingValueAsync(success, nextFactoryAsync, failureFactory),
                _ => ValueTask.FromResult(@this));
        }
    }
}

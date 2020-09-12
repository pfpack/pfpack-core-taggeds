#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Forward

        public Result<TNextSuccess, TNextFailure> Forward<TNextSuccess, TNextFailure>(
            Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Fold(nextFactory, failure => mapFailure.Invoke(failure));
        }

        public Result<TNextSuccess, TFailure> Forward<TNextSuccess>(
            Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory)
            where TNextSuccess : notnull
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Fold(nextFactory, failure => failure);
        }

        public Result<TSuccess, TFailure> Forward(
            Func<TSuccess, Result<TSuccess, TFailure>> nextFactory)
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            var @this = this;

            return Fold(nextFactory, _ => @this);
        }

        // Forward Async / Task

        public Task<Result<TNextSuccess, TNextFailure>> ForwardAsync<TNextSuccess, TNextFailure>(
            Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return FoldAsync(
                nextFactoryAsync,
                failure => (Result<TNextSuccess, TNextFailure>)mapFailure.Invoke(failure));
        }

        public Task<Result<TNextSuccess, TFailure>> ForwardAsync<TNextSuccess>(
            Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return FoldAsync(
                nextFactoryAsync,
                failure => (Result<TNextSuccess, TFailure>)failure);
        }

        public Task<Result<TSuccess, TFailure>> ForwardAsync(
            Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            var @this = this;

            return FoldAsync(nextFactoryAsync, _ => @this);
        }

        // Forward Async / ValueTask

        public ValueTask<Result<TNextSuccess, TNextFailure>> ForwardValueAsync<TNextSuccess, TNextFailure>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return FoldValueAsync(
                nextFactoryAsync,
                failure => (Result<TNextSuccess, TNextFailure>)mapFailure.Invoke(failure));
        }

        public ValueTask<Result<TNextSuccess, TFailure>> ForwardValueAsync<TNextSuccess>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return FoldValueAsync(
                nextFactoryAsync,
                failure => (Result<TNextSuccess, TFailure>)failure);
        }

        public ValueTask<Result<TSuccess, TFailure>> ForwardValueAsync(
            Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            var @this = this;

            return FoldValueAsync(nextFactoryAsync, _ => @this);
        }
    }
}

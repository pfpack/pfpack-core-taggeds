#nullable enable

using System.Threading.Tasks;
using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TNextSuccess, TNextFailure> Forward<TNextSuccess, TNextFailure>(
            Func<TSuccess, Result<TNextSuccess, TNextFailure>> nextFactory,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(
                nextFactory,
                failure => mapFailure.Invoke(failure));
        }

        public Result<TNextSuccess, TFailure> Forward<TNextSuccess>(
            Func<TSuccess, Result<TNextSuccess, TFailure>> nextFactory)
            where TNextSuccess : notnull
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Current.Fold(
                nextFactory,
                failure => failure);
        }

        public Result<TSuccess, TFailure> Forward(
            Func<TSuccess, Result<TSuccess, TFailure>> nextFactory)
        {
            _ = nextFactory ?? throw new ArgumentNullException(nameof(nextFactory));

            return Current.Fold(
                nextFactory,
                _ => Current);
        }

        public Task<Result<TNextSuccess, TNextFailure>> ForwardAsync<TNextSuccess, TNextFailure>(
            Func<TSuccess, Task<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(
                nextFactoryAsync,
                failure => Failure(mapFailure.Invoke(failure)).Build<TNextSuccess>());
        }

        public Task<Result<TNextSuccess, TFailure>> ForwardAsync<TNextSuccess>(
            Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return Current.Fold(
                nextFactoryAsync,
                failure => Failure(failure).Build<TNextSuccess>());
        }

        public Task<Result<TSuccess, TFailure>> ForwardAsync(
            Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return Current.Fold(
                nextFactoryAsync,
                _ => Current);
        }

        public ValueTask<Result<TNextSuccess, TNextFailure>> ForwardAsync<TNextSuccess, TNextFailure>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TNextFailure>>> nextFactoryAsync,
            Func<TFailure, TNextFailure> mapFailure)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Current.Fold(
                nextFactoryAsync,
                failure => Failure(mapFailure.Invoke(failure)).Build<TNextSuccess>());
        }

        public ValueTask<Result<TNextSuccess, TFailure>> ForwardAsync<TNextSuccess>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return Current.Fold(
                nextFactoryAsync,
                failure => Failure(failure).Build<TNextSuccess>());
        }

        public ValueTask<Result<TSuccess, TFailure>> ForwardAsync(
            Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return Current.Fold(
                nextFactoryAsync,
                _ => Current);
        }
    }
}

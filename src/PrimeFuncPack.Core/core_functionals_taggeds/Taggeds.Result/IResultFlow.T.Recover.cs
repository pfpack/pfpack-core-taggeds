#nullable enable

using System.Threading.Tasks;
using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TNextSuccess, TNextFailure> Recover<TNextSuccess, TNextFailure>(
            Func<TFailure, Result<TNextSuccess, TNextFailure>> otherFactory,
            Func<TSuccess, TNextSuccess> mapSuccess)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(
                success => Success(mapSuccess.Invoke(success)),
                otherFactory);
        }

        public Result<TSuccess, TNextFailure> Recover<TNextFailure>(
            Func<TFailure, Result<TSuccess, TNextFailure>> otherFactory)
            where TNextFailure : notnull, new()
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return Current.Fold(
                success => Success(success),
                otherFactory);
        }

        public Result<TSuccess, TFailure> Recover(
            Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return Current.Fold(
                _ => Current,
                otherFactory);
        }

        public Task<Result<TNextSuccess, TNextFailure>> RecoverAsync<TNextSuccess, TNextFailure>(
            Func<TFailure, Task<Result<TNextSuccess, TNextFailure>>> otherFactoryAsync,
            Func<TSuccess, TNextSuccess> mapSuccess)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(
                success => Task.FromResult(Success(mapSuccess.Invoke(success)).Build<TNextFailure>()),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TNextFailure>> RecoverAsync<TNextFailure>(
            Func<TFailure, Task<Result<TSuccess, TNextFailure>>> otherFactoryAsync)
            where TNextFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                success => Task.FromResult(Success(success).Build<TNextFailure>()),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                _ => Task.FromResult(Current),
                otherFactoryAsync);
        }

        public ValueTask<Result<TNextSuccess, TNextFailure>> RecoverAsync<TNextSuccess, TNextFailure>(
            Func<TFailure, ValueTask<Result<TNextSuccess, TNextFailure>>> otherFactoryAsync,
            Func<TSuccess, TNextSuccess> mapSuccess)
            where TNextSuccess : notnull
            where TNextFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(
                success => ValueTask.FromResult(Success(mapSuccess.Invoke(success)).Build<TNextFailure>()),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TNextFailure>> RecoverAsync<TNextFailure>(
            Func<TFailure, ValueTask<Result<TSuccess, TNextFailure>>> otherFactoryAsync)
            where TNextFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                success => ValueTask.FromResult(Success(success).Build<TNextFailure>()),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                _ => ValueTask.FromResult(Current),
                otherFactoryAsync);
        }
    }
}

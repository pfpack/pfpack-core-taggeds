#nullable enable

using System.Threading.Tasks;
using static System.Result;

namespace System
{
    partial interface IResultFlow<TSuccess, TFailure>
    {
        public Result<TOtherSuccess, TOtherFailure> Recover<TOtherSuccess, TOtherFailure>(
            Func<TFailure, Result<TOtherSuccess, TOtherFailure>> otherFactory,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherSuccess : notnull
            where TOtherFailure : notnull, new()
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(
                success => Success(mapSuccess.Invoke(success)),
                otherFactory);
        }

        public Result<TSuccess, TOtherFailure> Recover<TOtherFailure>(
            Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
            where TOtherFailure : notnull, new()
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

        public Task<Result<TOtherSuccess, TOtherFailure>> RecoverAsync<TOtherSuccess, TOtherFailure>(
            Func<TFailure, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherSuccess : notnull
            where TOtherFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(
                success => Success(mapSuccess.Invoke(success)).BuildAsync<TOtherFailure>(),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TOtherFailure>> RecoverAsync<TOtherFailure>(
            Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                success => Success(success).BuildAsync<TOtherFailure>(),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                _ => Current,
                otherFactoryAsync);
        }

        public ValueTask<Result<TOtherSuccess, TOtherFailure>> RecoverAsync<TOtherSuccess, TOtherFailure>(
            Func<TFailure, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherSuccess : notnull
            where TOtherFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Current.Fold(
                success => Success(mapSuccess.Invoke(success)).BuildValueAsync<TOtherFailure>(),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TOtherFailure>> RecoverAsync<TOtherFailure>(
            Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : notnull, new()
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                success => Success(success).BuildValueAsync<TOtherFailure>(),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return Current.Fold(
                _ => Current,
                otherFactoryAsync);
        }
    }
}

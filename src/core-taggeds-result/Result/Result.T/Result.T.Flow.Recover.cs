using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Recover

        public Result<TOtherSuccess, TOtherFailure> Recover<TOtherSuccess, TOtherFailure>(
            Func<TFailure, Result<TOtherSuccess, TOtherFailure>> otherFactory,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherFailure : struct
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return InternalFold(success => mapSuccess.Invoke(success), otherFactory);
        }

        public Result<TSuccess, TOtherFailure> Recover<TOtherFailure>(
            Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
            where TOtherFailure : struct
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return InternalFold(success => success, otherFactory);
        }

        public Result<TSuccess, TFailure> Recover(
            Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var @this = this;

            return InternalFold(_ => @this, otherFactory);
        }

        // Recover Async / Task

        public Task<Result<TOtherSuccess, TOtherFailure>> RecoverAsync<TOtherSuccess, TOtherFailure>(
            Func<TFailure, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<TSuccess, Task<TOtherSuccess>> mapSuccessAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));

            return InternalFold<Task<Result<TOtherSuccess, TOtherFailure>>>(
                async success => await mapSuccessAsync.Invoke(success).ConfigureAwait(false),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TOtherFailure>> RecoverAsync<TOtherFailure>(
            Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalFold(
                static success => Task.FromResult<Result<TSuccess, TOtherFailure>>(success),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            var @this = this;

            return InternalFold(_ => Task.FromResult(@this), otherFactoryAsync);
        }

        // Recover Async / ValueTask

        public ValueTask<Result<TOtherSuccess, TOtherFailure>> RecoverValueAsync<TOtherSuccess, TOtherFailure>(
            Func<TFailure, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<TSuccess, ValueTask<TOtherSuccess>> mapSuccessAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));

            return InternalFold<ValueTask<Result<TOtherSuccess, TOtherFailure>>>(
                async success => await mapSuccessAsync.Invoke(success).ConfigureAwait(false),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TOtherFailure>> RecoverValueAsync<TOtherFailure>(
            Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return InternalFold(
                static success => ValueTask.FromResult<Result<TSuccess, TOtherFailure>>(success),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TFailure>> RecoverValueAsync(
            Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            var @this = this;

            return InternalFold(_ => ValueTask.FromResult(@this), otherFactoryAsync);
        }
    }
}

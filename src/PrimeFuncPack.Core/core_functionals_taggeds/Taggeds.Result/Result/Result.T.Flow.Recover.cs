#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Recover

        public Result<TSuccess, TOtherFailure> Recover<TOtherFailure>(
            Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
            where TOtherFailure : struct
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return Fold(success => success, otherFactory);
        }

        public Result<TSuccess, TFailure> Recover(
            Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var @this = this;

            return Fold(_ => @this, otherFactory);
        }

        // Recover Async / Task

        public Task<Result<TSuccess, TOtherFailure>> RecoverAsync<TOtherFailure>(
            Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return FoldAsync(
                success => Task.FromResult<Result<TSuccess, TOtherFailure>>(success),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            var @this = this;

            return FoldAsync(_ => Task.FromResult(@this), otherFactoryAsync);
        }

        // Recover Async / ValueTask

        public ValueTask<Result<TSuccess, TOtherFailure>> RecoverValueAsync<TOtherFailure>(
            Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return FoldValueAsync(
                success => ValueTask.FromResult<Result<TSuccess, TOtherFailure>>(success),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TFailure>> RecoverValueAsync(
            Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            var @this = this;

            return FoldValueAsync(_ => ValueTask.FromResult(@this), otherFactoryAsync);
        }
    }
}

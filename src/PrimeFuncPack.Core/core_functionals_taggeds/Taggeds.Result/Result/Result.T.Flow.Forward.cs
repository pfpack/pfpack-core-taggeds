#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Forward

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

        public Task<Result<TNextSuccess, TFailure>> ForwardAsync<TNextSuccess>(
            Func<TSuccess, Task<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return FoldAsync(
                nextFactoryAsync,
                failure => Task.FromResult<Result<TNextSuccess, TFailure>>(failure));
        }

        public Task<Result<TSuccess, TFailure>> ForwardAsync(
            Func<TSuccess, Task<Result<TSuccess, TFailure>>> nextFactoryAsync)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            var @this = this;

            return FoldAsync(nextFactoryAsync, _ => Task.FromResult(@this));
        }

        // Forward Async / ValueTask

        public ValueTask<Result<TNextSuccess, TFailure>> ForwardValueAsync<TNextSuccess>(
            Func<TSuccess, ValueTask<Result<TNextSuccess, TFailure>>> nextFactoryAsync)
            where TNextSuccess : notnull
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            return FoldValueAsync(
                nextFactoryAsync,
                failure => ValueTask.FromResult<Result<TNextSuccess, TFailure>>(failure));
        }

        public ValueTask<Result<TSuccess, TFailure>> ForwardValueAsync(
            Func<TSuccess, ValueTask<Result<TSuccess, TFailure>>> nextFactoryAsync)
        {
            _ = nextFactoryAsync ?? throw new ArgumentNullException(nameof(nextFactoryAsync));

            var @this = this;

            return FoldValueAsync(nextFactoryAsync, _ => ValueTask.FromResult(@this));
        }
    }
}

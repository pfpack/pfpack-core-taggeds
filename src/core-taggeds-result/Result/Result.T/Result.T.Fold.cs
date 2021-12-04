using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public TResult Fold<TResult>(
            Func<TSuccess, TResult> mapSuccess,
            Func<TFailure, TResult> mapFailure)
        {
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return InternalFold(mapSuccess, mapFailure);
        }

        public Task<TResult> FoldAsync<TResult>(
            Func<TSuccess, Task<TResult>> mapSuccessAsync,
            Func<TFailure, Task<TResult>> mapFailureAsync)
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return InternalFold(mapSuccessAsync, mapFailureAsync);
        }

        public ValueTask<TResult> FoldValueAsync<TResult>(
            Func<TSuccess, ValueTask<TResult>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResult>> mapFailureAsync)
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return InternalFold(mapSuccessAsync, mapFailureAsync);
        }
    }
}

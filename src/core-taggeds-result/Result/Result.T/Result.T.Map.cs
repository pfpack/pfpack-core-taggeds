#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result<TResultSuccess, TResultFailure> Map<TResultSuccess, TResultFailure>(
            Func<TSuccess, TResultSuccess> mapSuccess,
            Func<TFailure, TResultFailure> mapFailure)
            where TResultFailure : struct
        {
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));
            _ = mapFailure ?? throw new ArgumentNullException(nameof(mapFailure));

            return Union.Map(mapSuccess, mapFailure).AsResult();
        }

        public async Task<Result<TResultSuccess, TResultFailure>> MapAsync<TResultSuccess, TResultFailure>(
            Func<TSuccess, Task<TResultSuccess>> mapSuccessAsync,
            Func<TFailure, Task<TResultFailure>> mapFailureAsync)
            where TResultFailure : struct
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return (await Union.MapAsync(mapSuccessAsync, mapFailureAsync).ConfigureAwait(false)).AsResult();
        }

        public async ValueTask<Result<TResultSuccess, TResultFailure>> MapValueAsync<TResultSuccess, TResultFailure>(
            Func<TSuccess, ValueTask<TResultSuccess>> mapSuccessAsync,
            Func<TFailure, ValueTask<TResultFailure>> mapFailureAsync)
            where TResultFailure : struct
        {
            _ = mapSuccessAsync ?? throw new ArgumentNullException(nameof(mapSuccessAsync));
            _ = mapFailureAsync ?? throw new ArgumentNullException(nameof(mapFailureAsync));

            return (await Union.MapValueAsync(mapSuccessAsync, mapFailureAsync).ConfigureAwait(false)).AsResult();
        }
    }
}
